using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    public static void Main()
    {
        string input = Console.ReadLine();
        List<Team> dreamTeam = new List<Team>();
        Team team = null;

        while (!input.Contains("END"))
        {
            try
            {
                string[] commandLine = input.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                switch (commandLine.Length)
                {
                    case 2:
                        string firstCommand = commandLine[0];
                        if (firstCommand == "Team")
                        {
                            string teamName = commandLine[1];
                            team = new Team(teamName);
                            dreamTeam.Add(team);
                        }
                        else if (firstCommand == "Rating")
                        {
                            string teamName = commandLine[1];
                            if (dreamTeam.Any(x => x.Name == teamName))
                            {
                                Console.WriteLine($"{team.Name} - {team.TeamRating():F0}");
                            }
                            else
                            {
                                throw new ArgumentException($"Team {teamName} does not exist.");
                            }
                        }
                        break;
                    case 3:
                        if (commandLine[0] == "Remove")
                        {
                            string teamName = commandLine[1];
                            if (dreamTeam.Any(x => x.Name == teamName))
                            {
                                string playerName = commandLine[2];
                                var currentTeam = dreamTeam.First(t => t.Name == teamName);
                                currentTeam.RemovePlayer(playerName);
                            }
                            else
                            {
                                throw new ArgumentException($"Team {teamName} does not exist.");
                            }
                        }
                        break;
                    case 8:
                        if (commandLine[0] == "Add")
                        {
                            string teamName = commandLine[1];
                            if (dreamTeam.Any(x => x.Name == teamName))
                            {
                                var currentTeam = dreamTeam.First(t => t.Name == teamName);
                                string playerName = commandLine[2];
                                double endurance = double.Parse(commandLine[3]);
                                double sprdouble = double.Parse(commandLine[4]);
                                double dribble = double.Parse(commandLine[5]);
                                double passing = double.Parse(commandLine[6]);
                                double shooting = double.Parse(commandLine[7]);
                                Player player = new Player(playerName, endurance, sprdouble, dribble, passing, shooting);
                                currentTeam.AddPlayer(player);
                            }
                            else
                            {
                                throw new ArgumentException($"Team {teamName} does not exist.");
                            }
                        }
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                input = Console.ReadLine();
            }
            
        }
        
    }
}
