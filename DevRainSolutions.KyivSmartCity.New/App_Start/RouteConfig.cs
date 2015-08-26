using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using DevRainSolutions.KyivSmartCity.New.Controllers;
using LowercaseRoutesMVC;

namespace DevRainSolutions.KyivSmartCity.New
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRouteLowercase("Root", "{action}",
                new { controller = "Home", action = "Index", area="" },
                new { isMethodInHomeController = new RootRouteConstraint<HomeController>() },
                new[] { "DevRainSolutions.KyivSmartCity.New.Controllers" });

            routes.MapRouteLowercase("Details", "{controller}/{id}",
                new { action = "Details", area = "" },
                new { id = @"\d+" },
                new[] { "DevRainSolutions.KyivSmartCity.New.Controllers" });

            routes.MapRouteLowercase(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }, // Parameter defaults
                new[] { "DevRainSolutions.KyivSmartCity.New.Controllers" }
            );
        }
    }

    public class RootRouteConstraint<T> : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            var rootMethodNames = typeof(T).GetMethods().Select(x => x.Name.ToLower());
            return rootMethodNames.Contains(values["action"].ToString().ToLower());
        }

    }
}
