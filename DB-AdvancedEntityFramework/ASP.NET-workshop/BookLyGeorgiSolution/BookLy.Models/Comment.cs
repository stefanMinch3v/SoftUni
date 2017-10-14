namespace BookLy.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public int BookId { get; set; }

        public virtual Book Book { get; set; }

        public string Content { get; set; }
    }
}