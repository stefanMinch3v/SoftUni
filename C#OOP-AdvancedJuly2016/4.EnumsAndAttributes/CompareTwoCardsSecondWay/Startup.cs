namespace CompareTwoCardsSecondWay
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            SortedSet<Card> cards = new SortedSet<Card>();

            for (int i = 0; i < 2; i++)
            {
                var cardRank = Console.ReadLine();
                var cardSuit = Console.ReadLine();

                CardRank rank = (CardRank)Enum.Parse(typeof(CardRank), cardRank);
                CardSuits suit = (CardSuits)Enum.Parse(typeof(CardSuits), cardSuit);

                Card card = new Card(rank, suit);
                cards.Add(card);
            }

            Console.WriteLine(string.Join(Environment.NewLine, cards.Max));
        }
    }
}
