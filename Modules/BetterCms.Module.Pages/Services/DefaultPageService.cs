﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

using BetterCms.Core.DataAccess;
using BetterCms.Core.DataAccess.DataContext;
using BetterCms.Core.DataContracts;
using BetterCms.Core.Exceptions.DataTier;
using BetterCms.Core.Exceptions.Mvc;
using BetterCms.Core.Modules.Projections;
using BetterCms.Core.Mvc;
using BetterCms.Core.Security;
using BetterCms.Core.Services;
using BetterCms.Core.Web;

using BetterCms.Module.Pages.Content.Resources;
using BetterCms.Module.Pages.Helpers;
using BetterCms.Module.Pages.Models;
using BetterCms.Module.Pages.ViewModels.Page;

using BetterCms.Module.Root;
using BetterCms.Module.Root.Models;
using BetterCms.Module.Root.Mvc.Helpers;

using Common.Logging;

using NHibernate.Linq;

using Page = BetterCms.Module.Pages.Models.PageProperties;
using RootPage = BetterCms.Module.Root.Models.Page;

namespace BetterCms.Module.Pages.Services
{
    public class DefaultPageService : IPageAccessor, IPageService
    {
        private static readonly ILog Logger = LogManager.GetCurrentClassLogger(); 
        
        private readonly IRepository repository;
        private readonly IRedirectService redirectService;
        private readonly IUrlService urlService;
        private readonly IAccessControlService accessControlService;
        private readonly ICmsConfiguration cmsConfiguration;
        private readonly ISitemapService sitemapService;
        private readonly IUnitOfWork unitOfWork;

        private IDictionary<string, IPage> temporaryPageCache;

        public DefaultPageService(
            IRepository repository, 
            IRedirectService redirectService, 
            IUrlService urlService,
            IAccessControlService accessControlService, 
            ICmsConfiguration cmsConfiguration, 
            ISitemapService sitemapService, 
            IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.redirectService = redirectService;
            this.urlService = urlService;
            this.accessControlService = accessControlService;
            this.cmsConfiguration = cmsConfiguration;
            this.unitOfWork = unitOfWork;
            this.sitemapService = sitemapService;

            temporaryPageCache = new Dictionary<string, IPage>();
        }
        
        /// <summary>
        /// Gets current page.
        /// </summary>
        /// <returns>Current page object.</returns>
        public IPage GetCurrentPage(HttpContextBase httpContext)
        {
            // TODO: remove it or optimize it.
            var http = new HttpContextTool(httpContext);
            var virtualPath = HttpUtility.UrlDecode(http.GetAbsolutePath());            
            return GetPageByVirtualPath(virtualPath) ?? new Page(); // TODO: do not return empty page, should implemented another logic.
        }

        /// <summary>
        /// Gets current page by given virtual path.
        /// </summary>
        /// <param name="virtualPath"></param>
        /// <returns>
        /// Current page object by given virtual path.
        /// </returns>
        public IPage GetPageByVirtualPath(string virtualPath)
        {
            var trimmed = virtualPath.UrlHash();
            if (temporaryPageCache.ContainsKey(trimmed))
            {
                return temporaryPageCache[trimmed];
            }

            // NOTE: if GetPageQuery() and CachePage() is used properly below code should not be executed.
            var inSitemapFuture = repository.AsQueryable<SitemapNode>().Where(node => node.UrlHash == trimmed && !node.IsDeleted && !node.Sitemap.IsDeleted).Select(node => node.Id).ToFuture();
            var page = repository
                .AsQueryable<PageProperties>(p => p.PageUrlHash == trimmed)
                .Fetch(p => p.Layout)
                .FirstOrDefault();

            if (page != null)
            {
                page.IsInSitemap = inSitemapFuture.Any() || repository.AsQueryable<SitemapNode>().Any(node => node.Page.Id == page.Id && !node.IsDeleted && !node.Sitemap.IsDeleted);
                temporaryPageCache.Add(trimmed, page);
            }

            return page;
        }

        /// <summary>
        /// Gets the page query.
        /// </summary>
        /// <returns>Queryable to find the page.</returns>
        public IQueryable<IPage> GetPageQuery()
        {
            return repository.AsQueryable<PageProperties>();
        }

        /// <summary>
        /// Caches the page.
        /// </summary>
        /// <param name="page">The page.</param>
        public void CachePage(IPage page)
        {
            var pageProperties = page as PageProperties;
            if (pageProperties != null)
            {
                pageProperties.IsInSitemap = SitemapHelper.IsPageInSitemap(
                    repository,
                    pageProperties.PageUrlHash,
                    pageProperties.Id,
                    pageProperties.LanguageGroupIdentifier);
                temporaryPageCache.Add(pageProperties.PageUrlHash, pageProperties);
            }
        }

        /// <summary>
        /// Validates the page URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="pageId">The page id.</param>
        /// <exception cref="System.ComponentModel.DataAnnotations.ValidationException"></exception>
        public void ValidatePageUrl(string url, Guid? pageId = null)
        {
            // Validate url
            if (!urlService.ValidateInternalUrl(url))
            {
                var logMessage = string.Format("Invalid page url {0}.", url);
                throw new ValidationException(() => PagesGlobalization.ValidatePageUrlCommand_InvalidUrlPath_Message, logMessage);
            }

            string patternsValidationMessage;
            if (!urlService.ValidateUrlPatterns(url, out patternsValidationMessage))
            {
                var logMessage = string.Format("{0}. URL: {1}.", patternsValidationMessage, url);
                throw new ValidationException(() => patternsValidationMessage, logMessage);
            }

            // Is Url unique
            var query = repository.AsQueryable<PageProperties>(page => page.PageUrlHash == url.UrlHash());
            if (pageId.HasValue && pageId != default(Guid))
            {
                query = query.Where(page => page.Id != pageId.Value);
            }

            if (query.Select(page => page.Id).Any())
            {
                var logMessage = string.Format("Page with entered URL {0} already exists.", url);
                throw new ValidationException(() => PagesGlobalization.ValidatePageUrlCommand_UrlAlreadyExists_Message, logMessage);
            }
        }

        /// <summary>
        /// Creates the page permalink.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="parentPageUrl">The parent page URL.</param>
        /// <returns>
        /// Created permalink
        /// </returns>
        public string CreatePagePermalink(string url, string parentPageUrl, Guid? parentPageId = null, Guid? languageId = null, Guid? categoryId = null)
        {
            string newUrl = null;
            if (UrlHelper.GeneratePageUrl != null)
            {
                try
                {
                    newUrl =
                        UrlHelper.GeneratePageUrl(
                            new PageUrlGenerationRequest
                            {
                                Title = url,
                                ParentPageId = parentPageId,
                                LanguageId = languageId,
                                CategoryId = categoryId
                            });
                }
                catch (Exception ex)
                {
                    Logger.Error("Custom page url generation failed.", ex);
                }
            }

            if (string.IsNullOrWhiteSpace(newUrl))
            {
                newUrl = CreatePagePermalinkDefault(url, parentPageUrl);
            }
            else
            {
                newUrl = urlService.AddPageUrlPostfix(newUrl, "{0}");
            }

            return newUrl;
        }

        private string CreatePagePermalinkDefault(string url, string parentPageUrl)
        {
            var prefixPattern = string.IsNullOrWhiteSpace(parentPageUrl)
                ? "{0}"
                : string.Concat(parentPageUrl.Trim('/'), "/{0}");

            url = url.Transliterate(true);
            url = urlService.AddPageUrlPostfix(url, prefixPattern);

            return url;
        }

        /// <summary>
        /// Gets the redirect for given url.
        /// </summary>
        /// <param name="virtualPath">The virtual path.</param>
        /// <returns>
        /// Redirect URL
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public string GetRedirect(string virtualPath)
        {
            return redirectService.GetRedirect(virtualPath);
        }

        /// <summary>
        /// Gets the list of meta data projections.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <returns>The list of meta data projections</returns>
        public IList<IPageActionProjection> GetPageMetaData(IPage page)
        {
            var metaData = new List<IPageActionProjection>();

            var rootPage = page as RootPage;
            if (rootPage != null)
            {
                if (!string.IsNullOrWhiteSpace(rootPage.MetaDescription))
                {
                    metaData.Add(new MetaDataProjection("description", rootPage.MetaDescription));
                }
                if (!string.IsNullOrWhiteSpace(rootPage.MetaKeywords))
                {
                    metaData.Add(new MetaDataProjection("keywords", rootPage.MetaKeywords));
                }
            }

            var pageProperties = page as Page;
            if (pageProperties != null)
            {
                if (pageProperties.UseNoFollow || pageProperties.UseNoIndex)
                {
                    string robotsContent = null;
                    if (pageProperties.UseNoIndex)
                    {
                        robotsContent = "noindex";
                    }
                    if (pageProperties.UseNoFollow)
                    {
                        if (!string.IsNullOrEmpty(robotsContent))
                        {
                            robotsContent += ",";
                        }
                        robotsContent += "nofollow";
                    }
                    metaData.Add(new MetaDataProjection("robots", robotsContent));
                }
                if (pageProperties.UseCanonicalUrl)
                {
                    metaData.Add(new RelationProjection("canonical", page.PageUrl));
                }
            }
            
            return metaData;
        }

        /// <summary>
        /// Gets the list of page translation view models.
        /// </summary>
        /// <param name="languageGroupIdentifier">Language group identifier.</param>
        /// <returns>
        /// The list of page translation view models
        /// </returns>
        public IEnumerable<PageTranslationViewModel> GetPageTranslations(Guid languageGroupIdentifier)
        {
            return repository
                .AsQueryable<Root.Models.Page>()
                .Where(p => p.LanguageGroupIdentifier == languageGroupIdentifier)
                .Select(p => new PageTranslationViewModel
                {
                    Id = p.Id,
                    Title = p.Title,
                    PageUrl = p.PageUrl,
                    LanguageId = p.Language.Id
                })
                .ToFuture();
        }

        /// <summary>
        /// Deletes the page.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="principal">The principal.</param>
        /// <param name="messages">The messages.</param>
        /// <returns>
        /// Delete result
        /// </returns>
        /// <exception cref="ConcurrentDataException"></exception>
        /// <exception cref="System.ComponentModel.DataAnnotations.ValidationException">
        /// </exception>
        public bool DeletePage(DeletePageViewModel model, IPrincipal principal, IMessagesIndicator messages = null)
        {
            var page = repository.First<PageProperties>(model.PageId);
            if (model.Version > 0 && page.Version != model.Version)
            {
                throw new ConcurrentDataException(page);
            }

            if (page.IsMasterPage && repository.AsQueryable<MasterPage>(mp => mp.Master == page).Any())
            {
                var message = PagesGlobalization.DeletePageCommand_MasterPageHasChildren_Message;
                var logMessage = string.Format("Failed to delete page. Page is selected as master page. Id: {0} Url: {1}", page.Id, page.PageUrl);
                throw new ValidationException(() => message, logMessage);
            }

            var isRedirectInternal = false;
            if (!string.IsNullOrWhiteSpace(model.RedirectUrl))
            {
                isRedirectInternal = urlService.ValidateInternalUrl(model.RedirectUrl);
                if (!isRedirectInternal && urlService.ValidateInternalUrl(urlService.FixUrl(model.RedirectUrl)))
                {
                    isRedirectInternal = true;
                }
                if (isRedirectInternal)
                {
                    model.RedirectUrl = urlService.FixUrl(model.RedirectUrl);
                }
            }

            if (model.UpdateSitemap)
            {
                accessControlService.DemandAccess(principal, RootModuleConstants.UserRoles.EditContent);
            }

            var sitemaps = new Dictionary<Sitemap, bool>();
            var sitemapNodes = sitemapService.GetNodesByPage(page);
            if (model.UpdateSitemap)
            {
                sitemapNodes.Select(node => node.Sitemap)
                            .Distinct()
                            .ToList()
                            .ForEach(
                                sitemap =>
                                sitemaps.Add(
                                    sitemap,
                                    !cmsConfiguration.Security.AccessControlEnabled || accessControlService.GetAccessLevel(sitemap, principal) == AccessLevel.ReadWrite));

                foreach (var node in sitemapNodes)
                {
                    if (sitemaps[node.Sitemap] && node.ChildNodes.Count > 0)
                    {
                        var logMessage = string.Format("In {0} sitemap node {1} has {2} child nodes.", node.Sitemap.Id, node.Id, node.ChildNodes.Count);
                        throw new ValidationException(() => PagesGlobalization.DeletePageCommand_SitemapNodeHasChildNodes_Message, logMessage);
                    }
                }
            }

            unitOfWork.BeginTransaction();

            IList<SitemapNode> updatedNodes = new List<SitemapNode>();
            IList<SitemapNode> deletedNodes = new List<SitemapNode>();
            if (sitemapNodes != null)
            {
                // Archive sitemaps before update.
                sitemaps.Select(pair => pair.Key).ToList().ForEach(sitemap => sitemapService.ArchiveSitemap(sitemap.Id));
                foreach (var node in sitemapNodes)
                {
                    if (!node.IsDeleted)
                    {
                        if (model.UpdateSitemap && sitemaps[node.Sitemap])
                        {
                            // Delete sitemap node.
                            sitemapService.DeleteNode(node, ref deletedNodes);
                        }
                        else
                        {
                            // Unlink sitemap node.
                            if (node.Page != null && node.Page.Id == page.Id)
                            {
                                node.Page = null;
                                node.Title = node.UsePageTitleAsNodeTitle ? page.Title : node.Title;
                                node.Url = page.PageUrl;
                                node.UrlHash = page.PageUrlHash;
                                repository.Save(node);
                                updatedNodes.Add(node);
                            }
                        }
                    }
                }
            }

            Redirect redirect;
            if (!string.IsNullOrWhiteSpace(model.RedirectUrl))
            {
                if (string.Equals(page.PageUrl, model.RedirectUrl, StringComparison.OrdinalIgnoreCase))
                {
                    var logMessage = string.Format("Circular redirect loop from url {0} to url {0}.", model.RedirectUrl);
                    throw new ValidationException(() => PagesGlobalization.ValidatePageUrlCommand_SameUrlPath_Message, logMessage);
                }

                // Validate url
                if (!urlService.ValidateExternalUrl(model.RedirectUrl))
                {
                    var logMessage = string.Format("Invalid redirect url {0}.", model.RedirectUrl);
                    throw new ValidationException(() => PagesGlobalization.ValidatePageUrlCommand_InvalidUrlPath_Message, logMessage);
                }

                string patternsValidationMessage;
                if (isRedirectInternal
                    && !urlService.ValidateUrlPatterns(model.RedirectUrl, out patternsValidationMessage, PagesGlobalization.DeletePage_RedirectUrl_Name))
                {
                    var logMessage = string.Format("{0}. URL: {1}.", patternsValidationMessage, model.RedirectUrl);
                    throw new ValidationException(() => patternsValidationMessage, logMessage);
                }

                redirect = redirectService.GetPageRedirect(page.PageUrl);
                if (redirect != null)
                {
                    redirect.RedirectUrl = model.RedirectUrl;
                }
                else
                {
                    redirect = redirectService.CreateRedirectEntity(page.PageUrl, model.RedirectUrl);
                }

                if (redirect != null)
                {
                    repository.Save(redirect);
                }
            }
            else
            {
                redirect = null;
            }

            // Delete child entities.            
            if (page.PageTags != null)
            {
                foreach (var pageTag in page.PageTags)
                {
                    repository.Delete(pageTag);
                }
            }

            var deletedPageContents = new List<PageContent>();
            if (page.PageContents != null)
            {
                foreach (var pageContent in page.PageContents)
                {
                    repository.Delete(pageContent);
                    deletedPageContents.Add(pageContent);
                }
            }

            if (page.Options != null)
            {
                foreach (var option in page.Options)
                {
                    repository.Delete(option);
                }
            }

            if (page.AccessRules != null)
            {
                var rules = page.AccessRules.ToList();
                rules.ForEach(page.RemoveRule);
            }

            if (page.MasterPages != null)
            {
                foreach (var master in page.MasterPages)
                {
                    repository.Delete(master);
                }
            }

            // Delete page
            repository.Delete<Root.Models.Page>(page);

            // Commit
            unitOfWork.Commit();

            var updatedSitemaps = new List<Sitemap>();
            foreach (var node in updatedNodes)
            {
                Events.SitemapEvents.Instance.OnSitemapNodeUpdated(node);
                if (!updatedSitemaps.Contains(node.Sitemap))
                {
                    updatedSitemaps.Add(node.Sitemap);
                }
            }

            foreach (var node in deletedNodes)
            {
                Events.SitemapEvents.Instance.OnSitemapNodeDeleted(node);
                if (!updatedSitemaps.Contains(node.Sitemap))
                {
                    updatedSitemaps.Add(node.Sitemap);
                }
            }

            foreach (var updatedSitemap in updatedSitemaps)
            {
                Events.SitemapEvents.Instance.OnSitemapUpdated(updatedSitemap);
            }

            // Notifying about redirect created
            if (redirect != null)
            {
                Events.PageEvents.Instance.OnRedirectCreated(redirect);
            }

            // Notify about deleted page contents
            foreach (var deletedPageContent in deletedPageContents)
            {
                Events.PageEvents.Instance.OnPageContentDeleted(deletedPageContent);
            }

            // Notifying, that page is deleted.
            Events.PageEvents.Instance.OnPageDeleted(page);

            if (sitemaps.Any(tuple => !tuple.Value) && messages != null)
            {
                // Some sitemaps where skipped, because user has no permission to edit.
                messages.AddSuccess(PagesGlobalization.DeletePage_SitemapSkipped_Message);
            }

            return true;
        }
    }
}