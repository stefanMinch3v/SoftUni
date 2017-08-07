namespace CardSuit
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            if (input == "Card Suits")
            {
                var values = Enum.GetValues(typeof(CardSuits));
                Console.WriteLine("Card Suits:");
                foreach (var card in values)
                {
                    Console.WriteLine($"Ordinal value: {(int)card}; Name value: {card}");
                }
            }
        }
    }
}
