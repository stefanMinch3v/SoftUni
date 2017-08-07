namespace SystemSplit.Repository
{
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Data : IDatabase
    {
        #region FIELDS

        private Dictionary<string, Hardware> hardware;
        //private Dictionary<string, Software> software;
        private Dictionary<string, Hardware> dumpedHardware; // bonus

        #endregion

        #region CONSTRUCTOR

        public Data()
        {
            this.hardware = new Dictionary<string, Hardware>();
            //this.software = new Dictionary<string, Software>();
            this.dumpedHardware = new Dictionary<string, Hardware>();
        }

        #endregion

        #region PROPERTIES

        public Dictionary<string, Hardware> Hardware => this.hardware;
               
        //public Dictionary<string, Software> Software => this.software;
               
        public Dictionary<string, Hardware> DumpedHardware => this.dumpedHardware; // bonus

        #endregion

        #region METHODS

        public void AddHardware(Hardware h)
        {
            this.hardware.Add(h.HardwareName, h);
        }

        public void Destroy(string hardwareName) //bonus
        {
            if (this.DumpedHardware.ContainsKey(hardwareName))
            {
                this.dumpedHardware.Remove(hardwareName);
            }
        }

        public void PrintAnalyzeCommand()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("System Analysis");
            sb.AppendLine($"Hardware Components: {this.hardware.Count}");
            sb.AppendLine($"Software Components: {this.hardware.Sum(x => x.Value.Software.Count)}");
            sb.AppendLine(
                $"Total Operational Memory: {this.Hardware.Sum(x => x.Value.MemoryUsing)} / { this.Hardware.Sum(x => x.Value.MaxMemory)}");
            sb.AppendLine(
                $"Total Capacity Taken: {this.Hardware.Sum(x => x.Value.CapacityUsing)} / {this.Hardware.Sum(x => x.Value.MaxCapacity)}");

            Console.WriteLine(sb.ToString().TrimEnd());
        }

        public void PrintSystemSplitCommand()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var kvp in this.Hardware)
            {
                sb.AppendLine($"Hardware Component - {kvp.Key}");
                sb.AppendLine($"Express Software Components - {kvp.Value.Software.Where(x => x.Type == "Express Software").Count()}");
                sb.AppendLine($"Light Software Components - {kvp.Value.Software.Where(x => x.Type == "Light Software").Count()}");
                sb.AppendLine($"Memory Usage: {kvp.Value.MemoryUsing} / {kvp.Value.MaxMemory}");
                sb.AppendLine($"Capacity Usage: {kvp.Value.CapacityUsing} / {kvp.Value.MaxCapacity}");
                sb.AppendLine($"Type: {kvp.Value.Type}");

                if (kvp.Value.Software.Count != 0)
                {
                    sb.AppendLine($"Software Components: {string.Join(", ", kvp.Value.Software)}");
                }
                else
                {
                    sb.AppendLine($"Software Components: None");
                }

                Console.WriteLine(sb.ToString().TrimEnd());
                sb.Clear();
            }
        }

        public void Dump(string hardwareName)
        {
            if (this.Hardware.ContainsKey(hardwareName))
            {
                Hardware hardwareForDump = this.Hardware[hardwareName];
                this.DumpedHardware.Add(hardwareName, hardwareForDump);
                this.Hardware.Remove(hardwareName);
            }
        }

        public void Restore(string hardwareName)
        {
            if (this.DumpedHardware.ContainsKey(hardwareName))
            {
                Hardware hardwareForDump = this.DumpedHardware[hardwareName];
                this.Hardware.Add(hardwareName, hardwareForDump);
                this.DumpedHardware.Remove(hardwareName);
            }
        }

        public void PrintDumpAnalyzeCommand()
        {
            int countExpressSoftware = 0;
            int countLightSoftware = 0;

            foreach (var kvp in this.DumpedHardware)
            {
                foreach (var soft in kvp.Value.Software)
                {
                    if (soft.Type == "Express Software")
                    {
                        countExpressSoftware++;
                    }
                    else
                    {
                        countLightSoftware++;
                    }
                }
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Dump Analysis");
            sb.AppendLine(
                $"Power Hardware Components: {this.DumpedHardware.Where(x => x.Value.Type == "Power").Count()}");
            sb.AppendLine(
                $"Heavy Hardware Components: {this.DumpedHardware.Where(x => x.Value.Type == "Heavy").Count()}");
            sb.AppendLine(
                $"Express Software Components: {countExpressSoftware}");
            sb.AppendLine(
                $"Light Software Components: {countLightSoftware}");
            sb.AppendLine(
                $"Total Dumped Memory: {this.DumpedHardware.Values.Sum(x => x.MemoryUsing)}");
            sb.AppendLine(
                $"Total Dumped Capacity: {this.DumpedHardware.Sum(x => x.Value.CapacityUsing)}");

            Console.WriteLine(sb.ToString().TrimEnd());
            sb.Clear();
        }

        #endregion
    }
}
