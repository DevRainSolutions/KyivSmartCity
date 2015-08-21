using System.Web.Mvc;

namespace DevRainSolutions.KyivSmartCity.New.Areas.Hackathon
{
    public class HachathonAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Hackathon";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Hackathon_default",
                "Hackathon/{controller}/{action}/{id}",
                new { action = "Index", controller="Home", id = UrlParameter.Optional },
                 new[] { "DevRainSolutions.KyivSmartCity.New.Areas.Hackathon.Controllers" }
            );
        }
    }
}