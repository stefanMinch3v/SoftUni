namespace LearningSystem.Web.Controllers
{
    using Data.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Services;
    using System.Threading.Tasks;

    [Authorize]
    public class UsersController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly IUserService userService;

        public UsersController(
            UserManager<User> userManager,
            IUserService userService)
        {
            this.userManager = userManager;
            this.userService = userService;
        }

        public async Task<IActionResult> Profile(string username)
        {
            // var userId = this.userManager.GetUserId(User);
            var user = await this.userManager.FindByNameAsync(username);

            if (user == null)
            {
                return NotFound();
            }

            var profile = await this.userService.ProfileAsync(user.Id);

            return View(profile);
        }

        [Authorize]
        public async Task<IActionResult> DownloadCertificate(int id)
        {
            var userId = this.userManager.GetUserId(User);

            var certificateContent = await this.userService.GetPdfCertificate(id, userId);
            if (certificateContent == null)
            {
                return BadRequest();
            }

            return File(certificateContent, "application/pdf", "Certificate.pdf");
        }
    }
}
