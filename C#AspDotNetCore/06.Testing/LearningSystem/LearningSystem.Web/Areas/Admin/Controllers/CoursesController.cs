namespace LearningSystem.Web.Areas.Admin.Controllers
{
    using Data.Models;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Models.Courses;
    using Services.Admin;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Web.Controllers;

    public class CoursesController : BaseAdminController
    {
        private readonly UserManager<User> userManager;
        private readonly IAdminCourseService courseService;

        public CoursesController(
            UserManager<User> userManager,
            IAdminCourseService courseService)
        {
            this.userManager = userManager;
            this.courseService = courseService;
        }

        public async Task<IActionResult> Create()
            => View(new AddCourseFormViewModel
            {
                Trainers = await GetTrainers(),
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(20)
            });

        [HttpPost]
        public async Task<IActionResult> Create(AddCourseFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Trainers = await GetTrainers();
                return View(model);
            }

            var selectedTrainer = await this.userManager.FindByIdAsync(model.TrainerId);
            var existingTrainer = selectedTrainer != null;

            if (!existingTrainer)
            {
                ModelState.AddModelError(string.Empty, "Invalid trainer");
            }

            await this.courseService.CreateAsync(
                model.Name,
                model.Description,
                model.StartDate,
                model.EndDate.AddDays(1), // equals to-new DateTime(endDate.Year, endDate.Month, endDate.Day, 23, 59, 59)
                model.TrainerId);

            TempData.AddSuccessMessage($"Course {model.Name} was successfully created.");

            return RedirectToAction(
                nameof(HomeController.Index),
                "Home",
                new { area = string.Empty });
        }

        private async Task<IEnumerable<SelectListItem>> GetTrainers()
        {
            var trainers = await this.userManager
                    .GetUsersInRoleAsync(WebConstants.TrainerRole);

            var trainerListItems = trainers
                .Select(t => new SelectListItem
                {
                    Text = t.UserName,
                    Value = t.Id
                })
                .ToList();

            return trainerListItems;
        }
    }
}
