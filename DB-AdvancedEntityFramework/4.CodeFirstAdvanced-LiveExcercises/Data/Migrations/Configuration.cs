namespace Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.MoviesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false; //if we dont want to write database-update and also this must be written in movies context - Database.SetInitializer(new MigrateDatabaseToLatestVersion<MoviesContext, Configuration>())
            AutomaticMigrationDataLossAllowed = true; // allows to delete columns with information in the DB
            ContextKey = "Data.MoviesContext";
        }

        protected override void Seed(Data.MoviesContext context)
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
