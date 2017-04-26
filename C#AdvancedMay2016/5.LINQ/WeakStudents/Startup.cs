using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class Startup
{
    public static void Main()
    {
        List<string[]> students = new List<string[]>();
        string input = Console.ReadLine();

        while(input != "END")
        {
            string[] studentDetails = input.Split();
            students.Add(studentDetails);

            input = Console.ReadLine();
        }

        students
            .Where(x => x.Skip(2)
            .Count(y => int.Parse(y) <= 3) >= 2)
            .ToList()
            .ForEach
            (
                x => Console.WriteLine($"{x[0]} {x[1]}")
            );
        //string input = Console.ReadLine();
        //List<Student> students = new List<Student>();
        //List<double> studentMarks = new List<double>();

        //string saveMarks = string.Empty;
        //string saveNames = string.Empty;

        //while (!input.Contains("END"))
        //{
        //    string patternName = @"([a-zA-Z]+\s[a-zA-Z]+)";// take only digits separated by empty space
        //    string patternMarks = @"\s([\d\s]+)"; // take the words

        //    Regex regexMark = new Regex(patternMarks);
        //    Regex regexName = new Regex(patternName);

        //    MatchCollection matchCollection = regexMark.Matches(input);
        //    MatchCollection matchCollection2 = regexName.Matches(input);

        //    foreach (Match match in matchCollection)
        //    {
        //        saveMarks = ((match.Groups[1].ToString()));
        //    }

        //    foreach (Match match in matchCollection2)
        //    {
        //        saveNames = ((match.Groups[1].ToString()));
        //    }

        //    studentMarks.AddRange(saveMarks.Split().Select(double.Parse).ToList());

        //    string[] splitInput = saveNames.Split();
        //    string fName = splitInput[0];
        //    string lName = splitInput[1];

        //    students.Add(new Student(fName, lName, studentMarks));

        //    studentMarks.Clear();
        //    input = Console.ReadLine();
        //}

        //foreach (var student in students.Where(x => x.Marks.Any(y => y <= 3) && x.Marks.Any(y => y <= 3)))
        //{
        //    Console.WriteLine($"{student.FirstName} {student.LastName}");
        //}
    }
}

public class Student
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public List<double> Marks { get; set; } = new List<double>();

    public Student(string fName, string lName, List<double> marks)
    {
        this.FirstName = fName;
        this.LastName = lName;
        Marks.AddRange(marks);
    }
}