using System;

public class Worker : Human
{
    private decimal weekSalary;
    private double workingHours;

    public Worker(string fName, string lName, decimal weekSalary, double workingHours) 
        : base(fName, lName)
    {
        WeekSalary = weekSalary;
        WorkingHoursPerDay = workingHours;
    }

    public decimal WeekSalary
    {
        get
        {
            return this.weekSalary;
        }
        protected set
        {
            if (value < 10)
            {
                throw new ArgumentException("Expected value mismatch!Argument: weekSalary");
            }
            this.weekSalary = value;
        }
    }

    public double WorkingHoursPerDay
    {
        get
        {
            return this.workingHours;
        }
        protected set
        {
            if (value > 12 || value < 1)
            {
                throw new ArgumentException("Expected value mismatch!Argument: workHoursPerDay");
            }
            this.workingHours = value;
        }
    }

    public override string LastName
    {
        get
        {
            return base.LastName;
        }

        protected set
        {
            if (value.Length < 4)
            {
                throw new ArgumentException("Expected length more than 3 symbols!Argument: lastName");
            }
            base.LastName = value;
        }
    }

    public override string ToString()
    {
        return $"{base.ToString()}\nWeek Salary: {this.WeekSalary:F2}\nHours per day: {this.WorkingHoursPerDay:F2}\nSalary per hour: {(this.WeekSalary / 5) / (decimal)this.WorkingHoursPerDay:F2}";
    }
}
