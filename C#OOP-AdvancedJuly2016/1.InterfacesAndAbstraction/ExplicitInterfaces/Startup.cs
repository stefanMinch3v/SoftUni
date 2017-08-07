using System;

namespace ExplicitInterfaces
{
    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] commandLine = input.Split();
                string name = commandLine[0];
                string country = commandLine[1];
                int age = int.Parse(commandLine[2]);

                Citizen citizen = new Citizen(name, country, age);

                IPerson person = citizen;
                Console.WriteLine(person.GetName());

                IResident resident = citizen;
                Console.WriteLine(resident.GetName());

                input = Console.ReadLine();
            }
        }
    }
}
