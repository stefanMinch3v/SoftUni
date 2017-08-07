namespace SystemSplit.Factory
{
    public class HardwareFactory
    {
        public Computer CreateHeavyHardware(string[] input) // can be HeavyHardware
        {
            string name = input[1];
            int capacity = int.Parse(input[2]);
            int memory = int.Parse(input[3]);

            return new HeavyHardware(name, capacity, memory);
        }

        public Computer CreatePowerHardware(string[] input) // can be PowerHardware
        {
            string name = input[1];
            int capacity = int.Parse(input[2]);
            int memory = int.Parse(input[3]);

            return new PowerHardware(name, capacity, memory);
        }
    }
}
