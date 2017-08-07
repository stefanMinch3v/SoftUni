using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

public class Startup
{
    public static void Main()
    {
        MethodInfo oldestMemberMethod = typeof(Family).GetMethod("GetOldestMember");
        MethodInfo addMemberMethod = typeof(Family).GetMethod("AddMember");
        if (oldestMemberMethod == null || addMemberMethod == null)
        {
            throw new Exception();
        }

        Family family = new Family();

        int rows = int.Parse(Console.ReadLine());
        for (int i = 0; i < rows; i++)
        {
            string[] commandLine = Console.ReadLine().Split();
            string personName = commandLine[0];
            int personAge = int.Parse(commandLine[1]);
            Person person = new Person(personName, personAge);
            family.AddMember(person);
        }
        foreach (var person in family.GetOldestMember())
        {
            Console.WriteLine($"{person.GetName} {person.GetAge}");
        }
        
        
    }
}
