namespace LearningSystem.Test.Web.Controllers
{
    using Data.Models;
    using FluentAssertions;
    using LearningSystem.Services;
    using LearningSystem.Services.Models.Users;
    using LearningSystem.Web.Controllers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Mocks;
    using Moq;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public class UserControllerTest
    {
        [Fact]
        public void DownloadCertificateShouldBeOnlyForAuthorizedUsers()
        {
            // Arrange
            var method = typeof(UsersController)
                .GetMethod(nameof(UsersController.DownloadCertificate));

            // Act
            var attributes = method
                .GetCustomAttributes(true);

            // Assert
            attributes
                .Should()
                .Match(attr => attr.Any(a => a.GetType() == typeof(AuthorizeAttribute)));
        }

        [Fact]
        public async Task ProfileShouldReturnNotFoundWithInvalidUsername()
        {
            // Arrange
            var controller = new UsersController(UserManagerMock.New.Object, null);

            // Act
            var result = await controller.Profile("Username");

            result
                .Should()
                .BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task ProfileShouldReturnViewWithCorrectModelWithValidUsername()
        {
            // Arrange
            const string userId = "SomeId";
            const string username = "SomeUsername";

            var userManager = UserManagerMock.New;
            userManager // it means whenever someone calls this method with any string will return new user with id = someid
                .Setup(u => u.FindByNameAsync(It.IsAny<string>()))
                .ReturnsAsync(new User { Id = userId });

            var userService = new Mock<IUserService>();
            userService // here returns the userprofile only if the id is equal to userid
                .Setup(u => u.ProfileAsync(It.Is<string>(id => id == userId)))
                .ReturnsAsync(new UserProfileServiceModel { Username = username });

            var controller = new UsersController(userManager.Object, userService.Object);

            // Act
            var result = await controller.Profile(username);

            // Assert
            result
                .Should()
                .BeOfType<ViewResult>()
                .Subject // points to the concret result
                .Model
                .Should()
                .Match(r => r.As<UserProfileServiceModel>().Username == username);
        }
    }
}
