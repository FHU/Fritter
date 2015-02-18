namespace Fritter.Migrations
{
    using Fritter.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Fritter.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Fritter.Models.ApplicationDbContext";
        }

        protected override void Seed(Fritter.Models.ApplicationDbContext context)
        {

            context.Treats.Add(new Treat(6, "Wow! It's cold today.", "TylerEstes"));
            context.Treats.Add(new Treat(7, "I love FHU.", "Sara"));

            //context.SaveChanges();

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
