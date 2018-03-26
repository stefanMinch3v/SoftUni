namespace BookShop.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Common.Еxtensions;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Models.Book;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class BookService : IBookService
    {
        private readonly BookShopDbContext db;

        public BookService(BookShopDbContext db)
        {
            this.db = db;
        }

        public async Task<BookDetailsServiceModel> Details(int id)
            => await this.db.Books
                .Where(b => b.Id == id)
                .ProjectTo<BookDetailsServiceModel>()
                .FirstOrDefaultAsync();

        public async Task<IEnumerable<BookListingServiceModel>> TopTen(string title)
            => await this.db.Books
                .Where(b => b.Title.ToLower().Contains(title.ToLower()))
                .OrderBy(b => b.Title)
                .Take(10)
                .ProjectTo<BookListingServiceModel>()
                .ToListAsync();

        public async Task<int> Create(
            string title, 
            string description,
            decimal price, 
            int copies, 
            int? edition, 
            int? ageRestriction,
            DateTime releaseDate,
            int authorId, 
            string categories)
        {
            var categoryNames = categories
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToHashSet();

            var categoriesInDb = await this.db.Categories
                .Where(c => categoryNames.Contains(c.Name))
                .ToListAsync();

            var allCategories = new List<Category>(categoriesInDb);

            foreach (var catName in categoryNames)
            {
                if (categoriesInDb.All(c => c.Name != catName))
                {
                    var category = new Category
                    {
                        Name = catName
                    };

                    allCategories.Add(category);

                    this.db.Categories.Add(category);
                }
            }

            await this.db.SaveChangesAsync();

            var book = new Book
            {
                Title = title,
                Description = description,
                Price = price,
                Copies = copies,
                Edition = edition,
                AgeRestriction = ageRestriction,
                ReleaseDate = releaseDate,
                AuthorId = authorId
            };

            // automatically adds the book id to categorybook table
            allCategories.ForEach(c => book.Categories.Add(new CategoryBook
            {
                CategoryId = c.Id
            }));

            this.db.Books.Add(book);

            await this.db.SaveChangesAsync();

            return book.Id;
        }

        public async Task<bool> Exists(int id)
            => await this.db.Books.AnyAsync(b => b.Id == id);

        public async Task Delete(int id)
        {
            var book = await this.db.Books.FindAsync(id);

            if (book == null)
            {
                return;
            }

            this.db.Books.Remove(book);
            await this.db.SaveChangesAsync();
        }

        public async Task Edit(
            int id,
            string title,
            string description,
            decimal price,
            int copies,
            int? edition, 
            int? ageRestriction,
            DateTime releaseDate,
            int authorId)
        {
            if (!await this.db.Authors.AnyAsync(a => a.Id == authorId))
            {
                return;
            }

            var book = await this.db.Books.FindAsync(id);
            if (book == null)
            {
                return;
            }

            book.Title = title;
            book.Description = description;
            book.Price = price;
            book.Copies = copies;
            book.Edition = edition;
            book.AgeRestriction = ageRestriction;
            book.ReleaseDate = releaseDate;
            book.AuthorId = authorId;

            this.db.Books.Update(book);
            await this.db.SaveChangesAsync();
        }
    }
}
