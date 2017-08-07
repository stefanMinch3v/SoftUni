using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    public static void Main()
    {
        int num = int.Parse(Console.ReadLine());
        List<Person> students = new List<Person>();

        for (int i = 0; i < num; i++)
        {
            var commandLine = Console.ReadLine().Split();
            string name = commandLine[0];
            int age = int.Parse(commandLine[1]);
            var person = new Person(name, age);
            students.Add(person);
        }

        foreach (var item in students.Where(x => x.Age > 30).OrderBy(x => x.Name))
        {
            Console.WriteLine($"{item.Name} - {item.Age}");
        }
    }
}
