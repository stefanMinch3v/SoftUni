using System;

namespace WildFarm
{
    abstract class Food
    {
        private int quantity;

        public Food(int quantity)
        {
            Quantity = quantity;
        }

        public int Quantity
        {
            get
            {
                return this.quantity;
            }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value.ToString()) || value < 0)
                {
                    throw new ArgumentException("Food quantity must be positive number");
                }
                this.quantity = value;
            }

        }
    }
}
