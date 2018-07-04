using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BlogEngine.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Post",
                url: "post/{slug}/{id}",
                defaults: new { controller = "Post", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "BlogEngine.Web.Controllers" }
            );

            routes.MapRoute(
               name: "Posts By Category",
               url: "category/{slug}/{id}",
               defaults: new { controller = "Post", action = "PostsByCategory", id = UrlParameter.Optional },
               namespaces: new string[] { "BlogEngine.Web.Controllers" }
            );

            routes.MapRoute(
               name: "Posts By Sub Category",
               url: "subcategory/{slug}/{id}",
               defaults: new { controller = "Post", action = "PostsBySubCategory", id = UrlParameter.Optional },
               namespaces: new string[] { "BlogEngine.Web.Controllers" }
            );

            routes.MapRoute(
                name: "About Me",
                url: "about-me",
                defaults: new { controller = "About", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "BlogEngine.Web.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "BlogEngine.Web.Controllers" }
            );
        }
    }
}
