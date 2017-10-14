namespace ManyToManyPlusDateManual.Models
{
    using System.Collections.Generic;

    public class Employee
    {
        public Employee()
        {
            this.ProjectEmployees = new HashSet<ProjectEmployees>();
        }
        public int EmployeeId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<ProjectEmployees> ProjectEmployees { get; set; }
    }
}
