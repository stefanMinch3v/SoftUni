namespace LearningSystem.Services
{
    using Models.Courses;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICourseService
    {
        Task<IEnumerable<CourseListingServiceModel>> AllAsync();

        Task<IEnumerable<CourseListingServiceModel>> ActiveAsync();

        Task<IEnumerable<CourseListingServiceModel>> FindAsync(string searchText);


        // use this method with a few service models, instantiate the specific in the controller
        Task<TModel> ByIdAsync<TModel>(int id) where TModel : class;

        Task<bool> SignUpUserAsync(string userId, int courseId);

        Task<bool> SignOutUserAsync(string userId, int courseId);

        Task<bool> UserIsEnrolledInCourseAsync(int courseId, string userId);

        Task<bool> SaveExamSubmission(int courseId, string studentId, byte[] examSubmission);
    }
}
