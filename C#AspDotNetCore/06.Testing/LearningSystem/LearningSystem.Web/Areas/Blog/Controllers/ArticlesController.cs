namespace LearningSystem.Web.Areas.Blog.Controllers
{
    using Data.Models;
    using Infrastructure.Extensions;
    using Infrastructure.Filters;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Models.Articles;
    using Services.Blog;
    using Services.Html;
    using System.Threading.Tasks;

    using static WebConstants;

    [Area(BlogArea)]
    [Authorize]
    public class ArticlesController : Controller
    {
        private readonly IBlogService blogService;
        private readonly UserManager<User> userManager;
        private readonly IHtmlService htmlService;

        public ArticlesController(
            IBlogService blogService,
            UserManager<User> userManager,
            IHtmlService htmlService)
        {
            this.blogService = blogService;
            this.userManager = userManager;
            this.htmlService = htmlService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(int page = 1)
            => View(new ArticleListingViewModel
            {
                Articles = await this.blogService.AllAsync(page),
                TotalArticles = await this.blogService.TotalAsync(),
                CurrentPage = page
            });

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
            => this.ViewOrNotFound(await this.blogService.ByIdAsync(id));

        [AllowAnonymous]
        public async Task<IActionResult> Search(string searchText)
        {
            var articles = await this.blogService.FindAsync(searchText);

            TempData.Add(TempDataSearchMessageKey, searchText);

            return View(articles);
        }

        [Authorize(Roles = BlogAuthorRole)]
        public IActionResult Create() => View();

        [HttpPost]
        [Authorize(Roles = BlogAuthorRole)]
        [ValidateModelState]
        public async Task<IActionResult> Create(PublishArticleFormViewModel model)
        {
            var userId = this.userManager.GetUserId(this.User);

            if (userId == null)
            {
                ModelState.AddModelError(string.Empty, "The author doesn't exist.");
            }

            model.Content = this.htmlService.Sanitize(model.Content);

            await this.blogService.CreateAsync(model.Title, model.Content, userId);

            TempData.AddSuccessMessage($"Article {model.Title} was successfully published.");

            return RedirectToAction(nameof(Index));
        }
    }
}
