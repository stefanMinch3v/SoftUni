namespace LearningSystem.Web.Models.Home
{
    using Services.Models.Courses;
    using Services.Models.Users;
    using System.Collections.Generic;

    public class SearchViewModel
    {
        // by default empty
        public IEnumerable<CourseListingServiceModel> Courses { get; set; } = new List<CourseListingServiceModel>();

        public IEnumerable<UserListingServiceModel> Users { get; set; } = new List<UserListingServiceModel>();

        public string SearchText { get; set; }
    }
}
