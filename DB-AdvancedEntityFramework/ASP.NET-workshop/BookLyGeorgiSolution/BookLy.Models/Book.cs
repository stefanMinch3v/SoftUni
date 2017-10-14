namespace BookLy.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Book
    {
        public Book()
        {
            this.Upvotes = new List<ApplicationUser>();
            this.Downvotes = new List<ApplicationUser>();
            this.Comments = new List<Comment>();
            this.Genres = new List<Genre>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Resume { get; set; }

        public int Pages { get; set; }

        public string ContentSource { get; set; }

        public string AuthorId { get; set; }
         
        [DataType(DataType.ImageUrl)]
        public string Image { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public virtual ICollection<Genre> Genres { get; set; }

        public virtual ICollection<ApplicationUser> Upvotes { get; set; }

        public virtual ICollection<ApplicationUser> Downvotes { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}