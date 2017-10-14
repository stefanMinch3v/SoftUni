namespace Client
{
    using Data;
    using System.Data.Entity;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var context = new BookShopContext();
            context.Database.Initialize(true);

            var books = context.Books
                                .Take(3)
                                .ToList();
            books[0].RelatedBooks.Add(books[1]);
            books[1].RelatedBooks.Add(books[0]);
            books[0].RelatedBooks.Add(books[2]);
            books[2].RelatedBooks.Add(books[0]);

            context.SaveChanges();

            var desiredBooks = context.Books.Take(3).ToArray();

            foreach (var book in desiredBooks)
            {
                System.Console.WriteLine(book.Title);
                foreach (var realtedBooks in book.RelatedBooks)
                {
                    System.Console.WriteLine(realtedBooks.Title);
                }
            }

        }
    }
}
