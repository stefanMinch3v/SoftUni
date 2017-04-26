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
            int age = int.Parse(input[2]);
            students.Add(new Student(fName, lName, age));

            input = Console.ReadLine().Split();
        }

        foreach (var student in students.Where(x => x.Age >= 18 && x.Age <= 24))
        {
            Console.WriteLine($"{student.FirstName} {student.LastName} {student.Age}");
        }
    }
}

public class Student
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public int Age { get; set; }

    public Student(string fName, string lName, int age)
    {
        this.FirstName = fName;
        this.LastName = lName;
        this.Age = age;
    }
}