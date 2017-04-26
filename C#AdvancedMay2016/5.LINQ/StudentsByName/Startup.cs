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
            students.Add(new Student(fName, lName));

            input = Console.ReadLine().Split();
        }

        foreach (var student in students.Where(x => string.Compare(x.FirstName, x.LastName) < 0))
        {
            Console.WriteLine($"{student.FirstName} {student.LastName}");
        }
    }
}

public class Student
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public Student(string fName, string lName)
    {
        this.FirstName = fName;
        this.LastName = lName;
    }
}
