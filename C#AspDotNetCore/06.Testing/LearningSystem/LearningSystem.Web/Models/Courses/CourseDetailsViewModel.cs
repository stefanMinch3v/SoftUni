namespace LearningSystem.Web.Models.Courses
{
    using Services.Models.Courses;

    public class CourseDetailsViewModel 
    {
        public CourseDetailsServiceModel Course { get; set; }

        public bool UserIsEnrolledInCourse { get; set; }
    }
}
