using System.Web.Mvc;
using LowercaseRoutesMVC;

namespace DevRainSolutions.KyivSmartCity.New.Areas.En
{
    public class EnAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "En";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRouteLowercase("Root_En", "en/{action}",
           new { controller = "Home", action = "Index" },
           new { isMethodInHomeController = new RootRouteConstraint<DevRainSolutions.KyivSmartCity.New.Areas.En.Controllers.HomeController>() },
            new[] { "DevRainSolutions.KyivSmartCity.New.Areas.En.Controllers" }
           );
           

            context.MapRouteLowercase(
                "En_default",
                "En/{controller}/{action}/{id}",
                new { action = "Index", controller="Home", id = UrlParameter.Optional },
                new[] { "DevRainSolutions.KyivSmartCity.New.Areas.En.Controllers" }
            );

          
        }
    }
}