using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Startup
{
    public static void Main()
    {
        string[] input = Console.ReadLine().Split();
        List<Student> students = new List<Student>();

        while (!input.Contains("END"))
        {
            string fName = input[0];
            string lName = input[1];
            string phone = input[2];
            students.Add(new Student(fName, lName, phone));

            input = Console.ReadLine().Split();
        }

        foreach (var student in students.Where(x => x.PhoneNumber.StartsWith("02") || x.PhoneNumber.StartsWith("+3592")))
        {
            Console.WriteLine($"{student.FirstName} {student.LastName}");
        }
    }
}

public class Student
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string PhoneNumber { get; set; }

    public Student(string fName, string lName, string phone)
    {
        this.FirstName = fName;
        this.LastName = lName;
        this.PhoneNumber = phone;
    }
}
