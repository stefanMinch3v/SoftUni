using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SystemSplit
{
    public class PowerHardware : Hardware
    {
        private const string Type = "Power";
        //private const int Memory = 

        public PowerHardware(string name, int maxCapacity, int maxMemory) 
            : base(Type, name, maxCapacity, maxMemory)
        {
        }

        public override int MaxCapacity
        {
            protected set
            {
                base.MaxCapacity = value - (int)Math.Abs(value * 0.75);
            }
        }

        public override int MaxMemory
        {
            protected set
            {
                base.MaxMemory = value + (int)Math.Abs(value * 0.75);
                //value + (value * 3) / 4;
            }
        }
    }
}