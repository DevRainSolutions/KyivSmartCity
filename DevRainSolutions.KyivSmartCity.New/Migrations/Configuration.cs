using DevRainSolutions.KyivSmartCity.New.Areas.Admin.Models;

namespace DevRainSolutions.KyivSmartCity.New.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<KyivSmartCityNewContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "DevRainSolutions.KyivSmartCity.New.Areas.Admin.Models.KyivSmartCityNewContext";
        }

        protected override void Seed(DevRainSolutions.KyivSmartCity.New.Areas.Admin.Models.KyivSmartCityNewContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
