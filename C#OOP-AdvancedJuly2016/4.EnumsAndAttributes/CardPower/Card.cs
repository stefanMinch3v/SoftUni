namespace CardPower
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
            return $"Card name: {this.Rank} of {this.Suit}; Card power:";
        }
    }
}
