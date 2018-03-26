namespace BookShop.Services
{
    using Models.Book;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System;

    public interface IBookService
    {
        Task<BookDetailsServiceModel> Details(int id);

        Task<IEnumerable<BookListingServiceModel>> TopTen(string title);

        Task<int> Create(
            string title, 
            string description,
            decimal price, 
            int copies, 
            int? edition, 
            int? ageRestriction,
            DateTime releaseDate,
            int authorId, 
            string categories);

        Task<bool> Exists(int id);

        Task Delete(int id);

        Task Edit(
            int id,
            string title,
            string description, 
            decimal price, 
            int copies, 
            int? edition, 
            int? ageRestriction, 
            DateTime releaseDate,
            int authorId);
    }
}
