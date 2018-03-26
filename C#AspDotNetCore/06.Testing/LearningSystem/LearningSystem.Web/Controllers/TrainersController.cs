namespace LearningSystem.Web.Controllers
{
    using Data.Models;
    using Data.Models.Enums;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Models.Trainers;
    using Services;
    using Services.Models.Courses;
    using System;
    using System.Threading.Tasks;

    [Authorize(Roles = WebConstants.TrainerRole)]
    public class TrainersController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly ITrainerService trainerService;
        private readonly ICourseService courseService;

        public TrainersController(
            UserManager<User> userManager,
            ITrainerService trainerService,
            ICourseService courseService)
        {
            this.userManager = userManager;
            this.trainerService = trainerService;
            this.courseService = courseService;
        }

        public async Task<IActionResult> Courses()
        {
            var trainerId = this.userManager.GetUserId(User);

            var courses = await this.trainerService.CoursesAsync(trainerId);

            return View(courses);
        }

        public async Task<IActionResult> Students(int id)
        {
            var userId = this.userManager.GetUserId(User);
            if (!await this.trainerService.IsTrainerAsync(id, userId))
            {
                return BadRequest();
            }

            var students = await this.trainerService.StudentsInCourseAsync(id);

            return View(new StudentsInCourseViewModel
            {
                Students = students,
                Course = await this.courseService.ByIdAsync<CourseListingServiceModel>(id)
            });
        }

        [HttpPost]
        public async Task<IActionResult> GradeStudent(int id, string studentId, Grade grade)
        {
            if (string.IsNullOrEmpty(studentId))
            {
                return BadRequest();
            }

            var userId = this.userManager.GetUserId(User);
            if (!await this.trainerService.IsTrainerAsync(id, userId))
            {
                return BadRequest();
            }

            var success = await this.trainerService.AddGradeAsync(id, studentId, grade);
            if (!success)
            {
                return BadRequest();
            }

            TempData.AddSuccessMessage("Successfully graded.");

            return RedirectToAction(nameof(Students), new { id = id });
        }

        public async Task<IActionResult> DownloadExam(int id, string studentId)
        {
            if (string.IsNullOrEmpty(studentId))
            {
                return BadRequest();
            }

            var userId = this.userManager.GetUserId(User);
            if (!await this.trainerService.IsTrainerAsync(id, userId))
            {
                return BadRequest();
            }

            var examContent = await this.trainerService.GetExamSubmissionAsync(id, studentId);
            if (examContent == null)
            {
                TempData.AddErrorMessage("The student hasn't uploaded his exam yet.");
                return RedirectToAction(nameof(Students), new { id = id });
                // or
                //return BadRequest();
            }

            var studentInCourseNames = await this.trainerService.StudentInCourseNamesAsync(id, studentId);

            if (studentInCourseNames == null)
            {
                return BadRequest();
            }

            return File(
                examContent, 
                "application/zip", 
                $"{studentInCourseNames.CourseName}-{studentInCourseNames.Username}-{DateTime.UtcNow.ToString("MM-DD-yyyy")}.zip");
        }
    }
}
