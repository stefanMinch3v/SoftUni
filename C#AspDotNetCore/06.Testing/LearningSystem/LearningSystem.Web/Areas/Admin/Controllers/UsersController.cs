namespace LearningSystem.Web.Areas.Admin.Controllers
{
    using Data.Models;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using Models.Users;
    using Services.Admin;
    using System.Linq;
    using System.Threading.Tasks;

    public class UsersController : BaseAdminController
    {
        private readonly IAdminUserService usersService;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<User> userManager;

        public UsersController(
            IAdminUserService usersService,
            RoleManager<IdentityRole> roleManager,
            UserManager<User> userManager)
        {
            this.usersService = usersService;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = await this.usersService.AllAsync();
            var roles = await this.roleManager.Roles
                .Select(r => new SelectListItem
                {
                    Text = r.Name,
                    Value = r.Name
                })
                .ToListAsync();

            return View(new UserListingsViewModel
            {
                Users = users,
                Roles = roles
            });
        }

        [HttpPost]
        public async Task<IActionResult> AddToRole(AddUserToRoleFormViewModel model)
        {
            var roleExists = await this.roleManager.RoleExistsAsync(model.Role);
            var selectedUser = await this.userManager.FindByIdAsync(model.UserId);
            var userExists = selectedUser != null;

            if (!roleExists || !userExists)
            {
                ModelState.AddModelError(string.Empty, "Invalid identity details.");
            }

            if (!ModelState.IsValid)
            {
                this.TempData.AddErrorMessage("Either user or role is not valid.");
                return RedirectToAction(nameof(Index));
            }

            // might create another check if the result below is succeeded => optional
            await this.userManager.AddToRoleAsync(selectedUser, model.Role);

            this.TempData.AddSuccessMessage($"User {selectedUser.UserName} successfully added to {model.Role} role.");
            return RedirectToAction(nameof(Index));
        }
    }
}
