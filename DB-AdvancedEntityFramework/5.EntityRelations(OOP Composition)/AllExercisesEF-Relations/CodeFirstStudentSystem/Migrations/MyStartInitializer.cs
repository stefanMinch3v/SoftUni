namespace CodeFirstStudentSystem.Migrations
{
    using CodeFirstStudentSystem.Data;
    using CodeFirstStudentSystem.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;

    public class MyStartInitializer : CreateDatabaseIfNotExists<StudentContext>
    {
        protected override void Seed(StudentContext context)
        {
            Student pesho = new Student()
            {
                Name = "Pesho",
                DateOfBirth = DateTime.Parse("1990-01-10"),
                PhoneNumber = "0988181823",
                RegistrationDate = DateTime.Now
            };

            context.Students.AddOrUpdate(s => s.Name, pesho);

            Student gosho = new Student()
            {
                Name = "Gosho",
                DateOfBirth = DateTime.Parse("1988-05-11"),
                PhoneNumber = "0988777723",
                RegistrationDate = DateTime.Now
            };

            context.Students.AddOrUpdate(s => s.Name, gosho);

            Student qnaki = new Student()
            {
                Name = "Qnaki",
                DateOfBirth = DateTime.Parse("1980-05-11"),
                PhoneNumber = "0988777111723",
                RegistrationDate = DateTime.Now
            };

            context.Students.AddOrUpdate(s => s.Name, qnaki);

            Student ivan = new Student()
            {
                Name = "Ivan",
                DateOfBirth = DateTime.Parse("1998-05-11"),
                PhoneNumber = "0988771231237723",
                RegistrationDate = DateTime.Now
            };

            context.Students.AddOrUpdate(s => s.Name, ivan);

            Homework peshoHomework = new Homework("Zip")
            {
                Content = "Interfaces and Abstractions",
                SubmissionDate = DateTime.Now
            };

            context.Homework.AddOrUpdate(h => h.Content, peshoHomework);

            Homework qnakiHomework = new Homework("Pdf")
            {
                Content = "Triangle exercises",
                SubmissionDate = DateTime.Now
            };

            context.Homework.AddOrUpdate(h => h.Content, qnakiHomework);

            Homework goshoHomework = new Homework("Zip")
            {
                Content = "Interfaces and Abstractions solutions",
                SubmissionDate = DateTime.Now
            };

            context.Homework.AddOrUpdate(h => h.Content, goshoHomework);

            Homework ivanHomework = new Homework("Pdf")
            {
                Content = "Triangle exercises solutions",
                SubmissionDate = DateTime.Now
            };

            context.Homework.AddOrUpdate(h => h.Content, ivanHomework);

            Resource introAbstractions = new Resource()
            {
                Name = "Intro to Interfaces and Abstractions",
                TypeOfResource = "Video",
                Url = "softuni.bg"
            };

            context.Resources.AddOrUpdate(r => r.Name, introAbstractions);

            Resource mathBasics = new Resource()
            {
                Name = "Math basics",
                TypeOfResource = "Video",
                Url = "softuni.bg"
            };

            context.Resources.AddOrUpdate(r => r.Name, mathBasics);

            Course oop = new Course()
            {
                Name = "C# OOP",
                StartDate = DateTime.Now,
                EndDate = DateTime.Parse("2017-10-11"),
                Price = 500m
            };

            context.Courses.AddOrUpdate(c => c.Name, oop);

            Course math = new Course()
            {
                Name = "Triangle part 1",
                StartDate = DateTime.Now,
                EndDate = DateTime.Parse("2017-12-12"),
                Price = 700m
            };

            context.Courses.AddOrUpdate(c => c.Name, math);

            context.SaveChanges();

            //add course to student
            pesho.Courses.Add(oop);
            gosho.Courses.Add(oop);
            qnaki.Courses.Add(math);
            ivan.Courses.Add(math);

            //add homework to student
            pesho.Homework.Add(peshoHomework);
            gosho.Homework.Add(goshoHomework);
            ivan.Homework.Add(ivanHomework);
            qnaki.Homework.Add(qnakiHomework);

            //add resources to course
            oop.Resources.Add(introAbstractions);
            math.Resources.Add(mathBasics);

            //add homework to course
            oop.Homeworks.Add(peshoHomework);
            oop.Homeworks.Add(goshoHomework);
            math.Homeworks.Add(qnakiHomework);
            math.Homeworks.Add(ivanHomework);

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
