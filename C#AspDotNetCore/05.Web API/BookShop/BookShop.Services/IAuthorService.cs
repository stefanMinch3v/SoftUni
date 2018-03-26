namespace BookShop.Services
{
    using Models.Author;
    using Models.Book;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAuthorService
    {
        Task<AuthorDetailsServiceModel> Details(int id);

        Task<int> Create(string firstName, string lastName);

        Task<IEnumerable<BookWithCategoriesServiceModel>> AuthorBooks(int authorId);

        Task<bool> Exists(int id);
    }
}
