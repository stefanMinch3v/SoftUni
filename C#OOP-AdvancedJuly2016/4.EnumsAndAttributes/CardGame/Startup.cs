namespace CardGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            Dictionary<Player, List<Card>> allPlayers = new Dictionary<Player, List<Card>>();

            var firstPlayer = Console.ReadLine();
            var secondPlayer = Console.ReadLine();

            Player player1 = new Player(firstPlayer);
            Player player2 = new Player(secondPlayer);

            allPlayers.Add(player1, new List<Card>());
            allPlayers.Add(player2, new List<Card>());

            var cardRanks = Enum.GetValues(typeof(CardRank)).OfType<CardRank>().ToList();
            var cardSuits = Enum.GetValues(typeof(CardSuits)).OfType<CardSuits>().ToList();


            for (int i = 0; i < 5; i++)
            {
                try
                {
                    PutPlayersCardsAndPoints(allPlayers, firstPlayer, cardRanks, cardSuits);
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
                    PutPlayersCardsAndPoints(allPlayers, secondPlayer, cardRanks, cardSuits);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            PrintWinner(allPlayers);

        }

        private static void PrintWinner(Dictionary<Player, List<Card>> allPlayers)
        {
            int firstPlayer = 0;
            int secondPlayer = 0;
            int counter = 1;

            foreach (var kvp in allPlayers)
            {
                var key = kvp.Key;
                if (counter == 1)
                {
                    firstPlayer = allPlayers[key].Max(c => c.Power);
                }
                else
                {
                    secondPlayer = allPlayers[key].Max(c => c.Power);
                }
                counter++; 
            }

            foreach (var kvp in allPlayers)
            {
                var player = kvp.Key;
                if (firstPlayer > secondPlayer)
                {
                    var winner = allPlayers.First(x => x.Key.Name == player.Name).Key.Name;
                    Console.WriteLine($"{winner} wins with {string.Join("",kvp.Value.Where(c => c.Power == kvp.Value.Max(p => p.Power)))}.");
                    break;
                }
                else
                {
                    var winner = allPlayers.First(x => x.Key.Name == player.Name).Key.Name;
                    Console.WriteLine($"{winner} wins with {string.Join("", kvp.Value.Where(c => c.Power == kvp.Value.Max(p => p.Power)))}.");
                    break;
                }
            }
        }

        private static void PutPlayersCardsAndPoints(Dictionary<Player, List<Card>> allPlayers, string player, List<CardRank> cardRanks, List<CardSuits> cardSuits)
        {
            var inputCard = Console.ReadLine().Split();
            var rank = inputCard[0];
            var suit = inputCard[2];

            var firstCardRanking = cardRanks.FirstOrDefault(c => c.ToString() == rank);
            var firstCardSuit = cardSuits.FirstOrDefault(c => c.ToString() == suit);

            if (firstCardRanking.ToString() == rank && firstCardSuit.ToString() == suit)
            {
                int power = (int)firstCardRanking + (int)firstCardSuit;
                Card card = new Card(firstCardRanking.ToString(), firstCardSuit.ToString(), power);

                foreach (var key in allPlayers.Keys.Where(x => x.Name == player))
                {
                    if (allPlayers[key].Exists(c => c.Suit == card.Suit && c.Rank == card.Rank))
                    {
                        throw new ArgumentException("Card is not in the deck.");
                    }
                    allPlayers[key].Add(card);
                }
                
            }
            else
            {
                throw new ArgumentException("No such card exists.");
            }
        }
    }
}
