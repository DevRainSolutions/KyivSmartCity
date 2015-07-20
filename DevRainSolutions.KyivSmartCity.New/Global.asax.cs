using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using DevRainSolutions.KyivSmartCity.New.Areas.Admin.Models;
using DevRainSolutions.KyivSmartCity.New.Migrations;

namespace DevRainSolutions.KyivSmartCity.New
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<KyivSmartCityNewContext, Configuration>());
            //Database.SetInitializer(new CreateDatabaseIfNotExists<KyivSmartCityNewContext>());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
