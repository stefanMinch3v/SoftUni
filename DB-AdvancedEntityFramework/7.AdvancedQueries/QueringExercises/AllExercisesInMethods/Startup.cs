
namespace AllExercisesInMethods
{
    using Data;
    using System;
    using System.Linq;
    using System.Data.Entity;
    using System.Globalization;
    using EntityFramework.Extensions;
    using System.Data.SqlClient;

    public class Startup
    {
        public static void Main()
        {
            var context = new BookContext();
            //1
            //BookTitlesByAgeRestriction(context);

            //2
            //GoldenBooks(context);

            //3
            //BooksByPrice(context);

            //4
            //NotReleasedBooks(context);

            //5
            //BookTitlesByCategory(context);

            //6
            //BooksReleasedBeforeDate(context);

            //7
            //AuthorsSearch(context);

            //8
            //BooksSearch(context);

            //9
            //BookTitlesSearch(context);

            //10
            //CountBooks(context);

            //11
            //TotalBookCopies(context);

            //12
            //FindProfit(context);

            //13
            //MostRecentBooks(context);

            //14
            //IncreaseBookCopies(context);

            //15
            //RemoveBooks(context);

            //16
            //StoredProcedure(context);


            //17
            //Softuni DB in the next project
            //18

            //19
            //Gringotts DB in the next project
            //20
        }

        private static void StoredProcedure(BookContext context)
        {
            string[] authorInfo = Console.ReadLine().Split();
            string firstName = authorInfo[0];
            string lastName = authorInfo[1];

            int result = context.Database.SqlQuery<int>("EXEC dbo.usp_AuthorBooks {0}, {1}", firstName, lastName).First();
            Console.WriteLine($"{firstName} {lastName} has written {result} books");
        }

        private static void RemoveBooks(BookContext context)
        {
            int result = context.Books.Where(b => b.Copies < 4200).Count();
            context.Books.Where(b => b.Copies < 4200).Delete();
            context.SaveChanges();

            Console.WriteLine($"{result} books were deleted");
        }

        private static void IncreaseBookCopies(BookContext context)
        {
            DateTime date = DateTime.Parse("2013-06-06");
            var books = context.Books.Where(b => b.ReleaseDate > date);
            int countCopiesAdded = 0;
            foreach (var book in books)
            {
                book.Copies += 44;
                countCopiesAdded += 44;
            }

            //context.SaveChanges();

            Console.WriteLine($"{books.Count()} books are released after 6 Jun 2013 so total of {countCopiesAdded} book copies were added ");
        }

        private static void MostRecentBooks(BookContext context)
        {
            var result = context.Categories
                                        .OrderByDescending(c => c.Books.Count)
                                        .Where(c => c.Books.Count > 35)
                                        .ToArray();
            foreach (var cat in result)
            {
                Console.WriteLine($"--{cat.Name}: {cat.Books.Count} books");
                var recentBooks = cat.Books
                                        .OrderByDescending(b => b.ReleaseDate)
                                        .ThenBy(b => b.Title)
                                        .Take(3);
                foreach (var book in recentBooks)
                {
                    Console.WriteLine($"{book.Title} ({book.ReleaseDate.Value.Year})");
                }
            }
        }

        private static void FindProfit(BookContext context)
        {
            var result = context.Categories.OrderByDescending(c => c.Books.Sum(b => b.Copies * b.Price)).ToArray();
            foreach (var cate in result)
            {
                Console.WriteLine($"{cate.Name} ${cate.Books.Sum(b => b.Copies * b.Price)}");
            }
        }

        private static void TotalBookCopies(BookContext context)
        {
            var result = context.Authors.OrderByDescending(b => b.Books.Sum(c => c.Copies)).ToArray();
            foreach (var author in result)
            {
                Console.WriteLine($"{author.FirstName} {author.LastName} - {author.Books.Sum(b => b.Copies)}");
            }
        }

        private static void CountBooks(BookContext context)
        {
            int symbolsLength = int.Parse(Console.ReadLine());
            var result = context.Books.Where(b => b.Title.Length > symbolsLength).Count();
            Console.WriteLine(result);
        }

        private static void BookTitlesSearch(BookContext context)
        {
            string input = Console.ReadLine();
            var result = context.Books.Where(b => b.Author.LastName.StartsWith(input)).ToArray();
            foreach (var book in result)
            {
                Console.WriteLine($"{book.Title} ({book.Author.FirstName} {book.Author.LastName})");
            }
        }

        private static void BooksSearch(BookContext context)
        {
            string input = Console.ReadLine();
            var result = context.Books.Where(b => b.Title.Contains(input)).Select(b => b.Title).ToArray();
            Console.WriteLine(string.Join(Environment.NewLine, result));
        }

        private static void AuthorsSearch(BookContext context)
        {
            string input = Console.ReadLine();
            var result = context.Authors.Where(a => a.FirstName.EndsWith(input));
            foreach (var author in result)
            {
                Console.WriteLine($"{author.FirstName} {author.LastName}");
            }
        }

        private static void BooksReleasedBeforeDate(BookContext context)
        {
            string input = Console.ReadLine();
            DateTime date = DateTime.ParseExact(input, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            var result = context.Books.Where(b => b.ReleaseDate < date).ToArray();
            foreach (var book in result)
            {
                Console.WriteLine($"{book.Title} - {book.EditionType == 1} - {book.Price}");
            }
        }

        private static void BookTitlesByCategory(BookContext context)
        {
            string[] inputCategoryToSearch = Console.ReadLine().ToLower().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            var categories = context.Categories.Select(c => c.Name.ToLower()).ToArray();
            if (!categories.Any(c => inputCategoryToSearch.Contains(c)))
            {
                Console.WriteLine("No such category!");
                return;
            }

            var resultBooks = context.Books
                                        .Where(b => b.Categories.Any(c => inputCategoryToSearch.Contains(c.Name)))
                                        .OrderBy(b => b.BookId)
                                        .Select(b => b.Title)
                                        .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, resultBooks));
        }

        private static void NotReleasedBooks(BookContext context)
        {
            Console.Write("Input year of release: ");
            int inputDate = int.Parse(Console.ReadLine());

            var books = context.Books
                                    .Where(b => b.ReleaseDate.Value.Year != inputDate)
                                    .OrderBy(b => b.BookId)
                                    .Select(b => b.Title)
                                    .ToArray();
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }

        private static void BooksByPrice(BookContext context)
        {
            var books = context.Books
                                            .Where(b => b.Price < 5 || b.Price > 40)
                                            .OrderBy(b => b.BookId)
                                            .ToArray();

            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title} - ${book.Price}");
            }
        }

        private static void GoldenBooks(BookContext context)
        {
            var goldenBooks = context.Books
                                            .Where(b => b.EditionType == 2 && b.Copies < 5000)
                                            .OrderBy(b => b.BookId)
                                            .Select(b => b.Title)
                                            .ToArray();
            foreach (var book in goldenBooks)
            {
                Console.WriteLine(book);
            }
        }

        private static void BookTitlesByAgeRestriction(BookContext context)
        {
            Console.Write("Write down tha age restricton: ");
            string input = Console.ReadLine().ToLower();
            switch (input)
            {
                case "minor":
                    var resultMinor = context.Books.Where(b => b.AgeRestriction == 0).Select(b => b.Title).ToArray();
                    foreach (var book in resultMinor)
                    {
                        Console.WriteLine(book);
                    }

                    break;
                case "teen":
                    var resultTeen = context.Books.Where(b => b.AgeRestriction == 1).Select(b => b.Title).ToArray();
                    foreach (var book in resultTeen)
                    {
                        Console.WriteLine(book);
                    }

                    break;
                case "adult":
                    var resultAdult = context.Books.Where(b => b.AgeRestriction == 2).Select(b => b.Title).ToArray();
                    foreach (var book in resultAdult)
                    {
                        Console.WriteLine(book);
                    }

                    break;
                default:
                    Console.WriteLine("No such age restriction!");
                    break;
            }
        }
    }
}
