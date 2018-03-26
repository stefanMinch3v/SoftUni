namespace LearningSystem.Services
{
    using Services.Models.Users;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUserService
    {
        Task<UserProfileServiceModel> ProfileAsync(string id);

        Task<IEnumerable<UserListingServiceModel>> FindAsync(string searchText);

        Task<byte[]> GetPdfCertificate(int courseId, string studentId);
    }
}
