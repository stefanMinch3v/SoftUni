namespace SystemSplit.Factory
{
    public class SoftwareFactory
    {
        public Computer CreateLightSoftware(string[] input) // can be LightSoftware
        {
            string hardware = input[1];
            string name = input[2];
            int capacity = int.Parse(input[3]);
            int memory = int.Parse(input[4]);

            return new LightSoftware(hardware, name, capacity, memory);
        }

        public Computer CreateExpressSoftware(string[] input) // can be ExpressSoftware
        {
            string hardware = input[1];
            string name = input[2];
            int capacity = int.Parse(input[3]);
            int memory = int.Parse(input[4]);

            return new ExpressSoftware(hardware, name, capacity, memory);
        }
    }
}
