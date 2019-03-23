namespace SugarFreeDiet.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SugarFreeDiet.DAL.SugarFreeDietContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SugarFreeDiet.DAL.SugarFreeDietContext context)
        {
            context.Roles.AddOrUpdate(
               p => p.Name,
               new IdentityRole { Name = "Admin" },
               new IdentityRole { Name = "User" }
             );
        }
    }
}
