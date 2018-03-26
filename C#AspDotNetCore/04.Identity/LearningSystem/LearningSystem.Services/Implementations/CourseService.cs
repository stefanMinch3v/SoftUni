namespace LearningSystem.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using LearningSystem.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Models.Courses;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CourseService : ICourseService
    {
        private readonly LearningSystemDbContext db;

        public CourseService(LearningSystemDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<CourseListingServiceModel>> AllAsync()
            => await this.db.Courses
                .OrderByDescending(c => c.Id)
                .ProjectTo<CourseListingServiceModel>()
                .ToListAsync();

        public async Task<IEnumerable<CourseListingServiceModel>> ActiveAsync()
            => await this.db.Courses
                .OrderByDescending(c => c.Id)
                .Where(c => c.StartDate >= DateTime.UtcNow)
                .ProjectTo<CourseListingServiceModel>()
                .ToListAsync();

        public async Task<IEnumerable<CourseListingServiceModel>> FindAsync(string searchText)
        {
            searchText = searchText ?? string.Empty;

            return await this.db.Courses
                .OrderByDescending(c => c.Id)
                .Where(c => c.Name.ToLower().Contains(searchText.ToLower()))
                .ProjectTo<CourseListingServiceModel>()
                .ToListAsync();
        }

        public Task<TModel> ByIdAsync<TModel>(int id) where TModel : class
            => this.db.Courses
                .Where(c => c.Id == id)
                .ProjectTo<TModel>()
                .FirstOrDefaultAsync();

        public async Task<bool> SignUpUserAsync(string userId, int courseId)
        {
            var courseInfo = await this.GetCourseInfo(userId, courseId);

            if (courseInfo == null
                || courseInfo.StartDate < DateTime.UtcNow
                || courseInfo.UserIdEnrolled)
            {
                return false;
            }

            var studentInCourse = new StudentCourse
            {
                CourseId = courseId,
                StudentId = userId
            };

            this.db.Add(studentInCourse);

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> SignOutUserAsync(string userId, int courseId)
        {
            var courseInfo = await this.GetCourseInfo(userId, courseId);

            if (courseInfo == null
                || courseInfo.StartDate < DateTime.UtcNow
                || !courseInfo.UserIdEnrolled)
            {
                return false;
            }

            // possible exceptions :
            // if the keys are only integers you need to specify the order : [Key] [Column(Order =)]
            // you must always follow the order of the key taken from the DB!
            var studentInCourse = await this.db
                .FindAsync<StudentCourse>(courseId, userId);

            // another version but with join
            //var studentInCours = await this.db.Courses
            //    .Where(c => c.Id == courseId)
            //    .SelectMany(c => c.Students)
            //    .FirstOrDefaultAsync(s => s.StudentId == userId);

            this.db.Remove(studentInCourse);

            await this.db.SaveChangesAsync();

            return true;
        }

        public Task<bool> UserIsEnrolledInCourseAsync(int courseId, string userId)
            => this.db.Courses
                .AnyAsync(c => c.Id == courseId && c.Students.Any(s => s.StudentId == userId));

        private async Task<CourseWithStudentInfo> GetCourseInfo(string userId, int courseId)
            => await this.db.Courses
                .Where(c => c.Id == courseId)
                .Select(c => new CourseWithStudentInfo
                {
                    StartDate = c.StartDate,
                    UserIdEnrolled = c.Students.Any(s => s.StudentId == userId)
                })
                .FirstOrDefaultAsync();

        public async Task<bool> SaveExamSubmission(int courseId, string studentId, byte[] examSubmission)
        {
            var studentInCourse = await this.db
                .FindAsync<StudentCourse>(courseId, studentId);

            if (studentInCourse == null)
            {
                return false;
            }

            studentInCourse.ExamSubmission = examSubmission;

            await this.db.SaveChangesAsync();

            return true;
        }
    }
}
