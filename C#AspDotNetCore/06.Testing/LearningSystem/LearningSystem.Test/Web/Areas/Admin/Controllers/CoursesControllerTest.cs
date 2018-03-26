namespace LearningSystem.Test.Web.Areas.Admin.Controllers
{
    using FluentAssertions;
    using LearningSystem.Data.Models;
    using LearningSystem.Services.Admin;
    using LearningSystem.Web;
    using LearningSystem.Web.Areas.Admin.Controllers;
    using LearningSystem.Web.Areas.Admin.Models.Courses;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using Mocks;
    using Moq;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public class CoursesControllerTest
    {
        private const string FirstUserId = "1";
        private const string FirstUserUsername = "User1";
        private const string SecondUserId = "2";
        private const string SecondUserUsername = "User2";

        [Fact]
        public void CoursesControllerShouldBeInAdminArea()
        {
            // Arrange
            var controller = typeof(CoursesController);
                
            // Act
            var areaAttribute = controller
                .GetCustomAttributes(true)
                .FirstOrDefault(attr => attr.GetType() == typeof(AreaAttribute))
                as AreaAttribute;

            // Assert
            areaAttribute
                .Should()
                .NotBeNull();

            areaAttribute.RouteValue
                .Should()
                .Be(WebConstants.AdminArea);
        }

        [Fact]
        public void CoursesControllerShouldBeOnlyForAdmins()
        {
            // Arrange
            var controller = typeof(CoursesController);

            // Act
            var authorizeAttribute = controller
                .GetCustomAttributes(true)
                .FirstOrDefault(attr => attr.GetType() == typeof(AuthorizeAttribute))
                as AuthorizeAttribute;

            // Assert
            authorizeAttribute
                .Should()
                .NotBeNull();

            authorizeAttribute.Roles
                .Should()
                .Match(WebConstants.AdministratorRole);
        }

        [Fact]
        public async Task GetCreateShouldReturnViewWithValidModel()
        {
            // Arrange
            var userManager = this.GetUserManagerMock();
            var controller = new CoursesController(userManager.Object, null);

            // Act
            var result = await controller.Create();

            // Assert
            result
                .Should()
                .BeOfType<ViewResult>();

            var model = result.As<ViewResult>().Model;

            model
                .Should()
                .BeOfType<AddCourseFormViewModel>();

            var formModel = model.As<AddCourseFormViewModel>();

            formModel.StartDate.Year.Should().Be(DateTime.UtcNow.Year);
            formModel.StartDate.Month.Should().Be(DateTime.UtcNow.Month);
            formModel.StartDate.Day.Should().Be(DateTime.UtcNow.Day);

            var endDate = DateTime.UtcNow.AddDays(30);

            formModel.EndDate.Year.Should().Be(endDate.Year);
            formModel.EndDate.Month.Should().Be(endDate.Month);
            //formModel.EndDate.Day.Should().Be(endDate.Day);

            formModel.Trainers
                .Should()
                .Match(items => items.Count() == 2)
                .And
                .Equals(this.GetTrainersTestList());

            // the method over is doing this at once
            //formModel.Trainers.First().Should().Match(u => u.As<SelectListItem>().Value == "FirstUserId");
            //formModel.Trainers.First().Should().Match(u => u.As<SelectListItem>().Text == "FirstUserUsername");
            //formModel.Trainers.First().Should().Match(u => u.As<SelectListItem>().Value == "SecondUserId");
            //formModel.Trainers.Last().Should().Match(u => u.As<SelectListItem>().Text == "SecondUserUsername");
        }

        [Fact]
        public async Task PostCreateShouldReturnViewWithValidModelWhenModelStateIsInvalid()
        {
            // Arrange
            var userManager = this.GetUserManagerMock();
            var controller = new CoursesController(userManager.Object, null);
            controller.ModelState.AddModelError(string.Empty, "Error");

            // Act
            var result = await controller.Create(new AddCourseFormViewModel());

            // Assert
            result
                .Should()
                .BeOfType<ViewResult>();

            var model = result.As<ViewResult>().Model;

            model
                .Should()
                .BeOfType<AddCourseFormViewModel>();

            var formModel = model.As<AddCourseFormViewModel>();

            formModel.Trainers
                .Should()
                .Match(items => items.Count() == 2)
                .And
                .Equals(this.GetTrainersTestList());
        }

        [Fact]
        public async Task PostCreateShouldReturnRedirectWithValidModel()
        {
            // Arrange
            var adminCourseService = new Mock<IAdminCourseService>();

            const string nameValue = "Name";
            const string descriptionValue = "Description";
            var startDateValue = new DateTime(2000, 11, 11);
            var endDateValue = new DateTime(2000, 11, 20);
            const string trainerIdValue = "1";

            string modelName = null;
            string modelDescription = null;
            DateTime modelStartDate = DateTime.UtcNow;
            DateTime modelEndDate = DateTime.UtcNow;
            string modelTrainerId = null;
            string successMessage = null;

            // callback fakes the method create async, whenever someone calls it returns the data below
            adminCourseService
                .Setup(s => s.CreateAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<DateTime>(),
                    It.IsAny<DateTime>(),
                    It.IsAny<string>()))
                .Callback((
                    string name,
                    string description,
                    DateTime startDate,
                    DateTime endDate,
                    string trainerId) =>
                    {
                        modelName = name;
                        modelDescription = description;
                        modelStartDate = startDate;
                        modelEndDate = endDate;
                        modelTrainerId = trainerId;
                    })
                .Returns(Task.CompletedTask);

            // Act
            var tempData = new Mock<ITempDataDictionary>(); // if forget to mock it will get null reference exception
            tempData.SetupSet(t => t[WebConstants.TempDataSuccessMessageKey] = It.IsAny<string>())
                .Callback((string key, object message) => successMessage = message as string); // mock indexer

            var controller = new CoursesController(UserManagerMock.New.Object, adminCourseService.Object)
            {
                TempData = tempData.Object
            };

            var result = await controller.Create(new AddCourseFormViewModel
            {
                Name = nameValue,
                Description = descriptionValue,
                StartDate = startDateValue,
                EndDate = endDateValue,
                TrainerId = trainerIdValue
            });

            // Assert
            modelName.Should().Be(nameValue);
            modelDescription.Should().Be(descriptionValue);
            modelStartDate.Should().Be(startDateValue);
            modelEndDate.Should().Be(endDateValue.AddDays(1));
            modelTrainerId.Should().Be(trainerIdValue);

            successMessage.Should().Be($"Course {nameValue} was successfully created.");

            result.Should().BeOfType<RedirectToActionResult>();
            result.As<RedirectToActionResult>().ActionName.Should().Be("Index");
            result.As<RedirectToActionResult>().ControllerName.Should().Be("Home");
            result.As<RedirectToActionResult>().RouteValues.Keys.Should().Contain("area");
            result.As<RedirectToActionResult>().RouteValues.Values.Should().Contain(string.Empty);
        }

        private Mock<UserManager<User>> GetUserManagerMock()
        {
            var userManager = UserManagerMock.New;
            userManager
                .Setup(u => u.GetUsersInRoleAsync(It.IsAny<string>()))
                .ReturnsAsync(this.GetTrainersTestList());

            return userManager;
        }

        private List<User> GetTrainersTestList()
            => new List<User>
                {
                    new User { Id = FirstUserId, UserName = FirstUserUsername },
                    new User { Id = SecondUserId, UserName = SecondUserUsername },
                };
    }
}
