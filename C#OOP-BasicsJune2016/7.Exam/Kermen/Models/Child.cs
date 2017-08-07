using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kermen
{
    public class Child
    {
        private decimal[] consumptions;

        public Child(decimal[] consumptions)
        {
            this.consumptions = consumptions;
        }

        public decimal GetTotalConsumption()
        {
            return this.consumptions.Sum();
        }
    }
}