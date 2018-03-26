namespace LearningSystem.Services.Blog
{
    using Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IBlogService
    {
        Task CreateAsync(string title, string content, string authorId);

        Task<int> TotalAsync();

        Task<BlogDetailsServiceModel> ByIdAsync(int id);

        Task<IEnumerable<BlogListingServiceModel>> AllAsync(int page = 1);

        Task<IEnumerable<BlogListingServiceModel>> FindAsync(string searchText);
    }
}
