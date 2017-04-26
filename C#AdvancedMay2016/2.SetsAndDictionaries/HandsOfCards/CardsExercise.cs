using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CardsExercise
{
    public static void Main(string[] args)
    {
        Dictionary<string, List<string>> playerCards = new Dictionary<string, List<string>>();

        string commandLine = Console.ReadLine();

        while (!commandLine.Equals("JOKER"))
        {
            string[] commandArgs = commandLine.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            string playerName = commandArgs[0];
            string[] cards = commandArgs[1].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(c => c.Trim()).ToArray();

            if (!playerCards.ContainsKey(playerName))
            {
                playerCards.Add(playerName, new List<string>());
            }

            playerCards[playerName].AddRange(cards);

            commandLine = Console.ReadLine();
        }
        PrintPlayerScores(playerCards);
    }

    private static void PrintPlayerScores(Dictionary<string, List<string>> playerCards)
    {
        foreach (var entry in playerCards)
        {
            string playerName = entry.Key;
            List<string> cards = entry.Value.Distinct().ToList();

            int sum = 0;
            foreach (var card in cards)
            {
                string rank = card.Substring(0, card.Length - 1);
                string suite = card.Substring(card.Length - 1);

                int rankPower = GetRank(rank);
                int suitPower = GetSuite(suite);

                sum += rankPower * suitPower;
            }
            Console.WriteLine(playerName + ": " + sum);
        }
    }

    private static int GetSuite(string suite)
    {
        switch (suite)
        {
            case "S":
                return 4;
            case "H":
                return 3;
            case "D":
                return 2;
            case "C":
                return 1;
            default:
                return 1;
                break;
        }
    }

    private static int GetRank(string rank)
    {
        switch (rank)
        {
            case "2":
                return 2;
            case "3":
                return 3;
            case "4":
                return 4;
            case "5":
                return 5;
            case "6":
                return 6;
            case "7":
                return 7;
            case "8":
                return 8;
            case "9":
                return 9;
            case "10":
                return 10;
            case "J":
                return 11;
            case "Q":
                return 12;
            case "K":
                return 13;
            case "A":
                return 14;
            default:
                return 1;
                break;
        }
    }
}
