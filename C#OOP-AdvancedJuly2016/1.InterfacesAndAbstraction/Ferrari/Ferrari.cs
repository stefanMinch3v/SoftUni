using System;

namespace Ferrari
{
    public class Ferrari : ICar
    {
        public Ferrari(string driverName)
        {
            this.DriverName = driverName;
        }

        public string DriverName { get; set; }

        public string Model
        {
            get
            {
                return "488-Spider";
            }     
        }

        public string PushTheGasPedal()
        {
            return "Zadu6avam sA!";
        }

        public string UseBrakes()
        {
            return "Brakes!";
        }

        public override string ToString()
        {
            return $"{this.Model}/{UseBrakes()}/{PushTheGasPedal()}/{DriverName}";
        }
    }
}
