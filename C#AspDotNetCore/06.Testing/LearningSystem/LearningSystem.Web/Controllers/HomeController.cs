namespace LearningSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Models.Home;
    using Services;
    using System.Diagnostics;
    using System.Threading.Tasks;

    public class HomeController : Controller
    {
        private readonly ICourseService courseService;
        private readonly IUserService userService;

        public HomeController(
            ICourseService courseService,
            IUserService userService)
        {
            this.courseService = courseService;
            this.userService = userService;
        }

        public async Task<IActionResult> Index()
            => View(new HomeIndexViewModel
            {
                Courses = await this.courseService.AllAsync()
            });

        public async Task<IActionResult> Search(SearchFormModel model)
        {
            var searchText = model.SearchText;

            var viewModel = new SearchViewModel
            {
                SearchText = searchText
            };

            if (model.SearchInCourses)
            {
                viewModel.Courses = await this.courseService.FindAsync(searchText);
            }

            if (model.SearchInUsers)
            {
                viewModel.Users = await this.userService.FindAsync(searchText);
            }

            return View(viewModel);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
