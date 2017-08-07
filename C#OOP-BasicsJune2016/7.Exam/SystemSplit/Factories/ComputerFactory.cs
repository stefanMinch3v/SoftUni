using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SystemSplit.Factory
{
    public static class ComputerFactory
    {
        static List<Hardware> listOfHardwares = new List<Hardware>();

        public static Computer CreateComputer(string input)
        {
            string pattern = @"([a-zA-Z]+)\(([a-zA-Z0-9,\.\s]+)\)";
            Regex rgx = new Regex(pattern);
            MatchCollection collection = rgx.Matches(input);

            if (!rgx.IsMatch(input))
            {
                throw new ArgumentException("Invalid input!");
            }

            string typeOfComputer = collection[0].Groups[1].Value;

            switch (typeOfComputer)
            {
                case "RegisterPowerHardware":
                    return CreatePowerHardware(collection, listOfHardwares);
                case "RegisterHeavyHardware":
                    return CreateHeavyHardware(collection, listOfHardwares);
                case "RegisterLightSoftware":
                    return CreateLightSoftware(collection, listOfHardwares);
                case "RegisterExpressSoftware":
                    return CreateExpressSoftware(collection, listOfHardwares);
                default:
                    throw new ArgumentException("Invalid command");
            }
        }

        private static Computer CreateExpressSoftware(MatchCollection collection, List<Hardware> listOfHardwares)
        {
            string[] properties = collection[0].Groups[2].Value.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            string type = properties[0];
            string name = properties[1];
            int memoryConsumption = int.Parse(properties[2]);
            int capacityConsumption = int.Parse(properties[3]);

            bool hasHardware = listOfHardwares.Exists(x => x.Name == type);

            if (!hasHardware)
            {
                throw new ArgumentException("That hardware doesn't exist!");
            }

            return new Express(type, name, memoryConsumption, capacityConsumption);
        }

        private static Computer CreateLightSoftware(MatchCollection collection, List<Hardware> listOfHardwares)
        {
            string[] properties = collection[0].Groups[2].Value.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            string type = properties[0];
            string name = properties[1];
            int memoryConsumption = int.Parse(properties[2]);
            int capacityConsumption = int.Parse(properties[3]);

            bool hasHardware = listOfHardwares.Exists(x => x.Name == type);

            if (!hasHardware)
            {
                throw new ArgumentException("That hardware doesn't exist!");
            }

            return new Light(type, /*name,*/ memoryConsumption, capacityConsumption);
        }

        private static Computer CreateHeavyHardware(MatchCollection collection, List<Hardware> listOfHardwares)
        {
            string[] properties = collection[0].Groups[2].Value.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            string type = properties[0];
            int maxCapacity = int.Parse(properties[1]);
            int maxMemory = int.Parse(properties[2]);

            Heavy heavy = new Heavy(type, maxCapacity, maxMemory);
            listOfHardwares.Add(heavy);
            return heavy;
        }

        private static Computer CreatePowerHardware(MatchCollection collection, List<Hardware> listOfHardwares)
        {
            string[] properties = collection[0].Groups[2].Value.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            string type = properties[0];
            int maxCapacity = int.Parse(properties[1]);
            int maxMemory = int.Parse(properties[2]);

            Power power = new Power(type, maxCapacity, maxMemory);
            listOfHardwares.Add(power);
            return power;
        }
    }
}
