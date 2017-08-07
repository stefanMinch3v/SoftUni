using System;
using System.Linq;

namespace CardGameSecondWay
{
    public class Card
    {
        public Card(CardRank rank, CardSuits suit)
        {
            this.Rank = rank;
            this.Suit = suit;
        }

        public CardRank Rank { get; set; }

        public CardSuits Suit { get; set; }

        public int Power { get { return (int)this.Rank + (int)this.Suit; } }

        public override string ToString()
        {
            return $"{this.Rank} of {this.Suit}";
        }
    }
}
