namespace LearningSystem.Web.Controllers
{
    using Data;
    using Data.Models;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Models.Courses;
    using Services;
    using Services.Models.Courses;
    using System.Threading.Tasks;

    public class CoursesController : Controller
    {
        private readonly ICourseService courseService;
        private readonly UserManager<User> userManager;

        public CoursesController(
            ICourseService courseService,
            UserManager<User> userManager)
        {
            this.courseService = courseService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = new CourseDetailsViewModel
            {
                Course = await this.courseService.ByIdAsync<CourseDetailsServiceModel>(id)
            };

            if (model.Course == null)
            {
                return NotFound();
            }

            if (User.Identity.IsAuthenticated)
            {
                var userId = this.userManager.GetUserId(User);
                model.UserIsEnrolledInCourse = await this.courseService.UserIsEnrolledInCourseAsync(id, userId);
            }

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SubmitExam(int id, IFormFile exam)
        {
            if (!exam.FileName.EndsWith(".zip")
                || exam.Length > DataConstants.CourseExamSubmissionFileLength)
            {
                TempData.AddErrorMessage("Your file must be '.zip' and no longer than 2mb in total !");
                return RedirectToAction(nameof(Details), new { id });
            }

            var fileContents = await exam.ToByteArrayAsync();
            var userId = this.userManager.GetUserId(User);

            var success = await this.courseService.SaveExamSubmission(id, userId, fileContents);

            if (!success)
            {
                return BadRequest();
            }

            TempData.AddSuccessMessage("Exam submission successfully saved.");
            return RedirectToAction(nameof(Details), new { id });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SignUp(int id)
        {
            var userId = this.userManager.GetUserId(User);

            var success = await this.courseService.SignUpUserAsync(userId, id);

            if (!success)
            {
                return BadRequest();
            }

            TempData.AddSuccessMessage("Thank you for your registration.");

            return RedirectToAction(nameof(Details), new { id });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SignOut(int id)
        {
            var userId = this.userManager.GetUserId(User);

            var success = await this.courseService.SignOutUserAsync(userId, id);

            if (!success)
            {
                return BadRequest();
            }

            TempData.AddSuccessMessage("You have successfully unsigned for this course.");

            return RedirectToAction(nameof(Details), new { id });
        }
    }
}
