using System;
using System.Collections.Generic;

namespace BirthdayCelebrations
{
    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            List<IBirthdate> entrantsBirthdate = new List<IBirthdate>();

            while (input != "End")
            {
                string[] commandLine = input.Split();
                string firstCommand = commandLine[0];

                switch (firstCommand)
                {
                    case "Citizen":
                        string name = commandLine[1];
                        int age = int.Parse(commandLine[2]);
                        string id = commandLine[3];
                        string birthdate = commandLine[4];
                        entrantsBirthdate.Add(new Citizen(name, age, id, birthdate));
                        break;
                    case "Pet":
                        string petName = commandLine[1];
                        string birth = commandLine[2];
                        entrantsBirthdate.Add(new Pet(petName, birth));
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }

            PrintBirthdates(entrantsBirthdate);
        }

        private static void PrintBirthdates(List<IBirthdate> entrantsBirthdate)
        {
            string desiredYear = Console.ReadLine();

            foreach (var entrant in entrantsBirthdate)
            {
                if (entrant.Birthdate.Substring(entrant.Birthdate.Length - desiredYear.Length) == desiredYear)
                {
                    Console.WriteLine(entrant.Birthdate);
                }
            }
        }
    }
}
