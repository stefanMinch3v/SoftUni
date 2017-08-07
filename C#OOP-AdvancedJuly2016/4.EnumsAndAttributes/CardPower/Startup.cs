using System;
using System.Linq;

namespace CardPower
{
    public class Startup
    {
        public static void Main()
        {
            string inputRank = Console.ReadLine();
            string inputSuit = Console.ReadLine();

            var cardRanks = Enum.GetValues(typeof(CardRank)).OfType<CardRank>().ToList();
            var cardSuits = Enum.GetValues(typeof(CardSuits)).OfType<CardSuits>().ToList();

            var firstCardRanking = cardRanks.FirstOrDefault(c => c.ToString() == inputRank);
            var firstCardSuit = cardSuits.FirstOrDefault(c => c.ToString() == inputSuit);

            if (firstCardRanking.ToString() == inputRank && firstCardSuit.ToString() == inputSuit)
            {
                Card card = new Card(firstCardRanking.ToString(), firstCardSuit.ToString());
                int result = (int)firstCardRanking + (int)firstCardSuit;

                Console.WriteLine($"{card} {result}");
            }
        }
    }
}
