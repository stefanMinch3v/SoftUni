using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControlSecondWay
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            List<IIdentifiable> entrants = new List<IIdentifiable>();
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] commandLine = input.Split();
                if (commandLine.Length == 3)
                {
                    Citizen citizen = new Citizen(commandLine[0], int.Parse(commandLine[1]), commandLine[2]);
                    entrants.Add(citizen);
                }
                else if (commandLine.Length == 2)
                {
                    Robot robot = new Robot(commandLine[0], commandLine[1]);
                    entrants.Add(robot);
                }

                input = Console.ReadLine();
            }

            string fakeId = Console.ReadLine();

            var currentEntrant = entrants.Where(x => x.Id.EndsWith(fakeId));
            Console.WriteLine(string.Join(Environment.NewLine, currentEntrant));
        }
    }
}
