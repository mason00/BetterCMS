﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18449
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BetterCms.Module.Root.Views.Shared.Layouts
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/Layouts/Preview.cshtml")]
    public partial class Preview : System.Web.Mvc.WebViewPage<dynamic>
    {
        public Preview()
        {
        }
        public override void Execute()
        {
WriteLiteral("<!DOCTYPE html>\r\n<html>\r\n<head>\r\n    <title>");

            
            #line 4 "..\..\Views\Shared\Layouts\Preview.cshtml"
      Write(ViewBag.Title);

            
            #line default
            #line hidden
WriteLiteral("</title>     \r\n</head>\r\n    <body>\r\n        <div");

WriteLiteral(" class=\"bcms-preview\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 8 "..\..\Views\Shared\Layouts\Preview.cshtml"
       Write(RenderBody());

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n");

WriteLiteral("        ");

            
            #line 10 "..\..\Views\Shared\Layouts\Preview.cshtml"
   Write(RenderSection("Scripts", false));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </body>\r\n</html>\r\n");

        }
    }
}
#pragma warning restore 1591
