namespace Data.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Globalization;
    using System.IO;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.BookShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "Data.BookShopContext";
        }

        protected override void Seed(Data.BookShopContext context)
        {
            SeedAuthors(context);
            SeedBooks(context);
            SeedCategories(context);
        }

        private void SeedCategories(BookShopContext context)
        {
            int booksCount = context.Books.Local.Count;
            string[] categories = File.ReadAllLines(@"../../../Data/Import/categories.csv");

            for (int i = 1; i < categories.Length; i++)
            {
                string[] data = categories[i].Split(',').Select(arg => arg.Replace("\"", string.Empty)).ToArray();
                string categoryName = data[0];
                var category = new Category() { Name = categoryName };

                int bookIndex = (i * 30) % booksCount;
                for (int j = 0; j < bookIndex; j++)
                {
                    Book book = context.Books.Local[j];
                    category.Books.Add(book);    
                }

                context.Categories.AddOrUpdate(c => c.Name, category);


            }
        }

        private void SeedBooks(BookShopContext context)
        {
            int authorsCount = context.Authors.Local.Count;
            string[] books = File.ReadAllLines(@"../../../Data/Import/books.csv");

            for (int i = 1; i < books.Length; i++)
            {
                var data = books[i].Split(',').Select(b => b.Replace("\"", string.Empty)).ToArray();
                int authorIndex = i % authorsCount;
                var author = context.Authors.Local[authorIndex];
                var editionType = (EditionType)int.Parse(data[0]);
                var releaseDate = DateTime.ParseExact(data[1], "d/M/yyyy", CultureInfo.InvariantCulture);
                int copies = int.Parse(data[2]);
                decimal price = decimal.Parse(data[3]);
                var ageRestriction = (AgeRestriction)int.Parse(data[4]);
                string title = data[5];

                var book = new Book()
                {
                    Author = author,
                    AuthorId = author.AuthorId,
                    EditionType = editionType,
                    ReleaseDate = releaseDate,
                    Copies = copies,
                    Price = price,
                    AgeRestriction = ageRestriction,
                    Title = title
                };

                context.Books.AddOrUpdate(b => new { b.Title, b.AuthorId }, book);
            }
        }

        private void SeedAuthors(BookShopContext context)
        {
            string[] authors = File.ReadAllLines(@"../../../Data/Import/authors.csv");

            for (int i = 1; i < authors.Length; i++)
            {
                var data = authors[i].Split(new char[] { ',' });
                var firstName = data[0].Replace("\"", string.Empty);
                var lastName = data[1].Replace("\"", string.Empty);

                var author = new Author()
                {
                    FirstName = firstName,
                    LastName = lastName
                };

                context.Authors.AddOrUpdate(a => new { a.FirstName, a.LastName }, author);//check if already exists author with the same first and last name
            }
        }
    }
}
