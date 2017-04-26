using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Startup
{
    public static void Main()
    {
        List<Student> students = new List<Student>();
        string[] input = Console.ReadLine().Split();

        while (!input.Contains("END"))
        {
            string fName = input[0];
            string lName = input[1];
            string email = input[2];
            students.Add(new Student(fName, lName, email));

            input = Console.ReadLine().Split();
        }

        foreach (var student in students.Where(x => x.Email.EndsWith("@gmail.com")))
        {
            Console.WriteLine($"{student.FirstName} {student.LastName}");
        }
    }
}

public class Student
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public Student(string fName, string lName, string mail)
    {
        this.FirstName = fName;
        this.LastName = lName;
        this.Email = mail;
    }
}