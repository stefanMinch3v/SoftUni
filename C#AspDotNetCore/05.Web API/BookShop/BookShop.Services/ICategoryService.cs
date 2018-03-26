namespace BookShop.Services
{
    using Models.Category;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICategoryService
    {
        Task<int> Create(string name);

        Task Edit(int id, string name);

        Task<IEnumerable<CategoryListingServiceModel>> All();

        Task<CategoryListingServiceModel> Details(int id);

        Task Delete(int id);

        Task<bool> Exists(int id);

        Task<bool> Exists(string name);
    }
}
