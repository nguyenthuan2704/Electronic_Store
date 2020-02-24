using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Electronic_Store
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Electronic_Store.Controllers" }
            );

            routes.MapRoute(
                name: "About",
                url: "About/{id}",
                defaults: new { controller = "Home", action = "About", id = UrlParameter.Optional },
                namespaces: new[] { "Electronic_Store.Controllers" }
            );

            routes.MapRoute(
                name: "Contact_Us",
                url: "Contact_Us/{id}",
                defaults: new { controller = "Home", action = "Contact_Us", id = UrlParameter.Optional },
                namespaces: new[] { "Electronic_Store.Controllers" }
            );

            routes.MapRoute(
                name: "All_Product",
                url: "All_Product/{id}",
                defaults: new { controller = "Home", action = "Product", id = UrlParameter.Optional },
                namespaces: new[] { "Electronic_Store.Controllers" }
            );

            routes.MapRoute(
                name: "Detail",
                url: "Detail/{id}",
                defaults: new { controller = "Home", action = "Detail", id = UrlParameter.Optional },
                namespaces: new[] { "Electronic_Store.Controllers" }
            );

            routes.MapRoute(
                name: "Search",
                url: "Search/{id}",
                defaults: new { controller = "Home", action = "Search", id = UrlParameter.Optional },
                namespaces: new[] { "Electronic_Store.Controllers" }
            );

            routes.MapRoute(
                name: "Cart",
                url: "Cart/{id}",
                defaults: new { controller = "Home", action = "Cart", id = UrlParameter.Optional },
                namespaces: new[] { "Electronic_Store.Controllers" }
            );

        }
    }
}
