using System.Web.Mvc;
using LowercaseRoutesMVC;

namespace DevRainSolutions.KyivSmartCity.New.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRouteLowercase(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", controller = "Home", id = UrlParameter.Optional },
                new[] { "DevRainSolutions.KyivSmartCity.New.Areas.Admin.Controllers" }
            );
        }
    }
}