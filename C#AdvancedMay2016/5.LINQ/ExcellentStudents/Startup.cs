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
        string input = Console.ReadLine();
        List<string> students = new List<string>();

        while (input != "END")
        {
            students.Add(input);
            input = Console.ReadLine();
        }
        var result = students.Select(x => x.Split()).Where(x => x.Contains("6")).ToList();

        foreach (var student in result)
        {
            Console.WriteLine(string.Join(" ", student[0], student[1]));
        }
        //string input = Console.ReadLine();
        //List<Student> students = new List<Student>();
        //List<double> studentMarks = new List<double>();
        //List<double> final = new List<double>();

        //string saveMarks = string.Empty;
        //string saveNames = string.Empty;

        //while (!input.Contains("END"))
        //{
        //    string patternName = @"([a-zA-Z]+\s[a-zA-Z]+)";
        //    string patternMarks = @"\s([\d\s]+)";

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

        //    studentMarks = saveMarks.Split().Select(double.Parse).ToList();

        //    var splitInput = saveNames.Split();
        //    string fName = splitInput[0];
        //    string lName = splitInput[1];
        //    final.AddRange(studentMarks);

        //    students.Add(new Student(fName, lName, final));

        //    final.Clear();
        //    input = Console.ReadLine();
        //}

        //foreach (var student in students.Where(x => x.Marks.Any(y => y == 6)))
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

