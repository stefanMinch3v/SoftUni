using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kermen
{
    public class AloneYoung : Single
    {
        private const int NumberOfRooms = 1;
        private const decimal RoomElectricity = 10;

        private decimal laptopCost;

        public AloneYoung(decimal income, decimal laptopCost) 
            : base(income, NumberOfRooms, RoomElectricity)
        {
            this.laptopCost = laptopCost;
        }

        public override decimal Consumption
        {
            get
            {
                return base.Consumption + this.laptopCost;
            }
        }
    }
}