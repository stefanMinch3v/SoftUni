namespace News.Test.Api.Controllers
{
    using Data;
    using Data.Models;
    using FluentAssertions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using News.Api.Controllers;
    using News.Api.Infrastructure.Filters;
    using News.Api.Models.News;
    using News.Test.Mocks;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    public class NewsControllerTest
    {
        [Fact]
        public void ListAllNewsShouldReturnOkResult()
        {
            // Arrange
            var db = InMemoryDatabase.GetDatabaseInstance();
            var controller = new NewsController(db);

            // Act
            var result = controller.Get();

            // Assert
            result
                .Should()
                .BeOfType<OkObjectResult>();
        }

        [Fact]
        public void ListAllNewsShouldReturnTheCorrectDataAndOkResult()
        {
            // Arrange
            var db = InMemoryDatabase.GetDatabaseInstance();
            var controller = new NewsController(db);
            this.PopulateDatabase(db);

            // Act
            var actionResult = controller.Get() as OkObjectResult;

            // Assert
            actionResult
                .Should()
                .NotBeNull();

            actionResult.Value
                .Should()
                .Equals(this.GetTestData());
        }

        [Fact]
        public void CreateNewsWithCorrectDataShouldReturnCreatedResultAndCorrectData()
        {
            // Arrange
            var db = InMemoryDatabase.GetDatabaseInstance();
            var controller = new NewsController(db);

            // Act
            var model = new NewsFormModel
            {
                Title = "Test title",
                Content = "Test content",
                PublishDate = DateTime.UtcNow
            };

            var actionResult = controller.Post(model) as CreatedAtActionResult;

            // Assert
            actionResult
                .Should()
                .NotBeNull();

            actionResult.Value
                .Should()
                .Be(model);
        }

        [Fact]
        public void CreateNewsWithTheSameTitleShouldReturnBadRequest()
        {
            // Arrange
            var db = InMemoryDatabase.GetDatabaseInstance();
            var controller = new NewsController(db);

            this.PopulateDatabase(db);

            // Act
            var dublicateModel = new NewsFormModel
            {
                Title = "Test title", // this is unique
                Content = "Test content",
                PublishDate = DateTime.UtcNow
            };

            var result = controller.Post(dublicateModel);

            // Assert
            result
                .Should()
                .BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public void CreateNewsShouldHaveModelStateValidationAttribute()
        {
            // Arrange
            var method = typeof(NewsController)
                .GetMethod(nameof(NewsController.Post));

            // Act
            var attributes = method
                .GetCustomAttributes(true);

            // Assert
            attributes
                .Should()
                .Match(attr => attr.Any(a => a.GetType() == typeof(ValidateModelStateAttribute)));
        }

        [Fact]
        public void CreateNewsWithIncorrectModelStateShouldReturnBadRequest()
        {
            // Arrange
            var db = InMemoryDatabase.GetDatabaseInstance();
            var controller = new NewsController(db);

            // Act
            var model = new NewsFormModel
            {
                PublishDate = DateTime.UtcNow
            };

            controller.ModelState.AddModelError("Invalid Data", "Invalid Data");

            // Assert
            controller.Post(model)
                .Should()
                .BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public void ModifyExistingNewsWithCorrectDataShouldReturnOkResult()
        {
            // Arrange
            var db = InMemoryDatabase.GetDatabaseInstance();
            var controller = new NewsController(db);

            this.PopulateDatabase(db);

            // Act
            var modifyEntry = this.GetPeshoTestObject();

            var result = controller.Put(1, modifyEntry) as OkResult;

            // Assert
            result
                .Should()
                .BeOfType<OkResult>();
        }

        [Fact]
        public void ModifyExistingNewsWithCorrectDataShouldBeEqualToTheSameObjectData()
        {
            // Arrange
            var db = InMemoryDatabase.GetDatabaseInstance();
            var controller = new NewsController(db);

            this.PopulateDatabase(db);

            // Act
            var modifyEntry = this.GetPeshoTestObject();

            controller.Put(1, modifyEntry);

            var dbEntry = db.News.First();

            // Assert
            dbEntry
                .Should()
                .Match(n => n.As<News>().Title == modifyEntry.Title
                    && n.As<News>().Content == modifyEntry.Content
                    && n.As<News>().PublishDate == modifyEntry.PublishDate);
        }

        [Fact]
        public void ModifyNewsWithUnexistingIdShouldReturnBadRequest()
        {
            // Arrange
            var db = InMemoryDatabase.GetDatabaseInstance();
            var controller = new NewsController(db);

            this.PopulateDatabase(db);

            // Act
            var modifyEntry = this.GetPeshoTestObject();

            // Assert
            controller.Put(5, modifyEntry)
                .Should()
                .BeOfType<BadRequestObjectResult>();

        }

        [Fact]
        public void ModifyExistingNewsWithIncorrectDataShouldReturnBadRequest()
        {
            // Arrange
            var db = InMemoryDatabase.GetDatabaseInstance();
            var controller = new NewsController(db);

            this.PopulateDatabase(db);

            // Act
            var modifyEntry = new NewsFormModel
            {
                PublishDate = DateTime.Now
            };

            controller.ModelState.AddModelError("Invalid Data", "Invalid Data");

            // Assert
            controller.Put(1, modifyEntry)
                .Should()
                .BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public void DeleteExistingNewsShouldReturnOkResult()
        {
            // Arrange
            var db = InMemoryDatabase.GetDatabaseInstance();
            var controller = new NewsController(db);

            this.PopulateDatabase(db);

            // Act
            var result = controller.Delete(1);

            // Assert
            result
                .Should()
                .BeOfType<OkObjectResult>();
        }

        [Fact]
        public void DeleteUnexistingNewsShouldReturnBadRequest()
        {
            // Arrange
            var db = InMemoryDatabase.GetDatabaseInstance();
            var controller = new NewsController(db);

            this.PopulateDatabase(db);

            // Act
            var result = controller.Delete(5);

            // Assert
            result
                .Should()
                .BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public void PostActionShouldHaveAuthorizeAttribute()
        {
            // Arrange
            var method = typeof(NewsController)
                .GetMethod(nameof(NewsController.Post));

            // Act
            var attributes = method
                .GetCustomAttributes(true);

            // Assert
            attributes
                .Should()
                .Match(attr => attr.Any(a => a.GetType() == typeof(AuthorizeAttribute)));
        }

        [Fact]
        public void DeleteActionShouldHaveAuthorizeAttribute()
        {
            // Arrange
            var method = typeof(NewsController)
                .GetMethod(nameof(NewsController.Delete));

            // Act
            var attributes = method
                .GetCustomAttributes(true);

            // Assert
            attributes
                .Should()
                .Match(attr => attr.Any(a => a.GetType() == typeof(AuthorizeAttribute)));
        }

        [Fact]
        public void PutActionShouldHaveAuthorizeAttribute()
        {
            // Arrange
            var method = typeof(NewsController)
                .GetMethod(nameof(NewsController.Put));

            // Act
            var attributes = method
                .GetCustomAttributes(true);

            // Assert
            attributes
                .Should()
                .Match(attr => attr.Any(a => a.GetType() == typeof(AuthorizeAttribute)));
        }

        // left :
        // create news with correct data and logged in user returns 201 created
        // create news with correct data and no logged in user returns 401 unauth
        // modify existing data with logged in returns 200
        // modify existing data with no logged in returns 401 unauth
        // delete existing data with logged in returns 200
        // delete existing data with no logged in returns 401

        private IEnumerable<News> GetTestData()
        {
            return new List<News>
            {
                new News { Id = 1, Title = "Test title", Content = "Test content", PublishDate = DateTime.Parse("01/01/2011") },
                new News { Id = 2, Title = "Test title2", Content = "Test content2", PublishDate = DateTime.Parse("01/01/2012") },
                new News { Id = 3, Title = "Test title3", Content = "Test content3", PublishDate = DateTime.Parse("01/01/2013") },
            };
        }

        private void PopulateDatabase(NewsDbContext db)
        {
            db.News.AddRange(this.GetTestData());
            db.SaveChanges();
        }

        private NewsFormModel GetPeshoTestObject()
            => new NewsFormModel
            {
                Title = "Pesho",
                Content = "Pesho",
                PublishDate = DateTime.Parse("01/01/1991")
            };
    }
}
