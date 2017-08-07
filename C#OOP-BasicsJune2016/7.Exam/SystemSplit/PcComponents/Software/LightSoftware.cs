namespace SystemSplit
{
    using System;

    public class LightSoftware : Software
    {
        private const string Type = "Light Software";

        public LightSoftware(string hardware, string name, int capacityConsumption, int memoryConsumption) 
            : base(Type, hardware, name, capacityConsumption, memoryConsumption)
        {
        }

        public override int CapacityConsumption
        {
            protected set
            {
                base.CapacityConsumption = value + (int)Math.Abs(value * 0.50);
                //value + (value / 2)
            }
        }

        public override int MemoryConsumption
        {
            protected set
            {
                base.MemoryConsumption = value - (int)Math.Abs(value * 0.50);
                //value / 2
            }
        }
    }
}