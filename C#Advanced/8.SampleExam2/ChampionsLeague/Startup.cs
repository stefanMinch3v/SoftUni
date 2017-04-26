using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Startup
{
    public static void Main()
    {
        Dictionary<string, Dictionary<string, int>> champLeague = new Dictionary<string, Dictionary<string, int>>();

        string input = Console.ReadLine();

        while (input != "stop")
        {
            string[] commandLine = input.Split('|');
            string team1 = commandLine[0].Trim();
            string team2 = commandLine[1].Trim();

            string[] scores1 = commandLine[2].Split(':');
            int team1GoalsHome = int.Parse(scores1[0]);
            int team2GoalsAway = int.Parse(scores1[1]);

            string[] scores2 = commandLine[3].Split(':');
            int team2GoalsHome = int.Parse(scores2[0]);
            int team1GoalsAway = int.Parse(scores2[1]);

            FilloutAllTeams(champLeague, team1, team2, team1GoalsHome, team2GoalsAway, team1GoalsAway, team2GoalsHome);

            input = Console.ReadLine();
        }
        PrintFinalResult(champLeague);
    }

    private static void PrintFinalResult(Dictionary<string, Dictionary<string, int>> champLeague)
    {

        var orderedDictionary = champLeague
                                    .OrderByDescending(x => x.Value.Values.Sum())
                                    .ThenBy(x => x.Key);// когато опитам с този код ми гърми с "unhandled exception at least one object must be implemented IComparable" 
        foreach (var kvp in orderedDictionary) // трябва тук да е orderedDictionary
        {
            Console.WriteLine(kvp.Key);
            int sum = kvp.Value.Values.Sum();
            foreach (var wins in kvp.Value.Values)
            {
                Console.WriteLine($"- Wins: {sum}");
                break;
            }
            Console.WriteLine($"- Opponents: {string.Join(", ", kvp.Value.Keys.OrderBy(x => x))}");
        }
    }

    private static void FilloutAllTeams(Dictionary<string, Dictionary<string, int>> champLeague, string team1, string team2, int team1GoalsHome, int team2GoalsAway, int team1GoalsAway, int team2GoalsHome)
    {
        int total1 = team1GoalsHome + team1GoalsAway;
        int total2 = team2GoalsHome + team2GoalsAway;

        if (total1 == total2)
        {
            if (team1GoalsAway > team2GoalsAway)
            {
                //team1 wins
                if (!champLeague.ContainsKey(team1))
                {
                    champLeague.Add(team1, new Dictionary<string, int>());
                    champLeague[team1].Add(team2, 1);
                }
                else
                {
                    if (champLeague[team1].ContainsKey(team2))
                    {
                        champLeague[team1][team2] += 1;
                    }
                    else
                    {
                        champLeague[team1].Add(team2, 1);
                    }
                }

                //team2 loses
                if (!champLeague.ContainsKey(team2))
                {
                    champLeague.Add(team2, new Dictionary<string, int>());
                    champLeague[team2].Add(team1, 0);
                }
                else
                {
                    if (champLeague[team2].ContainsKey(team1))
                    {
                        champLeague[team2][team1] += 0;
                    }
                    else
                    {
                        champLeague[team2].Add(team1, 0);
                    }
                }

            }
            else if(team2GoalsAway > team1GoalsAway)
            {
                //team2 wins
                if (!champLeague.ContainsKey(team2))
                {
                    champLeague.Add(team2, new Dictionary<string, int>());
                    champLeague[team2].Add(team1, 1);
                }
                else
                {
                    if (champLeague[team2].ContainsKey(team1))
                    {
                        champLeague[team2][team1] += 1;
                    }
                    else
                    {
                        champLeague[team2].Add(team1, 1);
                    }
                }

                //team1 loses
                if (!champLeague.ContainsKey(team1))
                {
                    champLeague.Add(team1, new Dictionary<string, int>());
                    champLeague[team1].Add(team2, 0);
                }
                else
                {
                    if (champLeague[team1].ContainsKey(team2))
                    {
                        champLeague[team1][team2] += 0;
                    }
                    else
                    {
                        champLeague[team1].Add(team2, 0);
                    }
                }
            }
        }
        else if (total1 > total2)
        {
            //team1 wins
            if (!champLeague.ContainsKey(team1))
            {
                champLeague.Add(team1, new Dictionary<string, int>());
                champLeague[team1].Add(team2, 1);
            }
            else
            {
                if (champLeague[team1].ContainsKey(team2))
                {
                    champLeague[team1][team2] += 1;
                }
                else
                {
                    champLeague[team1].Add(team2, 1);
                }
            }

            //team2 loses
            if (!champLeague.ContainsKey(team2))
            {
                champLeague.Add(team2, new Dictionary<string, int>());
                champLeague[team2].Add(team1, 0);
            }
            else
            {
                if (champLeague[team2].ContainsKey(team1))
                {
                    champLeague[team2][team1] += 0;
                }
                else
                {
                    champLeague[team2].Add(team1, 0);
                }
            }
        }
        else if (total1 < total2)
        {
            //team2 wins
            if (!champLeague.ContainsKey(team2))
            {
                champLeague.Add(team2, new Dictionary<string, int>());
                champLeague[team2].Add(team1, 1);
            }
            else
            {
                if (champLeague[team2].ContainsKey(team1))
                {
                    champLeague[team2][team1] += 1;
                }
                else
                {
                    champLeague[team2].Add(team1, 1);
                }
            }

            //team1 loses
            if (!champLeague.ContainsKey(team1))
            {
                champLeague.Add(team1, new Dictionary<string, int>());
                champLeague[team1].Add(team2, 0);
            }
            else
            {
                if (champLeague[team1].ContainsKey(team2))
                {
                    champLeague[team1][team2] += 0;
                }
                else
                {
                    champLeague[team1].Add(team2, 0);
                }
            }
        }
    }
}
