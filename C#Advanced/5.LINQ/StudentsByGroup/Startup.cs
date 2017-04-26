using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Startup
{
    public static void Main()
    {
        Dictionary<int, List<Student>> students = new Dictionary<int, List<Student>>();
        string[] input = Console.ReadLine().Split();

        while (!input.Contains("END"))
        {
            string firstName = input[0];
            string lastName = input[1];
            int group = int.Parse(input[2]);

            if (!students.ContainsKey(group))
            {
                students.Add(group, new List<Student>());
            }
            students[group].Add(new Student(firstName, lastName));


            input = Console.ReadLine().Split();
        }

        foreach (var kvp in students.Where(group => group.Key == 2))
        {
            foreach (var entry in kvp.Value.OrderBy(x => x.FirstName))
            {
                string fName = entry.FirstName;
                string lName = entry.LastName;
                Console.WriteLine($"{fName} {lName}");
            }
        }

    }
}

public class Student
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public Student(string fName, string lName)
    {
        this.FirstName = fName;
        this.LastName = lName;
    }
}
