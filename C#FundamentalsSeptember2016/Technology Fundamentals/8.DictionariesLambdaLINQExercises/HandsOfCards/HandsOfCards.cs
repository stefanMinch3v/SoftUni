using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOfCards
{
    public class HandsOfCards
    {
        public static void Main()
        {
            /* My solution of the problem
            Dictionary<string, List<string>> allUsersAndCards = new Dictionary<string, List<string>>();

            Dictionary<string, int> cardPower = new Dictionary<string, int>();
            cardPower.Add("2", 2);
            cardPower.Add("3", 3);
            cardPower.Add("4", 4);
            cardPower.Add("5", 5);
            cardPower.Add("6", 6);
            cardPower.Add("7", 7);
            cardPower.Add("8", 8);
            cardPower.Add("9", 9);
            cardPower.Add("10", 10);
            cardPower.Add("J", 11);
            cardPower.Add("Q", 12);
            cardPower.Add("K", 13);
            cardPower.Add("A", 14);

            Dictionary<string, int> cardType = new Dictionary<string, int>();
            cardType.Add("C", 1);
            cardType.Add("D", 2);
            cardType.Add("H", 3);
            cardType.Add("S", 4);

            string readConsole = Console.ReadLine();

            while (!readConsole.Equals("JOKER"))
            {
                string[] input = readConsole.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string playerName = input[0];
                string[] cards = input[1].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(c => c.Trim()).Distinct().ToArray();
                
                if (!allUsersAndCards.ContainsKey(playerName))
                {
                    allUsersAndCards.Add(playerName, new List<string>());
                }

                allUsersAndCards[playerName].AddRange(cards);
           
                readConsole = Console.ReadLine();
            }
            
            foreach (var entry in allUsersAndCards)
            {
                string playerName = entry.Key;
                List<string> cards = entry.Value.Distinct().ToList();
                long sumPower = 0;
                long sumType = 0;
                long sumAll = 0;

                foreach (var card in cards)
                {
                    var power = card.Substring(0, card.Length - 1);
                    var suit = card.Substring(card.Length - 1);

                    if (cardPower.ContainsKey(power))
                    {
                        sumPower = cardPower[power];
                    }
                    if (cardType.ContainsKey(suit))
                    {
                        sumType = cardType[suit];
                    }
                    sumAll += sumPower * sumType;
                }
                Console.WriteLine("{0}: {1}", playerName, sumAll);
            }
            */
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
}
