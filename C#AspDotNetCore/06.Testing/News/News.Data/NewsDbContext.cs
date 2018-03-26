namespace News.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class NewsDbContext : IdentityDbContext<User>
    {
        public NewsDbContext(DbContextOptions<NewsDbContext> options)
            : base(options)
        {
        }

        public DbSet<News> News { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<News>()
                .HasOne(n => n.Author)
                .WithMany(a => a.News)
                .HasForeignKey(n => n.AuthorId);

            base.OnModelCreating(builder);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=asus-pc\sql2016;Database=ASPNewsWebApi;Integrated Security=True;Trusted_Connection=True;MultipleActiveResultSets=true");

        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
