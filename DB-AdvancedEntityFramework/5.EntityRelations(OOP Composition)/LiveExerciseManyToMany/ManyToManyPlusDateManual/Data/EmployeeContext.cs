namespace ManyToManyPlusDateManual.Data
{
    using ManyToManyPlusDateManual.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class EmployeeContext : DbContext
    {
        public EmployeeContext()
            : base("name=EmployeeContext")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<EmployeeContext>());
            //Database.SetInitializer<EmployeeContext>(null); // to disable default initializer must do in the production environment in order not to loose some information in db
        }

         public virtual DbSet<Employee> Employees { get; set; }

         public virtual DbSet<Project> Projects { get; set; }

         public virtual DbSet<ProjectEmployees> ProjectEmployees { get; set; }
    }
}