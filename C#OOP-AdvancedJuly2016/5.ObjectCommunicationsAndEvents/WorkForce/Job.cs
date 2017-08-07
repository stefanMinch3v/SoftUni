namespace WorkForce
{
    using System;

    public delegate void JobUpdateHandler(object sender, JobDoneEventArgs e);

    public class Job
    {
        private string name;
        private int hoursOfWorkRequired;
        private Employee employee;

        public Job(Employee employee, string name, int hoursOfWorkRequired)
        {
            this.Name = name;
            this.HoursOfWorkRequired = hoursOfWorkRequired;
            this.Employee = employee;
        }

        public event JobUpdateHandler JobUpdater;// here we can use only simple EventHandler(which is a part of a delegate) and delete the delegate JobUpdateHandler

        public Employee Employee
        {
            get
            {
                return this.employee;
            }
            private set
            {
                this.employee = value;
            }
        }

        public int HoursOfWorkRequired
        {
            get
            {
                return this.hoursOfWorkRequired;
            }
            private set
            {
                this.hoursOfWorkRequired = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                this.name = value;
            }
        }

        public void Update()
        {
            this.HoursOfWorkRequired -= this.Employee.WorkHoursPerWeek;

            if (this.HoursOfWorkRequired <= 0)
            {
                Console.WriteLine($"Job {this.Name} done!");
                this.OnJobUpdate(new JobDoneEventArgs(this));
            }
        }

        public void OnJobUpdate(JobDoneEventArgs e)
        {
            this.JobUpdater?.Invoke(this, e); // if jobupdatehandler is != null then invoke it
        }

        public override string ToString()
        {
            return string.Format($"Job: {this.Name} Hours Remaining {this.HoursOfWorkRequired}");
        }
    }
}
