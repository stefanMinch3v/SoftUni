using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Startup
{
    public static void Main()
    {
        string[] input = Console.ReadLine().Split();
        List<Student> students = new List<Student>();

        while (! input.Contains("END"))
        {
            string firstName = input[0];
            string lastName = input[1];
            int group = int.Parse(input[2]);

            students.Add(new Student(firstName, lastName, group));

            input = Console.ReadLine().Split();
        }

        var groupStudents = students.OrderBy(x => x.groupName).GroupBy(st => st.groupName).ToList();
        foreach (var group in groupStudents)
        {
            Console.WriteLine("{0} - {1}", group.Key, string.Join(", ", group)); //<<<<<<<
        }
    }
}

public class Student
{
    public string firstName { get; set; }

    public string lastName { get; set; }

    public int groupName { get; set; }
    
    public Student(string fName, string lName, int groupName)
    {
        this.firstName = fName;
        this.lastName = lName;
        this.groupName = groupName;
    }

    public override string ToString() // <<<<<<<
    {
        return firstName + " " + lastName;
    }
}
