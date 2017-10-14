namespace BookLy.Data.Configurations
{
    using System.Data.Entity.ModelConfiguration;

    using BookLy.Models;

    public class UserEntityConfiguration : EntityTypeConfiguration<ApplicationUser>
    {
        public UserEntityConfiguration()
        {
            this.HasMany(u => u.Books)
                .WithRequired(b => b.Author)
                .HasForeignKey(b => b.AuthorId)
                .WillCascadeOnDelete(false);

            this.HasMany(a => a.UpvotedBooks).WithMany(b => b.Upvotes).Map(
                ca =>
                    {
                        ca.MapLeftKey("UserId");
                        ca.MapRightKey("BookId");
                        ca.ToTable("UpvoteUserBooks");
                    });

            this.HasMany(a => a.DownotedBooks).WithMany(b => b.Downvotes).Map(
                ca =>
                {
                    ca.MapLeftKey("UserId");
                    ca.MapRightKey("BookId");
                    ca.ToTable("DownvoteUserBooks");
                });
        }
    }
}
