namespace DeckOfCards
{
    public class Card
    {
        public Card(string rank, string suit)
        {
            this.Rank = rank;
            this.Suit = suit;
        }

        public string Rank { get; set; }

        public string Suit { get; set; }

        public override string ToString()
        {
            return $"{this.Rank} of {this.Suit}";
        }
    }
}
