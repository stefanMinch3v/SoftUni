using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kermen
{
    public abstract class Single : HouseHold
    {
        protected Single(decimal income, int numberOfRooms, decimal roomElectricity)
            : base(income, numberOfRooms, roomElectricity)
        {
        }
    }
}