using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SystemSplit
{
    public class HeavyHardware : Hardware
    {
        private const string Type = "Heavy";

        public HeavyHardware(string name, int maxCapacity, int maxMemory) 
            : base(Type, name, maxCapacity, maxMemory)
        {
        }

        public override int MaxCapacity
        {
            protected set 
            {
                base.MaxCapacity = value * 2;
            }
        }

        public override int MaxMemory
        {
            protected set
            {
                base.MaxMemory = value - (int)Math.Abs(value * 0.25);
                //value - (value) / 4
            }
        }
    }
}