﻿using System;
using System.Runtime.Serialization;

using BetterCms.Module.Api.Infrastructure;

using ServiceStack.ServiceHost;

namespace BetterCms.Module.Api.Operations.Pages.Sitemaps.Sitemap
{
    /// <summary>
    /// Sitemap delete request.
    /// </summary>
    [Route("/sitemaps/{SitemapId}", Verbs = "DELETE")]
    [Serializable]
    [DataContract]
    public class DeleteSitemapRequest : DeleteRequestBase, IReturn<DeleteSitemapResponse>
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [DataMember]
        public Guid SitemapId { get; set; }
    }
}