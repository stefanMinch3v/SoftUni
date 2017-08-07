using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Alive> entrants = new List<Alive>();
            Alive person = null;

            while (input != "End")
            {
                string[] commandLine = input.Split();
                string humanOrRobot = commandLine[0];

                bool isHuman = CheckHumanOrRobot(humanOrRobot);

                if (isHuman)
                {
                    string name = commandLine[0];
                    int age = int.Parse(commandLine[1]);
                    string id = commandLine[2];
                    person = new Citizen(name, age, id);
                    entrants.Add(person);
                }
                else
                {
                    string model = commandLine[0];
                    string id = commandLine[1];
                    person = new Robot(model, id);
                    entrants.Add(person);
                }

                input = Console.ReadLine();
            }

            PrintFakeIds(entrants);
        }

        private static void PrintFakeIds(List<Alive> entrants)
        {
            string fakeId = Console.ReadLine();

            foreach (var entrant in entrants)
            {
                string currentEntrant = entrant.Id.Substring(entrant.Id.Length - fakeId.Length);
                if (fakeId == currentEntrant)
                {
                    Console.WriteLine(entrant.Id);
                }
            }
        }

        private static bool CheckHumanOrRobot(string humanOrRobot)
        {
            bool isHuman = humanOrRobot.All(p => !char.IsDigit(p));
            return isHuman;
        }
    }
}
