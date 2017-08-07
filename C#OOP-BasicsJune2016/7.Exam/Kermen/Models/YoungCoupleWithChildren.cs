using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kermen
{
    public class YoungCoupleWithChildren : YoungCouple
    {
        private const int NumberOfRooms = 2;
        private const decimal RoomElectricity = 30;

        private Child[] children;

        public YoungCoupleWithChildren(decimal salaryOne, decimal salaryTwo, decimal tvCost, decimal fridgeCost, decimal laptopCost, Child[] children)
            : base(NumberOfRooms, RoomElectricity, salaryOne + salaryTwo, tvCost, fridgeCost, laptopCost)
        {
            this.children = children;
        }

        public override decimal Consumption
        {
            get
            {
                return base.Consumption + this.children.Sum(x => x.GetTotalConsumption());
            }
        }

        public override int Population
        {
            get
            {
                return base.Population + this.children.Length;
            }
        }

    }
}