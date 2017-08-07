using System;

namespace CardRankEx
{
    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            if (input == "Card Ranks")
            {
                var values = Enum.GetValues(typeof(CardRank));
                Console.WriteLine("Card Ranks:");
                foreach (var card in values)
                {
                    Console.WriteLine($"Ordinal value: {(int)card}; Name value: {card}");
                }
            }
        }
    }
}
