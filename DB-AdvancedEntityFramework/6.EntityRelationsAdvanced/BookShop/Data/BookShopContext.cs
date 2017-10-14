namespace Data
{
    using Data.Migrations;
    using Models;
    using System.Data.Entity;

    public class BookShopContext : DbContext
    {
        public BookShopContext()
            : base("name=BookShopContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookShopContext, Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                                       .HasMany(b => b.RelatedBooks)
                                       .WithMany()//when the relation is itself leave this empty
                                       .Map(m =>
                                       {
                                           m.MapLeftKey("BookId");
                                           m.MapRightKey("RelatedId");
                                           m.ToTable("RelatedBooks");
                                       });

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Author> Authors { get; set; }

        public virtual DbSet<Book> Books { get; set; }

        public virtual DbSet<Category> Categories { get; set; }
    }
}