namespace BookShop.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Models.Author;
    using Models.Book;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class AuthorService : IAuthorService
    {
        private readonly BookShopDbContext db;

        public AuthorService(BookShopDbContext db)
        {
            this.db = db;
        }

        public async Task<int> Create(string firstName, string lastName)
        {
            var author = new Author
            {
                FirstName = firstName,
                LastName = lastName
            };

            this.db.Authors.Add(author);
            await this.db.SaveChangesAsync();

            return author.Id;
        }

        public async Task<AuthorDetailsServiceModel> Details(int id)
            => await this.db.Authors
                .Where(a => a.Id == id)
                .ProjectTo<AuthorDetailsServiceModel>()
                .FirstOrDefaultAsync();

        // or this way below AuthorBooks
        //await this.db.Books
        //    .Where(a => a.AuthorId == authorId)
        //    .ProjectTo<BookByAuthorServiceModel>()
        //    .ToListAsync();
        public async Task<IEnumerable<BookWithCategoriesServiceModel>> AuthorBooks(int authorId)
            => await this.db.Authors
                .Where(a => a.Id == authorId)
                .SelectMany(a => a.Books)
                .ProjectTo<BookWithCategoriesServiceModel>()
                .ToListAsync();

        public async Task<bool> Exists(int id)
            => await this.db.Authors.AnyAsync(a => a.Id == id);
    }
}
