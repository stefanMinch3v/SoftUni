using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BookLibraryModification
{
    public static void Main(string[] args)
    {
        int input = int.Parse(Console.ReadLine());

        Library library = new Library();

        for (int i = 0; i < input; i++)
        {
            string[] command = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string title = command[0];
            string author = command[1];
            string publisher = command[2];
            string parseDate = command[3];

            DateTime releaseDate = DateTime.ParseExact(parseDate, "dd.MM.yyyy", CultureInfo.InvariantCulture);

            string isbn = command[4];
            double price = double.Parse(command[5]);

            Book book = null;

            
            book = new Book(title, author, publisher, releaseDate, isbn, price);
            library.Books.Add(book);
            
        }

        string inputDate = Console.ReadLine();
        DateTime date = DateTime.ParseExact(inputDate, "dd.MM.yyyy", CultureInfo.InvariantCulture);

        foreach (var item in library.Books
                                        .OrderBy(p => p.ReleaseDate)
                                        .ThenBy(a => a.Title))
        {
            var titles = item.Title;
            //DateTime dateOfRelease = DateTime.ParseExact(item.ReleaseDate, "dd.MM.yyyy", CultureInfo.InvariantCulture);

            if (date < item.ReleaseDate)
            {
                Console.WriteLine($"{titles} -> {item.ReleaseDate.Day}.{item.ReleaseDate.Month:00}.{item.ReleaseDate.Year}");
            }

            
            //var sumAllPrices = library.Books.Where(a => a.Author.Equals(item.Author)).Select(p => p.Price).Sum();
            // var authors = library.Books.Where(a => a.Author.Equals(a.Author)).Distinct().ToList();
            //Console.WriteLine($"{authors} -> {sumAllPrices:f2}");
        }

    }
}
public class Library
{
    public string Name { get; set; }
    public List<Book> Books { get; set; }

    public Library()
    {
        Books = new List<Book>();
    }
}

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Publisher { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string ISBN { get; set; }
    public double Price { get; set; }

    public Book(string title, string author, string publisher, DateTime releaseDate, string isbn, double price)
    {
        this.Title = title;
        this.Author = author;
        this.Publisher = publisher;
        this.ReleaseDate = releaseDate;
        this.ISBN = isbn;
        this.Price = price;
    }
}

