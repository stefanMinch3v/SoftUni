using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Practise
{
    public static void Main(string[] args)
    {
        int input = int.Parse(Console.ReadLine());
        List<Student> students = new List<Student>();
         
        for (int i = 0; i < input; i++)
        {
            string[] studen = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string name = studen[0];
            List<double> grade = studen.Skip(1).Select(x => double.Parse(x)).ToList();

            Student student = new Student(name);
            student.Grades.AddRange(grade);
            students.Add(student);
        }

        var finalResult = students.Where(s => s.Grades.Average() >= 5.00).OrderBy(n => n.Name).ThenByDescending(n => n.Grades.Average());

        foreach (var item in finalResult)
        {
            Console.WriteLine($"{item.Name} -> {item.Grades.Average():f2}");
        }
    }

}

public class Student
{
    public string Name { get; set; }

    public List<double> Grades { get; set; }

    //public double AverageGrades { get; set; }

    public Student(string name)
    {
        Name = name;
        Grades = new List<double>();
    }
}

