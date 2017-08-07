namespace WorkForce
{
    public class PartTimeEmployee : Employee
    {
        private const int workingHoursPerWeek = 20;

        public PartTimeEmployee(string name) 
            : base(name, workingHoursPerWeek)
        {
        }
    }
}
