namespace BookLy.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Summary { get; set; }

        public int Pages { get; set; }

        public string ContentSource { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public string ImageUrl { get; set; }

    }
}
