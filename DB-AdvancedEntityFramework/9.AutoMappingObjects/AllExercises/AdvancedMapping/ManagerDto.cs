namespace AdvancedMapping
{
    using System.Collections.Generic;

    public class ManagerDto
    {
        public ManagerDto()
        {
            this.Subordinates = new HashSet<EmployeeDto>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public HashSet<EmployeeDto> Subordinates { get; set; }

        public int NumberOfSubordinates { get; set; }
    }
}
