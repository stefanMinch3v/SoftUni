namespace LearningSystem.Test.Web.Controllers
{
    using FluentAssertions;
    using LearningSystem.Services;
    using LearningSystem.Services.Models.Courses;
    using LearningSystem.Services.Models.Users;
    using LearningSystem.Web.Controllers;
    using LearningSystem.Web.Models.Home;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public class HomeControllerTest
    {
        [Fact]
        public async Task SearchShouldReturnNoResultsWithNoCriteria()
        {
            // Arrange
            var controller = new HomeController(null, null);

            // Act
            var result = await controller.Search(new SearchFormModel
            {
                SearchInCourses = false,
                SearchInUsers = false
            });

            // Assert
            result.Should().BeOfType<ViewResult>();
            result.As<ViewResult>().Model.Should().BeOfType<SearchViewModel>();

            var searchViewModel = result.As<ViewResult>().Model.As<SearchViewModel>();

            searchViewModel.Courses.Should().BeEmpty();
            searchViewModel.Users.Should().BeEmpty();
            searchViewModel.SearchText.Should().BeNull();
        }

        [Fact]
        public async Task SearchShouldReturnViewWithValidModelWhenCoursesAreFiltered()
        {
            // Arrange
            const string searchText = "search";

            var courseService = new Mock<ICourseService>();
            courseService
                .Setup(c => c.FindAsync(It.IsAny<string>()))
                .ReturnsAsync(new List<CourseListingServiceModel>
                {
                    new CourseListingServiceModel { Id = 10 }
                });

            var controller = new HomeController(courseService.Object, null);

            // Act
            var result = await controller.Search(new SearchFormModel
            {
                SearchText = searchText,
                SearchInCourses = true,
                SearchInUsers = false
            });

            // Assert
            result.Should().BeOfType<ViewResult>();
            result.As<ViewResult>().Model.Should().BeOfType<SearchViewModel>();

            var searchViewModel = result.As<ViewResult>().Model.As<SearchViewModel>();

            searchViewModel.Courses.Should().Match(c => c.As<List<CourseListingServiceModel>>().Count == 1);
            searchViewModel.Courses.First().Should().Match(c => c.As<CourseListingServiceModel>().Id == 10);
            searchViewModel.Users.Should().BeEmpty();
            searchViewModel.SearchText.Should().Be(searchText);
        }

        [Fact]
        public async Task SearchShouldReturnViewWithValidModelWhenUsersAreFiltered()
        {
            // Arrange
            const string searchText = "search";

            var userService = new Mock<IUserService>();
            userService
                .Setup(c => c.FindAsync(It.IsAny<string>()))
                .ReturnsAsync(new List<UserListingServiceModel>
                {
                    new UserListingServiceModel { NumOfCourses = 10 }
                });

            var controller = new HomeController(null, userService.Object);

            // Act
            var result = await controller.Search(new SearchFormModel
            {
                SearchText = searchText,
                SearchInCourses = false,
                SearchInUsers = true
            });

            // Assert
            result.Should().BeOfType<ViewResult>();
            result.As<ViewResult>().Model.Should().BeOfType<SearchViewModel>();

            var searchViewModel = result.As<ViewResult>().Model.As<SearchViewModel>();

            searchViewModel.Users.Should().Match(c => c.As<List<UserListingServiceModel>>().Count == 1);
            searchViewModel.Users.First().Should().Match(c => c.As<UserListingServiceModel>().NumOfCourses == 10);
            searchViewModel.Courses.Should().BeEmpty();
            searchViewModel.SearchText.Should().Be(searchText);
        }
    }
}
