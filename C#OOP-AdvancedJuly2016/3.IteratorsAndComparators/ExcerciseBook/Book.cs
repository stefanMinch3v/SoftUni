using System;

namespace ExcerciseBook
{
    public class Book : IComparable<Book> 
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public int CompareTo(Book other) // first compare by authors then by title or whatever you want condition
        {
            var authorCompare = this.Author.CompareTo(other.Author);
            if (authorCompare != 0)
            {
                return authorCompare;
            }

            return this.Title.CompareTo(other.Title);
        }
    }
}
