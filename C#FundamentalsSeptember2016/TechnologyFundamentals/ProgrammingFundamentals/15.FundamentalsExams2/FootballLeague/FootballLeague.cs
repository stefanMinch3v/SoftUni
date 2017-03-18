using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class FootballLeague
{
    public static void Main(string[] args)
    {
        string key = Console.ReadLine();
        string inputLine = Console.ReadLine();
        Dictionary<string, int> leagueStandings = new Dictionary<string, int>();
        Dictionary<string, int> leagueTopScores = new Dictionary<string, int>();

        while (! inputLine.Equals("final"))
        {
            string[] userLine = inputLine.Split();
            string[] scores = userLine[2].Split(':');

            string firstTeam = userLine[0];
            string secondTeam = userLine[1];
            int firstTeamScore = int.Parse(scores[0]);
            int secondTeamScore = int.Parse(scores[1]);

            string decryptedFirstTeam = GetEncryptedTeam(firstTeam, key);
            string decryptedSecondTeam = GetEncryptedTeam(secondTeam, key);

            firstTeam = GetReversedTeam(decryptedFirstTeam);
            secondTeam = GetReversedTeam(decryptedSecondTeam);

            SetTopScores(leagueTopScores, firstTeam, firstTeamScore);
            SetTopScores(leagueTopScores, secondTeam, secondTeamScore);

            SetLeagueStandings(leagueStandings, firstTeam, firstTeamScore, secondTeam, secondTeamScore);

            inputLine = Console.ReadLine();
        }

        PrintFinalResults(leagueStandings, leagueTopScores);
    }

    private static void PrintFinalResults(Dictionary<string, int> leagueStandings, Dictionary<string, int> leagueTopScores)
    {
        var leagueStandingInOrder = leagueStandings.OrderByDescending(v => v.Value).ThenBy(k => k.Key);
        int countPosition = 1;
        Console.WriteLine("League standings:");
        foreach (var item in leagueStandingInOrder)
        {
            Console.WriteLine($"{countPosition}. {item.Key} {item.Value}");
            countPosition++;
        }
        Console.WriteLine("Top 3 scored goals:");
        var leagueTopScoreInOrder = leagueTopScores.OrderByDescending(v => v.Value).ThenBy(k => k.Key);//.Take(3) instead of countTop3
        int countTop3 = 0;
        foreach (var item in leagueTopScoreInOrder)
        {
            countTop3++;
            Console.WriteLine($"- {item.Key} -> {item.Value}");
            if (countTop3 == 3)
            {
                break;
            }
        }
    }

    private static void SetLeagueStandings(Dictionary<string, int> leagueStandings, string firstTeam, int firstTeamScore, string secondTeam, int secondTeamScore)
    {
        if (firstTeamScore > secondTeamScore)
        {
            firstTeamScore = 3;
            secondTeamScore = 0;
        }
        else if (firstTeamScore < secondTeamScore)
        {
            secondTeamScore = 3;
            firstTeamScore = 0;
        }
        else
        {
            secondTeamScore = 1;
            firstTeamScore = 1;
        }

        if (! leagueStandings.ContainsKey(firstTeam))
        {
            leagueStandings.Add(firstTeam, firstTeamScore);
        }
        else
        {
            leagueStandings[firstTeam] += firstTeamScore;
        }

        if (!leagueStandings.ContainsKey(secondTeam))
        {
            leagueStandings.Add(secondTeam, secondTeamScore);
        }
        else
        {
            leagueStandings[secondTeam] += secondTeamScore;
        }
    }

    private static void SetTopScores(Dictionary<string, int> leagueTopScores, string teamName, int teamScore)
    {
        if (! leagueTopScores.ContainsKey(teamName))
        {
            leagueTopScores.Add(teamName, 0);
        }
        leagueTopScores[teamName] += teamScore;
    }

    private static string GetReversedTeam(string decryptTeam)
    {
        char[] charArray = decryptTeam.ToUpper().ToCharArray();
        Array.Reverse(charArray);
        string result = string.Join("", charArray);
        return result;
    }

    private static string GetEncryptedTeam(string teamName, string key)
    {
        int startIndex = teamName.IndexOf(key) + key.Length;
        int endIndex = teamName.LastIndexOf(key);
        int length = Math.Abs(startIndex - endIndex);
        string result = teamName.Substring(startIndex, length);
        return result;
    }
}

