using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Startup
{
    public static void Main()
    {
        List<Person> persons = new List<Person>();
        Person person = null;

        string input = Console.ReadLine();
        while (input != "END")
        {
            string[] commandLine = input.Split();
            string name = commandLine[0];
            int age = int.Parse(commandLine[1]);
            string occupation = commandLine[2];
            person = new Person(name, age, occupation);
            persons.Add(person);

            input = Console.ReadLine();
        }

        foreach (var item in persons.OrderBy(x => x.GetAge))
        {
            Console.WriteLine(item.ToString());
        }
    }
}
