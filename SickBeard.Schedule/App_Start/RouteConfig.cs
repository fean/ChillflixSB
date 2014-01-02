using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SickBeard.Schedule
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Schedule",
                url: "Schedule",
                defaults: new { controller = "Schedule", action = "Schedule", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Overview",
                url: "Overview",
                defaults: new { controller = "Schedule", action = "Overview", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Request",
                url: "Request",
                defaults: new { controller = "Schedule", action = "Request", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Login",
                url: "Login",
                defaults: new { controller = "Authentication", action = "Login", ReturnUrl = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Schedule", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}