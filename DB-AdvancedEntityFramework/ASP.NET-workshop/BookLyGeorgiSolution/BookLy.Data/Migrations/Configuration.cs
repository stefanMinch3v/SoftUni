namespace BookLy.Data.Migrations
{
    using System.Data.Entity.Migrations;

    using BookLy.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            context.Genres.AddOrUpdate(g => g.Name, new Genre { Name = "Thriller" });
            context.Genres.AddOrUpdate(g => g.Name, new Genre { Name = "Romance" });
            context.Genres.AddOrUpdate(g => g.Name, new Genre { Name = "Action" });
            context.Genres.AddOrUpdate(g => g.Name, new Genre { Name = "Sci-Fi" });
            context.Genres.AddOrUpdate(g => g.Name, new Genre { Name = "Crime" });
            context.Genres.AddOrUpdate(g => g.Name, new Genre { Name = "Mystery" });
            context.Genres.AddOrUpdate(g => g.Name, new Genre { Name = "Humour" });
        }
    }
}
