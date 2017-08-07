using System;

namespace Vehicles
{
    class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelConsumption
        {
            get
            {
                return base.FuelConsumption;
            }

            protected set
            {
                base.FuelConsumption = value + 1.6;
            }
        }
        public override void Drive(double distance)
        {
            double consumptionPerKm = this.FuelConsumption * distance;
            
            if (base.FuelQuantity < consumptionPerKm)
            {
                throw new ArgumentException("Truck needs refueling");
            }

            base.FuelQuantity -= consumptionPerKm;

            Console.WriteLine($"Truck travelled {distance} km");
        }

        public override void Refuel(double liters)
        {
            base.FuelQuantity += liters * 0.95;
        }
    }
}
