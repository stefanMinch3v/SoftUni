using System;
using System.Linq;

namespace CompareTwoCards
{
    public class Card
    {
        public Card(string rank, string suit, int power)
        {
            this.Rank = rank;
            this.Suit = suit;
            this.Power = power;
        }

        public string Rank { get; set; }

        public string Suit { get; set; }

        public int Power { get; set; }

        public override string ToString()
        {
            return $"Card name: {this.Rank} of {this.Suit}; Card power: {this.Power}";
        }
    }
}
