namespace WorkForce
{
    public abstract class Employee
    {
        private string name;
        private int workHoursPerWeek;

        public Employee(string name, int workingHoursPerWeek)
        {
            this.Name = name;
            this.WorkHoursPerWeek = workingHoursPerWeek;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            protected set
            {
                this.name = value;
            }
        }

        public int WorkHoursPerWeek
        {
            get
            {
                return this.workHoursPerWeek;
            }
            protected set
            {
                this.workHoursPerWeek = value;
            }
        }
    }
}
