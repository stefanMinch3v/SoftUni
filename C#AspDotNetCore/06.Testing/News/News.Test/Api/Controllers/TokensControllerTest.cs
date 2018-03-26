namespace News.Test.Api.Controllers
{
    using FluentAssertions;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Mocks;
    using Moq;
    using News.Api;
    using News.Api.Controllers;
    using News.Api.Models.Tokens;
    using News.Data.Models;
    using System.IO;
    using System.Threading.Tasks;
    using Xunit;

    public class TokensControllerTest
    {
        private const string UsernameValue = "Ivo";
        private const string EmailValue = "ivo@abv.bg";
        private const string PasswordValue = "test12";
        private const string ConfirmPasswordValue = "test12";

        [Fact]
        public async Task CreateNewUserWithCorrectDataShouldReturnOkResultObject()
        {
            // Arrange

            User modelUser = null;
            string modelPassword = null;
            bool modelIsPersistent = false;

            var userManager = this.GetUserManager();
            userManager
                .Setup(u => u.CreateAsync(
                    It.IsAny<User>(),
                    It.IsAny<string>()))
                .Callback((
                    User user,
                    string password) =>
                    {
                        modelUser = user;
                        modelPassword = password;
                    })
                .Returns(Task.FromResult(IdentityResult.Success));

            var signInManager = this.GetSignInManager();
            signInManager
                .Setup(s => s.SignInAsync(
                    It.IsAny<User>(),
                    It.IsAny<bool>(),
                    It.IsAny<string>()))
                .Callback((
                    User user,
                    bool isPersistent,
                    string authenticationMethod) =>
                    {
                        modelUser = user;
                        modelIsPersistent = isPersistent;
                        authenticationMethod = null;
                    })
                .Returns(Task.CompletedTask);

            var configuration = this.GetConfiguration();

            var controller = new TokensController(configuration, userManager.Object, signInManager.Object);

            // Act
            var result = await controller.Register(new RegisterFormModel
            {
                Username = UsernameValue,
                Email = EmailValue,
                Password = PasswordValue,
                ConfirmPassword = ConfirmPasswordValue
            });

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            result.Should().Match(r => r.As<OkObjectResult>().Value.ToString().Contains(WebConstants.ImportantMessageSecurityToken));

            // check for successfuly added model == modelValue ? thats why i have the model and modelValues
        }

        [Fact]
        public async Task CreateNewUserWithExistingUsernameShouldReturnBadRequestObjectResult()
        {
            // Arrange
            var userManager = this.GetUserManager();
            userManager
                .Setup(u => u.CreateAsync(
                    It.IsAny<User>(),
                    It.IsAny<string>()))
                .Returns(Task.FromResult(IdentityResult.Failed(new IdentityError())));

            var controller = new TokensController(null, userManager.Object, null);

            // Act

            var result = await controller.Register(new RegisterFormModel
            {
                Username = UsernameValue,
                Email = EmailValue,
                Password = PasswordValue,
                ConfirmPassword = ConfirmPasswordValue
            });

            // Assert
            result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public async Task LoginForExistingUserWithCorrectDataShouldReturnCreatedObjectResult()
        {
            // Arrange
            var userManager = this.GetUserManager();
            userManager
                .Setup(u => u.FindByNameAsync(
                    It.IsAny<string>()))
                .ReturnsAsync(new User
                {
                    UserName = UsernameValue,
                    Email = EmailValue
                });

            var signInManager = this.GetSignInManager();
            signInManager
                .Setup(s => s.PasswordSignInAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<bool>(),
                    It.IsAny<bool>()))
                .ReturnsAsync(Microsoft.AspNetCore.Identity.SignInResult.Success);

            var configuration = this.GetConfiguration();

            var controller = new TokensController(configuration, userManager.Object, signInManager.Object);

            // Act
            var result = await controller.Login(new LoginFormModel
            {
                Username = UsernameValue,
                Password = PasswordValue
            });

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            result.Should().Match(r => r.As<OkObjectResult>().Value.ToString().Contains(WebConstants.ImportantMessageSecurityToken));
        }

        [Fact]
        public async Task LoginForUnexistingUserShouldReturnBadRequestObject()
        {
            // Arrange
            const string unExistingUsername = "Cracker";

            var userManager = this.GetUserManager();
            userManager
                .Setup(u => u.FindByNameAsync(
                    It.IsAny<string>()))
                .ReturnsAsync(new User
                {
                    UserName = unExistingUsername
                });

            var signInManager = this.GetSignInManager();
            signInManager
                .Setup(s => s.PasswordSignInAsync(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<bool>(),
                    It.IsAny<bool>()))
                .ReturnsAsync(Microsoft.AspNetCore.Identity.SignInResult.Failed);

            var configuration = this.GetConfiguration();

            var controller = new TokensController(configuration, userManager.Object, signInManager.Object);

            // Act
            var result = await controller.Login(new LoginFormModel
            {
                Username = unExistingUsername,
                Password = PasswordValue
            });

            // Assert
            result.Should().BeOfType<UnauthorizedResult>(); // could be done with bad request object result 
        }

        private Mock<UserManager<User>> GetUserManager()
            => new Mock<UserManager<User>>(
                Mock.Of<IUserStore<User>>(), null, null, null, null, null, null, null, null);

        private Mock<SignInManager<User>> GetSignInManager()
            => new Mock<SignInManager<User>>(
                this.GetUserManager().Object,
                new HttpContextAccessor { HttpContext = this.GetHttpContext().Object },
                this.GetClaimsFactory().Object,
                null, null, null);

        private Mock<HttpContext> GetHttpContext()
            => new Mock<HttpContext>();

        private Mock<IUserClaimsPrincipalFactory<User>> GetClaimsFactory()
            => new Mock<IUserClaimsPrincipalFactory<User>>();

        private IConfiguration GetConfiguration()
            => new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .Build();
    }
}
