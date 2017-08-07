using System;
using System.Collections.Generic;
using System.Linq;

namespace CompareTwoCards
{
    public class Startup
    {
        public static void Main()
        {
            SortedSet<Card> cardSet = new SortedSet<Card>(new CardsComparer());

            for (int i = 0; i < 2; i++)
            {
                string inputRank = Console.ReadLine();
                string inputSuit = Console.ReadLine();

                var cardRanks = Enum.GetValues(typeof(CardRank)).OfType<CardRank>().ToList();
                var cardSuits = Enum.GetValues(typeof(CardSuits)).OfType<CardSuits>().ToList();

                var firstCardRanking = cardRanks.FirstOrDefault(c => c.ToString() == inputRank);
                var firstCardSuit = cardSuits.FirstOrDefault(c => c.ToString() == inputSuit);

                if (firstCardRanking.ToString() == inputRank && firstCardSuit.ToString() == inputSuit)
                {
                    int result = (int)firstCardRanking + (int)firstCardSuit;
                    Card card = new Card(firstCardRanking.ToString(), firstCardSuit.ToString(), result);
                    cardSet.Add(card);
                }
            }

            Console.WriteLine(string.Join("", cardSet.Take(1)));
        }
    }
}
