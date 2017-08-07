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
        Type personType = typeof(Person);
        FieldInfo[] fields = personType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
        MethodInfo[] methods = personType.GetMethods(BindingFlags.Public | BindingFlags.Instance);

        if (fields.Length != 1 || methods.Length != 5)
        {
            throw new Exception();
        }

        string personName = Console.ReadLine();
        Person person = new Person(personName);
        Console.WriteLine(person.SayHello());
    }
}

