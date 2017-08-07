using System;
using System.Reflection;

public class Startup
{
    public static void Main()
    {
        var firstPerson = new Person
        {
            name = "Pesho",
            age = 20
        };

        var secondPerson = new Person();
        secondPerson.name = "Gosho";
        secondPerson.age = 18;

        var thirdPerson = new Person
        {
            name = "Stamat",
            age = 43
        };

        Type personType = typeof(Person);
        FieldInfo[] fields = personType.GetFields(BindingFlags.Public | BindingFlags.Instance);
        Console.WriteLine(fields.Length);
    }
}
