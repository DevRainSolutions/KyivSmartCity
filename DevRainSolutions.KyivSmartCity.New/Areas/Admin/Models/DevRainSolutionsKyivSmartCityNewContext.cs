using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DevRainSolutions.KyivSmartCity.New.Areas.Admin.Models
{
    public class KyivSmartCityNewContext : DbContext
    {
        public KyivSmartCityNewContext()
            : base("DefaultConnection")
        {
            
        }

        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<DevRainSolutions.KyivSmartCity.New.Areas.Admin.Models.DevRainSolutionsKyivSmartCityNewContext>());

        public DbSet<DevRainSolutions.KyivSmartCity.New.Models.TeamMember> TeamMembers { get; set; }

        public DbSet<DevRainSolutions.KyivSmartCity.New.Models.NewsItem> NewsItems { get; set; }

        public DbSet<DevRainSolutions.KyivSmartCity.New.Models.Group> Groups { get; set; }

        public DbSet<DevRainSolutions.KyivSmartCity.New.Models.Expert> Experts { get; set; }

        public DbSet<DevRainSolutions.KyivSmartCity.New.Models.Document> Documents { get; set; }

        public DbSet<DevRainSolutions.KyivSmartCity.New.Models.Volunteer> Volunteers { get; set; }
    }
}