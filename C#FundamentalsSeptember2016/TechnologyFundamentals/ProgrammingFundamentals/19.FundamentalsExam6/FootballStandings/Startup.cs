using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class Startup
{
    public static void Main()
    {
        string key = Console.ReadLine();
        string input = Console.ReadLine();
        Dictionary<string, int> leagueStandings = new Dictionary<string, int>();
        Dictionary<string, int> topScores = new Dictionary<string, int>();

        while (input != "final")
        {
            string[] commandLine = input.Split();
            string firstTeam = commandLine[0];
            string secondTeam = commandLine[1];

            int[] scores = commandLine[2].Split(':').Select(int.Parse).ToArray();
            int firstTscore = scores[0];
            int secondTscore = scores[1];

            firstTeam = GetEncryptedTeam(firstTeam, key);
            secondTeam = GetEncryptedTeam(secondTeam, key);

            FilloutLeagueStandings(leagueStandings, firstTeam, firstTscore, secondTeam, secondTscore);
            FilloutTopScores(topScores, firstTeam, firstTscore, secondTeam, secondTscore);

            input = Console.ReadLine();
        }
        PrintResults(leagueStandings, topScores);
    }

    private static void PrintResults(Dictionary<string, int> leagueStandings, Dictionary<string, int> topScores)
    {
        var finalResult = leagueStandings.OrderByDescending(v => v.Value).ThenBy(k => k.Key);
        Console.WriteLine("League standings:");
        int counter = 1;
        foreach (var kvp in finalResult)
        {
            Console.WriteLine($"{counter}. {kvp.Key} {kvp.Value}");
            counter++;
        }

        var finalTopResults = topScores.OrderByDescending(v => v.Value).ThenBy(k => k.Key).Take(3);
        Console.WriteLine("Top 3 scored goals:");
        foreach (var kvp in finalTopResults)
        {
            Console.WriteLine($"- {kvp.Key} -> {kvp.Value}");
        }
    }

    private static void FilloutTopScores(Dictionary<string, int> topScores, string firstTeam, int firstTscore, string secondTeam, int secondTscore)
    {
        if (!topScores.ContainsKey(firstTeam))
        {
            topScores.Add(firstTeam, firstTscore);
        }
        else
        {
            topScores[firstTeam] += firstTscore;
        }

        if (!topScores.ContainsKey(secondTeam))
        {
            topScores.Add(secondTeam, secondTscore);
        }
        else
        {
            topScores[secondTeam] += secondTscore;
        }
    }

    private static void FilloutLeagueStandings(Dictionary<string, int> leagueStandings, string firstTeam, int firstTscore, string secondTeam, int secondTscore)
    {
        int firstResult = 0;
        int secondResult = 0;

        if (firstTscore > secondTscore)
        {
            firstResult = 3;
        }
        else if (firstTscore < secondTscore)
        {
            secondResult = 3;
        }
        else
        {
            firstResult = 1;
            secondResult = 1;
        }

        if (!leagueStandings.ContainsKey(firstTeam))
        {
            leagueStandings.Add(firstTeam, firstResult);
        }
        else
        {
            leagueStandings[firstTeam] += firstResult;
        }

        if (!leagueStandings.ContainsKey(secondTeam))
        {
            leagueStandings.Add(secondTeam, secondResult);
        }
        else
        {
            leagueStandings[secondTeam] += secondResult;
        }

    }

    private static string GetEncryptedTeam(string teamName, string key)
    {
        int startIndex = teamName.IndexOf(key) + key.Length;
        int endIndex = teamName.LastIndexOf(key);
        int length = Math.Abs(startIndex - endIndex);
        string result = teamName.Substring(startIndex, length);
        result = string.Join("", result.ToCharArray().Reverse()).ToUpper();
        return result;
    }
}
