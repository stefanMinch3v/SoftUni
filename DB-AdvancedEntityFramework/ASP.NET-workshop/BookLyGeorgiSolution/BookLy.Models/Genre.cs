namespace BookLy.Models
{
    using System.Collections.Generic;

    public class Genre
    {
        public Genre()
        {
            this.Books = new List<Book>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}