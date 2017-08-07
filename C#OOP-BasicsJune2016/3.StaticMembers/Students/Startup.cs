using System;

public class Startup
{
    public static void Main()
    {
        string name = Console.ReadLine();
        while (name != "End")
        {
            Student st = new Student(name);
            name = Console.ReadLine();
        }
        Console.WriteLine(Student.countStudents);
    }
}
