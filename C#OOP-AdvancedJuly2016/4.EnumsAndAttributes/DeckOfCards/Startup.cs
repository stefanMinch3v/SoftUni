namespace DeckOfCards
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            List<Card> playCards = new List<Card>();

            var input = Console.ReadLine();
            if (input == "Card Deck")
            {
                var cardRank = Enum.GetValues(typeof(CardRank)).OfType<CardRank>().ToList();
                var cardSuit = Enum.GetValues(typeof(CardSuits)).OfType<CardSuits>().ToList();
                

                for (int i = 0; i < cardSuit.Count; i++)
                {
                    for (int j = 0; j < cardRank.Count; j++)
                    {
                        Card card = new Card(cardRank[j].ToString(), cardSuit[i].ToString());
                        playCards.Add(card);
                    }
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, playCards));
        }
    }
}
