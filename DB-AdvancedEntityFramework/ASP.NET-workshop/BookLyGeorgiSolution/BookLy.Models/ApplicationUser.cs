namespace BookLy.Models
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public enum Gender
    {
        Male,
        Female
    }

    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.BookComments = new List<Comment>();
            this.Books = new List<Book>();
            this.UpvotedBooks = new HashSet<Book>();
            this.DownotedBooks = new HashSet<Book>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public Gender Gender { get; set; }

        public byte[] ProfilePicture { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        public virtual ICollection<Book> UpvotedBooks { get; set; }

        public virtual ICollection<Book> DownotedBooks { get; set; }

        public virtual ICollection<Comment> BookComments { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            
            // Add custom user claims here
            return userIdentity;
        }
    }
}