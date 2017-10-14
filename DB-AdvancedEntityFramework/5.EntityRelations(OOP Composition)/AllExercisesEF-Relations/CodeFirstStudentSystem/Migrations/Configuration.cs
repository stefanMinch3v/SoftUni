namespace CodeFirstStudentSystem.Migrations
{
    using CodeFirstStudentSystem.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CodeFirstStudentSystem.Data.StudentContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;
            ContextKey = "CodeFirstStudentSystem.Data.StudentContext";
        }

        protected override void Seed(CodeFirstStudentSystem.Data.StudentContext context)
        {
        }
    }
}
