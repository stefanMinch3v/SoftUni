namespace LearningSystem.Services.Admin
{
    using Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAdminUserService
    {
        IEnumerable<AdminUserListingServiceModel> All();

        Task<IEnumerable<AdminUserListingServiceModel>> AllAsync();
    }
}
