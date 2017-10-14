namespace AdvancedMapping
{
    using System;
    using System.Collections.Generic;

    public class Employee
    {
        public Employee()
        {
            this.Subordinates = new HashSet<Employee>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public DateTime Birthday { get; set; }

        public string Address { get; set; }

        public bool IsOnHoliday { get; set; }

        public Employee Manager { get; set; }

        public HashSet<Employee> Subordinates { get; set; }

    }
}
