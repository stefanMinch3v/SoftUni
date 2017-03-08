using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class AverageGrades
{
    public static void Main(string[] args)
    {
        int input = int.Parse(Console.ReadLine());

        List<Student> students = new List<Student>();

        for (int i = 0; i < input; i++)
        {
            string[] command = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string name = command[0];
            List<double> grades = command.Skip(1).Select(x => double.Parse(x)).ToList();

            Student student = new Student(name);
            student.Grades.AddRange(grades);
            students.Add(student);
        }

        var orderedStudents = students.Where(s => s.Grades.Average() >= 5.00).OrderBy(s => s.Name).ThenByDescending(n => n.Grades.Average());

        foreach (var studn in orderedStudents)
        {
            Console.WriteLine($"{studn.Name} -> {studn.Grades.Average():f2}");
        }
    }

}

class Student
{
    public string Name { get; set; }
    public List<double> Grades { get; set; }

    public Student(string name)
    {
        Name = name;
        Grades = new List<double>();
    }
}
