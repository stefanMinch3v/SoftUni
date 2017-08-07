using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kermen
{
    public class OldCouple : Couple
    {
        private const int NumberOfRooms = 3;
        private const decimal RoomElectricity = 15;

        private decimal stoveCost;

        public OldCouple(decimal pensionOne, decimal pensionTwo, decimal tvCost, decimal fridgeCost, decimal stoveCost) 
            : base(NumberOfRooms, RoomElectricity, pensionOne + pensionTwo, tvCost, fridgeCost)
        {
            this.stoveCost = stoveCost;
        }

        public override decimal Consumption
        {
            get
            {
                return base.Consumption + this.stoveCost;
            }
        }
    }
}