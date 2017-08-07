using System.Collections.Generic;

namespace CompareTwoCards
{
    /// <summary>
    /// Sort the cards by Descending from the biggest to the smallest card power.
    /// </summary>
    public class CardsComparer : IComparer<Card>
    {
        public int Compare(Card x, Card y)
        {
            int result = x.Power.CompareTo(y.Power);
            if (result > 0)
            {
                return -1;
            }
            else if (result < 0)
            {
                return 1;
            }

            return 0;
        }
    }
}
