namespace ProjectionSolution.Data
{
    using ProjectionSolution.Models;
    using System.Data.Entity;

    public class EmployeeContext : DbContext
    {
        public EmployeeContext()
            : base("name=EmployeeContext")
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<EmployeeContext>());
        }

        public virtual DbSet<Employee> Employees { get; set; }
    }
}