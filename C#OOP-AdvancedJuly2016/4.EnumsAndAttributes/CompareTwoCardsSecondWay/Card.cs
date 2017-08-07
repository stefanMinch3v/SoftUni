using System;

namespace CompareTwoCardsSecondWay
{
    public class Card : IComparable<Card>
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
            return string.Format($"Card name: {this.Rank} of {this.Suit}; Card power: {this.Power}");
        }

        public int CompareTo(Card other)
        {
            return this.Power.CompareTo(other.Power);
        }
    }
}
