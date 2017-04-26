using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Startup
{
    public static void Main()
    {
        //List<string[]> students = new List<string[]>();
        //string input = Console.ReadLine();
        //while (input != "END")
        //{
        //    string[] studentDetails = input.Split();
        //    students.Add(studentDetails);
        //    input = Console.ReadLine();
        //}
        //students
        //    .Where(x => x[0].EndsWith("14") || x[0].EndsWith("15"))
        //    .ToList()
        //    .ForEach
        //    (
        //        x => Console.WriteLine(string.Join(" ", x.Skip(1)))
        //    );

        string[] input = Console.ReadLine().Split();        
        List<int> grades = new List<int>();
        List<Student> student = new List<Student>();

        while (! input[0].Equals("END"))
        {
            string studentID = input[0];

            for (int i = 1; i < input.Length; i++)
            {
                grades.Add(int.Parse(input[i]));
            }
            
            student.Add(new Student(studentID, grades));
            
            grades.Clear();

            input = Console.ReadLine().Split();
        }

        foreach (var st in student.Where(x => x.StudentId.Substring(4, 2) == "14" || x.StudentId.Substring(4, 2) == "15"))
        {
            Console.WriteLine(string.Join(" ", st.studentGrades));
        }
    }
}

public class Student
{
    public string StudentId { get; set; }

    public List<int> studentGrades = new List<int>();

    public Student (string student, List<int> stGrades)
    {
        this.StudentId = student;
        studentGrades.AddRange(stGrades);
    }
}
