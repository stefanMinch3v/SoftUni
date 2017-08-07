namespace KingsGambit
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            Dictionary<string, Soldier> uniqueSoldiers = new Dictionary<string, Soldier>();
            King king = new King(Console.ReadLine());

            string[] guards = Console.ReadLine().Split();
            foreach (var guardName in guards)
            {
                var royalGuard = new RoyalGuard(guardName);
                PutUniqueSoldiers(uniqueSoldiers, guardName, royalGuard);
                king.KingAttacked += royalGuard.KingUnderAttack;
            }

            string[] footman = Console.ReadLine().Split();
            foreach (var footmanName in footman)
            {
                var currentFootman = new Footman(footmanName);
                PutUniqueSoldiers(uniqueSoldiers, footmanName, currentFootman);
                king.KingAttacked += currentFootman.KingUnderAttack;
            }

            string inputCommand = Console.ReadLine();
            while (inputCommand != "End")
            {
                string[] commandLine = inputCommand.Split();
                string command = commandLine[0];
                string desiredSoliderToRemove = commandLine[1];
                switch (command)
                {
                    case "Attack":
                        king.RespondAttack();
                        break;
                    case "Kill":
                        Soldier removeSoldier = uniqueSoldiers[desiredSoliderToRemove];
                        king.KingAttacked -= removeSoldier.KingUnderAttack;
                        uniqueSoldiers.Remove(desiredSoliderToRemove);
                        break;
                    default:
                        break;
                }

                inputCommand = Console.ReadLine();
            }

        }

        private static void PutUniqueSoldiers(Dictionary<string, Soldier> uniqueSoldiers, string soldierName, Soldier royalGuard)
        {
            if (!uniqueSoldiers.ContainsKey(soldierName))
            {
                uniqueSoldiers.Add(soldierName, royalGuard);
            }
        }
    }
}
