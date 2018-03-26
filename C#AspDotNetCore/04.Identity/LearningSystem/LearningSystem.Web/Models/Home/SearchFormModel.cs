namespace LearningSystem.Web.Models.Home
{
    using System.ComponentModel.DataAnnotations;

    public class SearchFormModel
    {
        // if its not binds by itself could use [FromQuerry] attribute
        public string SearchText { get; set; }

        [Display(Name = "Search in Users")]
        public bool SearchInUsers { get; set; } = true; // by default true

        [Display(Name = "Search in Courses")]
        public bool SearchInCourses { get; set; } = true;
    }
}
