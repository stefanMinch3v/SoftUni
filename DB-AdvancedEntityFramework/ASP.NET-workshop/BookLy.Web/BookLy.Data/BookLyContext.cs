namespace BookLy.Data
{
    using BookLy.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;

    public class BookLyContext : IdentityDbContext<ApplicationUser>
    {
        public BookLyContext()
            : base("BookLyContext", throwIfV1Schema: false)
        {
        }

        public static BookLyContext Create()
        {
            return new BookLyContext();
        }

        public virtual DbSet<Book> Books { get; set; }
    }
}
