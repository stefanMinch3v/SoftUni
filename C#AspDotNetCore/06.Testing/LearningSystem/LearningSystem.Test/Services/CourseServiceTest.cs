namespace LearningSystem.Test.Services
{
    using Data;
    using Data.Models;
    using FluentAssertions;
    using LearningSystem.Services.Implementations;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public class CourseServiceTest
    {
        public CourseServiceTest()
        {
            Tests.Initialize();
        }

        [Fact]
        public async Task FindAsyncShouldReturnCorrectResultWithFilteringAndOrder()
        {
            // Can be done with mocking too. But with the microsoft library inmemory we can use use in memory database.
            // We will use mocking for the controllers in the web part

            // Arrange
            var db = this.GetDatabase();

            var firstCourse = new Course { Id = 1, Name = "First" };
            var secondCourse = new Course { Id = 2, Name = "Second" };
            var thirdCourse = new Course { Id = 3, Name = "Third" };

            db.AddRange(firstCourse, secondCourse, thirdCourse);

            await db.SaveChangesAsync();

            var courseService = new CourseService(db);

            // Act
            var result = await courseService.FindAsync("t");

            // Assert
            result
                .Should()
                .Match(r =>
                    r.ElementAt(0).Id == 3
                    && r.ElementAt(1).Id == 1)
                .And
                .HaveCount(2);
        }

        [Fact]
        public async Task SignUpStudentAsyncShouldSaveCorrectDataWithValidCourseIdAndStudentId()
        {
            // Arrange
            var db = this.GetDatabase();

            var courseService = new CourseService(db);

            const int courseId = 1;
            const string studentId = "TestStudentId";

            // datetime.minvalue is always before the current date
            // datetime.maxvalue is always after the current date

            var course = new Course
            {
                Id = courseId,
                StartDate = DateTime.MaxValue,
                Students = new List<StudentCourse>()
            };

            db.Add(course);

            await db.SaveChangesAsync();

            // Act
            var result = await courseService.SignUpUserAsync(studentId, courseId);
            var savedEntry = db.Find<StudentCourse>(courseId, studentId);

            // Assert
            result
                .Should()
                .Be(true);

            savedEntry
                .Should()
                .NotBeNull();
        }

        private LearningSystemDbContext GetDatabase()
        {
            var dbOptions = new DbContextOptionsBuilder<LearningSystemDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .Options; // create everytime unique name cuz if the name is equal to all methods it will share the database between them

            return new LearningSystemDbContext(dbOptions);
        }
    }
}
