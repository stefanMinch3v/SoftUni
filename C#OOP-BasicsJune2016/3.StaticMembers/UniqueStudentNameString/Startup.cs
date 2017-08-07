using System;

public class Startup
{
    public static void Main()
    {
        string name = Console.ReadLine();
        while (name != "End")
        {
            //Student student = new Student(name);
            Student.uniqueNames.Add(name);

            name = Console.ReadLine();
        }
        Console.WriteLine(Student.uniqueNames.Count);
    }
}
