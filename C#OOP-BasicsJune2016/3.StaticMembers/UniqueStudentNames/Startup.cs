using System;

public class Startup
{
    public static void Main()
    {
        string input = Console.ReadLine();
        while (input != "End")
        {
            Student st = new Student(input);
            Student.uniqueStudents.Add(st);
            input = Console.ReadLine();
        }

        Console.WriteLine(Student.uniqueStudents.Count);
    }
}
