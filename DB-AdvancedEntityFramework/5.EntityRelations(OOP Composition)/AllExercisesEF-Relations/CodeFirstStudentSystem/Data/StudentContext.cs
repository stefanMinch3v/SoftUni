namespace CodeFirstStudentSystem.Data
{
    using CodeFirstStudentSystem.Migrations;
    using CodeFirstStudentSystem.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class StudentContext : DbContext
    {
        public StudentContext()
            : base("name=StudentContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentContext, Configuration>());
            //Database.SetInitializer(new MyStartInitializer());
        }

        public virtual DbSet<Course> Courses { get; set; }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<Homework> Homework { get; set; }

        public virtual DbSet<Resource> Resources { get; set; }

    }
}