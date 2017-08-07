namespace CardGameSecondWay
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var firstPlayer = Console.ReadLine();
            var secondPlayer = Console.ReadLine();

            var firstPlayerCards = new List<Card>();
            var secondPlayerCards = new List<Card>();

            var originalDeck = new List<string>();
            var playableDeck = new List<string>();

            var cardRanks = Enum.GetValues(typeof(CardRank));
            var cardSuits = Enum.GetValues(typeof(CardSuits));

            foreach (CardSuits suit in cardSuits)
            {
                foreach (CardRank rank in cardRanks)
                {
                    originalDeck.Add(string.Format($"{rank} of {suit}"));
                    playableDeck.Add(string.Format($"{rank} of {suit}"));
                }
            }

            for (int i = 0; i < 5; i++)
            {
                try
                {
                    var inputCard = Console.ReadLine();
                    CreatePlayersHands(firstPlayerCards, originalDeck, playableDeck, inputCard);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    i--;
                }
            }

            for (int i = 0; i < 5; i++)
            {
                try
                {
                    var inputCard = Console.ReadLine();
                    CreatePlayersHands(secondPlayerCards, originalDeck, playableDeck, inputCard);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    i--;
                }
            }

            PrintWinner(firstPlayer, secondPlayer, firstPlayerCards, secondPlayerCards);

        }

        private static void PrintWinner(string firstPlayer, string secondPlayer, List<Card> firstPlayerCards, List<Card> secondPlayerCards)
        {
            int maxFirstPlayerCard = firstPlayerCards.Max(c => c.Power);
            var objectFirstPlayerCard = firstPlayerCards.Find(c => c.Power == maxFirstPlayerCard);

            int maxSecondPlayerCard = secondPlayerCards.Max(c => c.Power);
            var objectSecondPlayerCard = secondPlayerCards.Find(c => c.Power == maxSecondPlayerCard);

            if (maxFirstPlayerCard > maxSecondPlayerCard)
            {
                Console.WriteLine(string.Format($"{firstPlayer} wins with {objectFirstPlayerCard}."));
            }
            else
            {
                Console.WriteLine(string.Format($"{secondPlayer} wins with {objectSecondPlayerCard}."));
            }
        }

        private static void CreatePlayersHands(List<Card> listOfCards, List<string> originalDeck, List<string> playableDeck, string inputCard)
        {
            if (originalDeck.Contains(inputCard))
            {
                if (playableDeck.Contains(inputCard))
                {
                    var commandLine = inputCard.Split();
                    string rank = commandLine[0];
                    string suit = commandLine[2];

                    Card card = new Card((CardRank)Enum.Parse(typeof(CardRank), rank), (CardSuits)Enum.Parse(typeof(CardSuits), suit));
                    listOfCards.Add(card);
                    playableDeck.Remove(inputCard);
                }
                else
                {
                    throw new ArgumentException("Card is not in the deck.");
                }
            }
            else
            {
                throw new ArgumentException("No such card exists.");
            }
        }
    }
}
