using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kermen
{
    public abstract class Couple : HouseHold
    {
        private decimal tvCost;
        private decimal fridgeCost;

        protected Couple(int numberOfRooms, decimal roomElectricity, decimal income, decimal tvCost, decimal fridgeCost) 
            : base(income, numberOfRooms, roomElectricity)
        {
            this.tvCost = tvCost;
            this.fridgeCost = fridgeCost;
        }

        public override decimal Consumption
        {
            get
            {
                return base.Consumption + this.tvCost + this.fridgeCost;
            }
        }
        public override int Population
        {
            get
            {
                return base.Population + 1;
            }
        }
    }
}