namespace CameraBazaar.Web.Controllers
{
    using Data.Models;
    using Infrastructure;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Models.Users;
    using Services;
    using System.Linq;
    using System.Threading.Tasks;

    [Route("Users")]
    public class UsersController : Controller
    {
        private readonly IUserService users;
        private readonly ICameraService cameras;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UsersController(
            IUserService users,
            ICameraService cameras,
            UserManager<User> userManager,
            SignInManager<User> signManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.users = users;
            this.cameras = cameras;
            this.userManager = userManager;
            this.signManager = signManager;
            this.roleManager = roleManager;
        }

        [Authorize(Roles = GlobalConstants.AdministratorRole)]
        [Route(nameof(All))]
        public IActionResult All()
        {
            var userModel = this.users.All();

            return View(userModel);
        }

        [Route(nameof(Details) + "/" + "{username}")]
        public async Task<IActionResult> Details(string username)
        {
            var user = await this.userManager.GetUserAsync(this.User); // this method invoke only user table without any cameras which are connected to it

            if (user == null)
            {
                return this.NotFound();
            }

            var userModel = this.users.ByUsername(username);

            if (username == this.User.Identity.Name)
            {
                userModel.IsOwner = true;
            }

            return View(userModel);
        }

        [Authorize]
        [Route(nameof(Edit))]
        public async Task<IActionResult> Edit()
        {
            var user = await this.userManager.GetUserAsync(this.User);

            if (user == null)
            {
                return NotFound("No such user.");
            }

            return View(new EditUserViewModel
            {
                Username = user.UserName,
                Email = user.Email,
                Phone = user.PhoneNumber,
                LastLoginTime = user.LastLoginTime
            });
        }

        [Authorize]
        [HttpPost]
        [Route(nameof(Edit))]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            //var currentUserId = this.userManager.GetUserId(this.User);

            //var userDb = await this.userManager.GetUserAsync(this.User);
            //var userId = userDb.Id;

            //if (currentUserId != userId)
            //{
            //    return NotFound();
            //}

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await this.userManager.GetUserAsync(this.User);

            if (user == null)
            {
                return NotFound("User does not exist.");
            }

            var validCurrentPassword = await this.signManager.CheckPasswordSignInAsync(user, model.OldPassword, false);

            if (!validCurrentPassword.Succeeded)
            {
                TempData["ErrorPassword"] = "The current password is not correct.";
                return View(model);
            }

            // using the integrated microsoft implementation

            // mail
            if (model.Email != user.Email)
            {
                var emailToken = await this.userManager.GenerateChangeEmailTokenAsync(user, model.Email);
                var updateEmail = await this.userManager.ChangeEmailAsync(user, model.Email, emailToken);

                if (!updateEmail.Succeeded)
                {
                    TempData["SuccessMessage"] = "Unexpected error with your email.";
                }

                TempData["SuccessMessage"] = "Your information has been successfuly updated.";
            }

            // phone
            if (model.Phone != user.PhoneNumber)
            {
                var phoneToken = await this.userManager.GenerateChangePhoneNumberTokenAsync(user, model.Phone);
                var updatePhone = await this.userManager.ChangePhoneNumberAsync(user, model.Phone, phoneToken);

                if (!updatePhone.Succeeded)
                {
                    TempData["SuccessMessage"] = "Unexpected error with your phone.";
                }

                TempData["SuccessMessage"] = "Your information has been successfuly updated.";
            }

            // password 
            if (!string.IsNullOrEmpty(model.NewPassword))
            {
                var updatePassword = await this.userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);

                if (!updatePassword.Succeeded)
                {
                    TempData["SuccessMessage"] = "Unexpected error with your password.";
                }

                TempData["SuccessMessage"] = "Your information has been successfuly updated.";
            }

            // using mine implementation of the user service
            //if (model.Email != user.Email
            //    || model.Phone != user.PhoneNumber
            //    || !string.IsNullOrEmpty(model.NewPassword))
            //{
            //    this.users.Update(user.Id, model.Email, model.Phone, model.NewPassword);
            //    TempData["SuccessMessage"] = "Your information has been successfuly updated.";
            //}

            return RedirectToAction(nameof(Details), new { username = user.UserName });
        }

        [Route(nameof(Restrict) + "/" + "{username}")]
        [Authorize(Roles = GlobalConstants.AdministratorRole)]
        public IActionResult Restrict(string username)
        {
            var existing = this.users.Existing(username);

            if (!existing)
            {
                 return NotFound();
            }

            return View(nameof(Restrict), username);
        }

    [Route(nameof(ConfirmRestrict) + "/" + "{username}")]
        [Authorize(Roles = GlobalConstants.AdministratorRole)]
        public async Task<IActionResult> ConfirmRestrict(string username)
        {
            bool isUserAdmin = await CheckForAdmin(username);

            if (isUserAdmin)
            {
                this.TempData["ErrorMessage"] = "Administrators cannot be restricted.";

                return RedirectToAction(nameof(All));
            }

            var user = await this.userManager.FindByNameAsync(username);

            await this.userManager.RemoveFromRoleAsync(user, GlobalConstants.RegisteredRole);

            await this.userManager.AddToRoleAsync(user, GlobalConstants.RestrictedRole);

            await this.userManager.UpdateSecurityStampAsync(user); // in order to immediately sign out the user

            return RedirectToAction(nameof(All));
        }

        [Route(nameof(Unrestrict) + "/" + "{username}")]
        [Authorize(Roles = GlobalConstants.AdministratorRole)]
        public async Task<IActionResult> Unrestrict(string username)
        {
            bool isUserAdmin = await CheckForAdmin(username);

            if (isUserAdmin)
            {
                this.TempData["ErrorMessage"] = "Administrators cannot be changed.";

                return RedirectToAction(nameof(All));
            }

            var user = await this.userManager.FindByNameAsync(username);

            await this.userManager.RemoveFromRoleAsync(user, GlobalConstants.RestrictedRole);

            await this.userManager.AddToRoleAsync(user, GlobalConstants.RegisteredRole);

            return RedirectToAction(nameof(All));
        }

        private async Task<bool> CheckForAdmin(string username)
        {
            var adminUsers = await this.userManager.GetUsersInRoleAsync(GlobalConstants.AdministratorRole);

            var isUserAdmin = adminUsers.Any(u => u.UserName == username);
            return isUserAdmin;
        }
    } 
}
