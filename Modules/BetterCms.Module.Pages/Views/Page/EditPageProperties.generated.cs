﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    
    #line 1 "..\..\Views\Page\EditPageProperties.cshtml"
    using BetterCms.Module.Pages;
    
    #line default
    #line hidden
    
    #line 2 "..\..\Views\Page\EditPageProperties.cshtml"
    using BetterCms.Module.Pages.Content.Resources;
    
    #line default
    #line hidden
    
    #line 3 "..\..\Views\Page\EditPageProperties.cshtml"
    using BetterCms.Module.Pages.Controllers;
    
    #line default
    #line hidden
    
    #line 4 "..\..\Views\Page\EditPageProperties.cshtml"
    using BetterCms.Module.Pages.ViewModels.Page;
    
    #line default
    #line hidden
    
    #line 5 "..\..\Views\Page\EditPageProperties.cshtml"
    using BetterCms.Module.Root;
    
    #line default
    #line hidden
    
    #line 6 "..\..\Views\Page\EditPageProperties.cshtml"
    using BetterCms.Module.Root.Content.Resources;
    
    #line default
    #line hidden
    
    #line 7 "..\..\Views\Page\EditPageProperties.cshtml"
    using BetterCms.Module.Root.Mvc.Extensions;
    
    #line default
    #line hidden
    
    #line 8 "..\..\Views\Page\EditPageProperties.cshtml"
    using BetterCms.Module.Root.Mvc.Helpers;
    
    #line default
    #line hidden
    
    #line 9 "..\..\Views\Page\EditPageProperties.cshtml"
    using BetterCms.Module.Root.ViewModels.Category;
    
    #line default
    #line hidden
    
    #line 10 "..\..\Views\Page\EditPageProperties.cshtml"
    using BetterCms.Module.Root.ViewModels.Tags;
    
    #line default
    #line hidden
    
    #line 11 "..\..\Views\Page\EditPageProperties.cshtml"
    using Microsoft.Web.Mvc;
    
    #line default
    #line hidden
    
    #line 12 "..\..\Views\Page\EditPageProperties.cshtml"
    using MvcContrib.EnumerableExtensions;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Page/EditPageProperties.cshtml")]
    public partial class _Views_Page_EditPageProperties_cshtml : System.Web.Mvc.WebViewPage<EditPagePropertiesViewModel>
    {
        public _Views_Page_EditPageProperties_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

            
            #line 15 "..\..\Views\Page\EditPageProperties.cshtml"
 if (Model == null)
{
    return;
}

            
            #line default
            #line hidden
            
            #line 19 "..\..\Views\Page\EditPageProperties.cshtml"
  
    var tagsTemplateViewModel = new TagsTemplateViewModel
    {
        TooltipDescription = PagesGlobalization.EditPageProperties_BasicPropertiesTab_AddTags_Tooltip_Description
    };

    var categoriesTemplateViewModel = new CategoryTemplateViewModel
    {
        TooltipDescription = PagesGlobalization.EditPageProperties_BasicPropertiesTab_Category_Tooltip_Description
    };

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<div");

WriteLiteral(" class=\"bcms-tab-header\"");

WriteLiteral(">\r\n    <a");

WriteLiteral(" class=\"bcms-tab bcms-tab-active\"");

WriteLiteral(" data-name=\"#bcms-tab-1\"");

WriteLiteral(">");

            
            #line 32 "..\..\Views\Page\EditPageProperties.cshtml"
                                                           Write(PagesGlobalization.EditPageProperties_BasicPropertiesTab_Title);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n    <a");

WriteLiteral(" class=\"bcms-tab\"");

WriteLiteral(" data-name=\"#bcms-tab-2\"");

WriteLiteral(">");

            
            #line 33 "..\..\Views\Page\EditPageProperties.cshtml"
                                           Write(PagesGlobalization.EditPageProperties_AdvancedPropertiesTab_Title);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n    <a");

WriteLiteral(" class=\"bcms-tab\"");

WriteLiteral(" data-name=\"#bcms-tab-3\"");

WriteLiteral(">");

            
            #line 34 "..\..\Views\Page\EditPageProperties.cshtml"
                                           Write(PagesGlobalization.EditPageProperties_LayoutPropertiesTab_Title);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n    <a");

WriteLiteral(" class=\"bcms-tab\"");

WriteLiteral(" data-name=\"#bcms-tab-4\"");

WriteLiteral(">");

            
            #line 35 "..\..\Views\Page\EditPageProperties.cshtml"
                                           Write(PagesGlobalization.EditPageProperties_OptionsTab_Title);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n");

            
            #line 36 "..\..\Views\Page\EditPageProperties.cshtml"
    
            
            #line default
            #line hidden
            
            #line 36 "..\..\Views\Page\EditPageProperties.cshtml"
     if (Model.ShowTranslationsTab)
    {

            
            #line default
            #line hidden
WriteLiteral("        <a");

WriteLiteral(" class=\"bcms-tab\"");

WriteLiteral(" data-name=\"#bcms-tab-5\"");

WriteLiteral(">");

            
            #line 38 "..\..\Views\Page\EditPageProperties.cshtml"
                                               Write(PagesGlobalization.EditPageProperties_TranslationsTab_Title);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n");

            
            #line 39 "..\..\Views\Page\EditPageProperties.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n\r\n<div");

WriteLiteral(" class=\"bcms-scroll-window\"");

WriteLiteral(">\r\n");

WriteLiteral("    ");

            
            #line 43 "..\..\Views\Page\EditPageProperties.cshtml"
Write(Html.TabbedContentMessagesBox());

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 44 "..\..\Views\Page\EditPageProperties.cshtml"
    
            
            #line default
            #line hidden
            
            #line 44 "..\..\Views\Page\EditPageProperties.cshtml"
     if (Model.IsMasterPage)
    {
        
            
            #line default
            #line hidden
            
            #line 46 "..\..\Views\Page\EditPageProperties.cshtml"
   Write(Html.Partial("Partial/InfoMessageAboutMasterPage"));

            
            #line default
            #line hidden
            
            #line 46 "..\..\Views\Page\EditPageProperties.cshtml"
                                                           
    }

            
            #line default
            #line hidden
WriteLiteral("    ");

            
            #line 48 "..\..\Views\Page\EditPageProperties.cshtml"
     using (Html.BeginForm<PageController>(f => f.EditPageProperties((EditPagePropertiesViewModel)null), FormMethod.Post,
            new
            {
                @class = "bcms-ajax-form",
                data_readonly = Model.IsReadOnly.ToString().ToLower()
            }))
    {

            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" id=\"bcms-tab-1\"");

WriteLiteral(" class=\"bcms-tab-single\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"bcms-padded-content\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"bcms-input-list-holder\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 58 "..\..\Views\Page\EditPageProperties.cshtml"
               Write(Html.Tooltip(PagesGlobalization.EditPageProperties_BasicPropertiesTab_PageName_Tooltip_Description));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    <div");

WriteLiteral(" class=\"bcms-content-titles\"");

WriteLiteral(">");

            
            #line 59 "..\..\Views\Page\EditPageProperties.cshtml"
                                                Write(PagesGlobalization.EditPageProperties_BasicPropertiesTab_PageName_Title);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n\r\n                    <div");

WriteLiteral(" class=\"bcms-input-box\"");

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 62 "..\..\Views\Page\EditPageProperties.cshtml"
                   Write(Html.TextBoxFor(model => model.PageName, new { @class = "bcms-editor-field-box" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                        ");

            
            #line 63 "..\..\Views\Page\EditPageProperties.cshtml"
                   Write(Html.BcmsValidationMessageFor(f => f.PageName));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </div>\r\n                </div>\r\n\r\n");

WriteLiteral("                ");

            
            #line 67 "..\..\Views\Page\EditPageProperties.cshtml"
           Write(Html.Partial("Partial/PagePropertiesEditPermalink"));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n                <div");

WriteLiteral(" class=\"bcms-page-images-holder\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"bcms-input-list-holder\"");

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 71 "..\..\Views\Page\EditPageProperties.cshtml"
                   Write(Html.Tooltip(PagesGlobalization.EditPageProperties_BasicPropertiesTab_PageImage_Tooltip_Description));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        <div");

WriteLiteral(" class=\"bcms-content-titles\"");

WriteLiteral(">");

            
            #line 72 "..\..\Views\Page\EditPageProperties.cshtml"
                                                    Write(PagesGlobalization.EditPageProperties_BasicPropertiesTab_PageImage_Title);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                        <div");

WriteLiteral(" class=\"bcms-uploaded-image\"");

WriteLiteral(">\r\n                            <!-- ko if: image().url() -->\r\n                   " +
"         <a");

WriteLiteral(" class=\"bcms-remove-image\"");

WriteLiteral(" data-bind=\"click: image().remove.bind(image())\"");

WriteLiteral(">");

            
            #line 75 "..\..\Views\Page\EditPageProperties.cshtml"
                                                                                                    Write(RootGlobalization.Button_Remove);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n                            <a");

WriteLiteral(" data-bind=\"click: image().preview.bind(image())\"");

WriteLiteral(">\r\n                                <img");

WriteLiteral(" data-bind=\"attr: { src: image().thumbnailUrl(), alt: image().tooltip() }\"");

WriteLiteral(" />\r\n                            </a>\r\n                            <!-- /ko -->\r\n" +
"                        </div>\r\n                        <div");

WriteLiteral(" class=\"bcms-btn-small\"");

WriteLiteral(" data-bind=\"click: image().select.bind(image())\"");

WriteLiteral(">");

            
            #line 81 "..\..\Views\Page\EditPageProperties.cshtml"
                                                                                               Write(PagesGlobalization.EditPageProperties_BasicPropertiesTab_SelectImage_ButtonTitle);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                    </div>\r\n\r\n                    <div");

WriteLiteral(" class=\"bcms-input-list-holder\"");

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 85 "..\..\Views\Page\EditPageProperties.cshtml"
                   Write(Html.Tooltip(PagesGlobalization.EditPageProperties_BasicPropertiesTab_PageFeaturedImage_Tooltip_Description));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        <div");

WriteLiteral(" class=\"bcms-content-titles\"");

WriteLiteral(">");

            
            #line 86 "..\..\Views\Page\EditPageProperties.cshtml"
                                                    Write(PagesGlobalization.EditPageProperties_BasicPropertiesTab_PageFeaturedImage_Title);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                        <div");

WriteLiteral(" class=\"bcms-uploaded-image\"");

WriteLiteral(">\r\n                            <!-- ko if: featuredImage().url() -->\r\n           " +
"                 <a");

WriteLiteral(" class=\"bcms-remove-image\"");

WriteLiteral(" data-bind=\"click: featuredImage().remove.bind(featuredImage())\"");

WriteLiteral(">");

            
            #line 89 "..\..\Views\Page\EditPageProperties.cshtml"
                                                                                                                    Write(RootGlobalization.Button_Remove);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n                            <a");

WriteLiteral(" data-bind=\"click: featuredImage().preview.bind(featuredImage())\"");

WriteLiteral(">\r\n                                <img");

WriteLiteral(" data-bind=\"attr: { src: featuredImage().thumbnailUrl(), alt: featuredImage().too" +
"ltip() }\"");

WriteLiteral(" />\r\n                            </a>\r\n                            <!-- /ko -->\r\n" +
"                        </div>\r\n                        <div");

WriteLiteral(" class=\"bcms-btn-small\"");

WriteLiteral(" data-bind=\"click: featuredImage().select.bind(featuredImage())\"");

WriteLiteral(">");

            
            #line 95 "..\..\Views\Page\EditPageProperties.cshtml"
                                                                                                               Write(PagesGlobalization.EditPageProperties_BasicPropertiesTab_SelectImage_ButtonTitle);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                    </div>\r\n\r\n                    <div");

WriteLiteral(" class=\"bcms-input-list-holder\"");

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 99 "..\..\Views\Page\EditPageProperties.cshtml"
                   Write(Html.Tooltip(PagesGlobalization.EditPageProperties_BasicPropertiesTab_PageSecondaryImage_Tooltip_Description));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        <div");

WriteLiteral(" class=\"bcms-content-titles\"");

WriteLiteral(">");

            
            #line 100 "..\..\Views\Page\EditPageProperties.cshtml"
                                                    Write(PagesGlobalization.EditPageProperties_BasicPropertiesTab_PageSecondaryImage_Title);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                        <div");

WriteLiteral(" class=\"bcms-uploaded-image\"");

WriteLiteral(">\r\n                            <!-- ko if: secondaryImage().url() -->\r\n          " +
"                  <a");

WriteLiteral(" class=\"bcms-remove-image\"");

WriteLiteral(" data-bind=\"click: secondaryImage().remove.bind(secondaryImage())\"");

WriteLiteral(">");

            
            #line 103 "..\..\Views\Page\EditPageProperties.cshtml"
                                                                                                                      Write(RootGlobalization.Button_Remove);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n                            <a");

WriteLiteral(" data-bind=\"click: secondaryImage().preview.bind(secondaryImage())\"");

WriteLiteral(">\r\n                                <img");

WriteLiteral(" data-bind=\"attr: { src: secondaryImage().thumbnailUrl(), alt: secondaryImage().t" +
"ooltip() }\"");

WriteLiteral(" />\r\n                            </a>\r\n                            <!-- /ko -->\r\n" +
"                        </div>\r\n                        <div");

WriteLiteral(" class=\"bcms-btn-small\"");

WriteLiteral(" data-bind=\"click: secondaryImage().select.bind(secondaryImage())\"");

WriteLiteral(">");

            
            #line 109 "..\..\Views\Page\EditPageProperties.cshtml"
                                                                                                                 Write(PagesGlobalization.EditPageProperties_BasicPropertiesTab_SelectImage_ButtonTitle);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                    </div>\r\n                </div>\r\n\r\n                <di" +
"v");

WriteLiteral(" class=\"bcms-categories-box-holder\"");

WriteLiteral(" data-bind=\"with: categories\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 114 "..\..\Views\Page\EditPageProperties.cshtml"
               Write(Html.Partial("~/Areas/bcms-root/Views/Category/CategoriesTemplate.cshtml", categoriesTemplateViewModel));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n\r\n                <div");

WriteLiteral(" class=\"bcms-tags-box-holder\"");

WriteLiteral(" data-bind=\"with: tags\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 118 "..\..\Views\Page\EditPageProperties.cshtml"
               Write(Html.Partial("~/Areas/bcms-root/Views/Tags/TagsTemplate.cshtml", tagsTemplateViewModel));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n\r\n");

            
            #line 121 "..\..\Views\Page\EditPageProperties.cshtml"
                
            
            #line default
            #line hidden
            
            #line 121 "..\..\Views\Page\EditPageProperties.cshtml"
                 if (Model.AccessControlEnabled)
                {
                    
            
            #line default
            #line hidden
            
            #line 123 "..\..\Views\Page\EditPageProperties.cshtml"
               Write(Html.Partial(RootModuleConstants.AccessControlTemplate));

            
            #line default
            #line hidden
            
            #line 123 "..\..\Views\Page\EditPageProperties.cshtml"
                                                                            
                }

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 126 "..\..\Views\Page\EditPageProperties.cshtml"
                
            
            #line default
            #line hidden
            
            #line 126 "..\..\Views\Page\EditPageProperties.cshtml"
                 if (!Model.IsMasterPage)
                {

            
            #line default
            #line hidden
WriteLiteral("                    <div");

WriteLiteral(" class=\"bcms-input-list-holder\"");

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 129 "..\..\Views\Page\EditPageProperties.cshtml"
                   Write(Html.Tooltip(PagesGlobalization.EditPageProperties_Properties_Tooltip_Description));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        <div");

WriteLiteral(" class=\"bcms-content-titles\"");

WriteLiteral(">");

            
            #line 130 "..\..\Views\Page\EditPageProperties.cshtml"
                                                    Write(PagesGlobalization.EditPageProperties_Properties_Title);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                        <div");

WriteLiteral(" class=\"bcms-checkbox-holder\"");

WriteLiteral(">\r\n");

            
            #line 132 "..\..\Views\Page\EditPageProperties.cshtml"
                            
            
            #line default
            #line hidden
            
            #line 132 "..\..\Views\Page\EditPageProperties.cshtml"
                              
                    object options = null;
                    if (!Model.CanPublishPage)
                    {
                        options = new { disabled = "disabled" };
                    }
                            
            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                            ");

            
            #line 139 "..\..\Views\Page\EditPageProperties.cshtml"
                       Write(Html.CheckBoxFor(model => model.IsPagePublished, options));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            <div");

WriteLiteral(" class=\"bcms-edit-label\"");

WriteLiteral(">");

            
            #line 140 "..\..\Views\Page\EditPageProperties.cshtml"
                                                    Write(PagesGlobalization.EditPageProperties_AdvancedPropertiesTab_Privacy_VisibleToEveryone);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                        </div>\r\n                        <div");

WriteLiteral(" class=\"bcms-checkbox-holder\"");

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 143 "..\..\Views\Page\EditPageProperties.cshtml"
                       Write(Html.CheckBoxFor(model => model.UseNoFollow));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            <div");

WriteLiteral(" class=\"bcms-edit-label\"");

WriteLiteral(">");

            
            #line 144 "..\..\Views\Page\EditPageProperties.cshtml"
                                                    Write(PagesGlobalization.EditPageProperties_AdvancedPropertiesTab_UseNoFollow);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                        </div>\r\n                        <div");

WriteLiteral(" class=\"bcms-checkbox-holder\"");

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 147 "..\..\Views\Page\EditPageProperties.cshtml"
                       Write(Html.CheckBoxFor(model => model.UseNoIndex));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            <div");

WriteLiteral(" class=\"bcms-edit-label\"");

WriteLiteral(">");

            
            #line 148 "..\..\Views\Page\EditPageProperties.cshtml"
                                                    Write(PagesGlobalization.EditPageProperties_AdvancedPropertiesTab_UseNoIndex);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                        </div>\r\n                        <div");

WriteLiteral(" class=\"bcms-checkbox-holder\"");

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 151 "..\..\Views\Page\EditPageProperties.cshtml"
                       Write(Html.CheckBoxFor(model => model.IsArchived));

            
            #line default
            #line hidden
WriteLiteral("\r\n                            <div");

WriteLiteral(" class=\"bcms-edit-label\"");

WriteLiteral(">");

            
            #line 152 "..\..\Views\Page\EditPageProperties.cshtml"
                                                    Write(PagesGlobalization.EditPageProperties_AdvancedPropertiesTab_IsArchived);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                        </div>\r\n                    </div>\r\n");

WriteLiteral("                    <div");

WriteLiteral(" class=\"bcms-input-list-holder\"");

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 156 "..\..\Views\Page\EditPageProperties.cshtml"
                   Write(Html.Tooltip(PagesGlobalization.EditPageProperties_ForceProtocol_Tooltip_Description));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        <div");

WriteLiteral(" class=\"bcms-content-titles\"");

WriteLiteral(">");

            
            #line 157 "..\..\Views\Page\EditPageProperties.cshtml"
                                                    Write(PagesGlobalization.EditPageProperties_ForceProtocol_Title);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n");

WriteLiteral("                        ");

            
            #line 158 "..\..\Views\Page\EditPageProperties.cshtml"
                   Write(Html.DropDownListFor(model => model.ForceAccessProtocol, Model.PageAccessProtocols.ToSelectList(Model.ForceAccessProtocol), null, new { @class = "bcms-global-select" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </div>\r\n");

            
            #line 160 "..\..\Views\Page\EditPageProperties.cshtml"
                }

            
            #line default
            #line hidden
WriteLiteral("                ");

            
            #line 161 "..\..\Views\Page\EditPageProperties.cshtml"
           Write(Html.HiddenFor(model => model.CanPublishPage));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 162 "..\..\Views\Page\EditPageProperties.cshtml"
           Write(Html.HiddenFor(model => model.TemplateId, new { @id = "TemplateId" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 163 "..\..\Views\Page\EditPageProperties.cshtml"
           Write(Html.HiddenFor(model => model.MasterPageId, new { @id = "MasterPageId" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 164 "..\..\Views\Page\EditPageProperties.cshtml"
           Write(Html.HiddenFor(model => model.Id));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 165 "..\..\Views\Page\EditPageProperties.cshtml"
           Write(Html.HiddenFor(model => model.Version));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 166 "..\..\Views\Page\EditPageProperties.cshtml"
           Write(Html.HiddenFor(model => model.Image.ImageId, new { data_bind = "value: image().id()" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 167 "..\..\Views\Page\EditPageProperties.cshtml"
           Write(Html.HiddenFor(model => model.SecondaryImage.ImageId, new { data_bind = "value: secondaryImage().id()" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 168 "..\..\Views\Page\EditPageProperties.cshtml"
           Write(Html.HiddenFor(model => model.FeaturedImage.ImageId, new { data_bind = "value: featuredImage().id()" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 169 "..\..\Views\Page\EditPageProperties.cshtml"
                
            
            #line default
            #line hidden
            
            #line 169 "..\..\Views\Page\EditPageProperties.cshtml"
                 if (Model.ShowTranslationsTab)
                {
                    
            
            #line default
            #line hidden
            
            #line 171 "..\..\Views\Page\EditPageProperties.cshtml"
               Write(Html.HiddenFor(model => model.LanguageId, new { data_bind = "value: translations.language.languageId()" }));

            
            #line default
            #line hidden
            
            #line 171 "..\..\Views\Page\EditPageProperties.cshtml"
                                                                                                                               
                }

            
            #line default
            #line hidden
WriteLiteral("            </div>\r\n        </div>\r\n");

            
            #line 175 "..\..\Views\Page\EditPageProperties.cshtml"


            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" id=\"bcms-tab-2\"");

WriteLiteral(" class=\"bcms-tab-single\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"bcms-padded-content\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"bcms-input-list-holder\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 179 "..\..\Views\Page\EditPageProperties.cshtml"
               Write(Html.Tooltip(PagesGlobalization.EditPageProperties_AdvancedPropertiesTab_PageCss_Tooltip_Description));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    <div");

WriteLiteral(" class=\"bcms-content-titles\"");

WriteLiteral(">");

            
            #line 180 "..\..\Views\Page\EditPageProperties.cshtml"
                                                Write(PagesGlobalization.EditPageProperties_AdvancedPropertiesTab_PageCss_Title);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n");

WriteLiteral("                    ");

            
            #line 181 "..\..\Views\Page\EditPageProperties.cshtml"
               Write(Html.TextAreaFor(model => model.PageCSS, new { @class = "bcms-editor-field-area bcms-code-field bcms-code-field-css" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n\r\n                <div");

WriteLiteral(" class=\"bcms-input-list-holder\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 185 "..\..\Views\Page\EditPageProperties.cshtml"
               Write(Html.Tooltip(PagesGlobalization.EditPageProperties_AdvancedPropertiesTab_PageJavascript_Tooltip_Description));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    <div");

WriteLiteral(" class=\"bcms-content-titles\"");

WriteLiteral(">");

            
            #line 186 "..\..\Views\Page\EditPageProperties.cshtml"
                                                Write(PagesGlobalization.EditPageProperties_AdvancedPropertiesTab_PageJavascript_Title);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n");

WriteLiteral("                    ");

            
            #line 187 "..\..\Views\Page\EditPageProperties.cshtml"
               Write(Html.TextAreaFor(model => model.PageJavascript, new { @class = "bcms-editor-field-area bcms-code-field bcms-code-field-javascript" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n");

            
            #line 191 "..\..\Views\Page\EditPageProperties.cshtml"


            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" id=\"bcms-tab-3\"");

WriteLiteral(" class=\"bcms-tab-single\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"bcms-padded-content\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"bcms-input-list-holder\"");

WriteLiteral(">\r\n");

WriteLiteral("                    ");

            
            #line 195 "..\..\Views\Page\EditPageProperties.cshtml"
               Write(Html.Tooltip(PagesGlobalization.EditPageProperties_LayoutPropertiesTab_Layout_Tooltip_Description));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    <div");

WriteLiteral(" class=\"bcms-content-titles\"");

WriteLiteral(">");

            
            #line 196 "..\..\Views\Page\EditPageProperties.cshtml"
                                                Write(PagesGlobalization.EditPageProperties_LayoutPropertiesTab_ChooseLayout_Title);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                </div>\r\n\r\n                <div");

WriteLiteral(" class=\"bcms-info-message-box\"");

WriteLiteral(">\r\n                    <a");

WriteLiteral(" class=\"bcms-btn-close\"");

WriteLiteral(">");

            
            #line 200 "..\..\Views\Page\EditPageProperties.cshtml"
                                         Write(RootGlobalization.Button_Close);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n");

WriteLiteral("                    ");

            
            #line 201 "..\..\Views\Page\EditPageProperties.cshtml"
               Write(Html.Raw(PagesGlobalization.EditPageProperties_LayoutPropertiesTab_InfoMessage));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n\r\n");

WriteLiteral("                ");

            
            #line 204 "..\..\Views\Page\EditPageProperties.cshtml"
           Write(Html.Partial("Partial/TemplatesList", Model.Templates));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n        </div>\r\n");

            
            #line 207 "..\..\Views\Page\EditPageProperties.cshtml"


            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" id=\"bcms-tab-4\"");

WriteLiteral(" class=\"bcms-tab-single\"");

WriteLiteral(" data-bind=\"with: options\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 209 "..\..\Views\Page\EditPageProperties.cshtml"
       Write(Html.Partial(PagesConstants.OptionValuesGridTemplate));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n");

            
            #line 211 "..\..\Views\Page\EditPageProperties.cshtml"

        if (Model.ShowTranslationsTab)
        {

            
            #line default
            #line hidden
WriteLiteral("            <div");

WriteLiteral(" id=\"bcms-tab-5\"");

WriteLiteral(" class=\"bcms-tab-single\"");

WriteLiteral(">\r\n\r\n");

            
            #line 216 "..\..\Views\Page\EditPageProperties.cshtml"
                
            
            #line default
            #line hidden
            
            #line 216 "..\..\Views\Page\EditPageProperties.cshtml"
                 if (Model.TranslationMessages != null)
                {
                    
            
            #line default
            #line hidden
            
            #line 218 "..\..\Views\Page\EditPageProperties.cshtml"
               Write(Html.TabbedContentCustomMessagesBox(Model.TranslationMessages));

            
            #line default
            #line hidden
            
            #line 218 "..\..\Views\Page\EditPageProperties.cshtml"
                                                                                   
                }

            
            #line default
            #line hidden
WriteLiteral("\r\n                <div");

WriteLiteral(" class=\"bcms-padded-content bcms-page-translations-content\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"bcms-input-list-holder\"");

WriteLiteral(" data-bind=\"with: translations.language\"");

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 223 "..\..\Views\Page\EditPageProperties.cshtml"
                   Write(Html.Tooltip(PagesGlobalization.EditPageProperties_TranslationsTab_Language_Tooltip_Description));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        <div");

WriteLiteral(" class=\"bcms-content-titles\"");

WriteLiteral(">");

            
            #line 224 "..\..\Views\Page\EditPageProperties.cshtml"
                                                    Write(PagesGlobalization.EditPageProperties_TranslationsTab_Language);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                        <select");

WriteLiteral(" class=\"bcms-global-select\"");

WriteLiteral(" data-bind=\"options: languages, optionsText: \'value\', optionsValue: \'key\', value:" +
" languageId\"");

WriteLiteral("></select>\r\n                    </div>\r\n\r\n                    <div");

WriteLiteral(" class=\"bcms-title-show-helper\"");

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 229 "..\..\Views\Page\EditPageProperties.cshtml"
                   Write(Html.Tooltip(PagesGlobalization.EditPageTranslations_OtherLanguages_Tooltip));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        <div");

WriteLiteral(" class=\"bcms-content-titles\"");

WriteLiteral(">");

            
            #line 230 "..\..\Views\Page\EditPageProperties.cshtml"
                                                    Write(PagesGlobalization.EditPageTranslations_OtherLanguages_Title);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                    </div>\r\n                </div>\r\n\r\n");

WriteLiteral("                ");

            
            #line 234 "..\..\Views\Page\EditPageProperties.cshtml"
           Write(Html.Partial("Partial/TranslationsGrid"));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n            </div>\r\n");

            
            #line 237 "..\..\Views\Page\EditPageProperties.cshtml"
        }

        
            
            #line default
            #line hidden
            
            #line 239 "..\..\Views\Page\EditPageProperties.cshtml"
   Write(Html.HiddenSubmit());

            
            #line default
            #line hidden
            
            #line 239 "..\..\Views\Page\EditPageProperties.cshtml"
                            
    }

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n");

        }
    }
}
#pragma warning restore 1591
