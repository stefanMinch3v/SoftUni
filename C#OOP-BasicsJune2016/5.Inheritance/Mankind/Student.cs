using System;

public class Student : Human
{
    private string facultyNumber;

    public Student(string fName, string lName, string facultyNumber) 
        : base(fName, lName)
    {
        FacultyNumber = facultyNumber;
    }

    public string FacultyNumber
    {
        get
        {
            return this.facultyNumber;
        }
        private set
        {
            if (value.Length < 5 || value.Length > 10)
            {
                throw new ArgumentException("Invalid faculty number!");
            }
            foreach (var number in value)
            {
                if (!char.IsDigit(number))
                {
                    throw new ArgumentException("Invalid faculty number!");
                }
            }
            this.facultyNumber = value;
        }
    }

    public override string ToString()
    {
        return $"{base.ToString()}\nFaculty number: {this.FacultyNumber}";
    }
}
