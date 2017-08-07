using System;

namespace Vehicles
{
    class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) 
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
                base.FuelConsumption = value + 0.9;
            }
        }
        public override double FuelQuantity
        {
            get
            {
                return base.FuelQuantity;
            }

            protected set
            {
                if (value > base.TankCapacity)
                {
                    throw new ArgumentException("Cannot fit fuel in tank");
                }
                base.FuelQuantity = value;
            }
        }
        public override double TankCapacity
        {
            get
            {
                return base.TankCapacity;
            }

            protected set
            {
                if (value < base.FuelQuantity)
                {
                    throw new ArgumentException("Cannot fit fuel in tank");
                }
                base.TankCapacity = value;
            }
        }
        public override void Drive(double distance)
        {
            double consumptionPerKm = this.FuelConsumption * distance;
            
            if (this.FuelQuantity < consumptionPerKm)
            {
                throw new ArgumentException("Car needs refueling");
            }

            this.FuelQuantity -= consumptionPerKm;

            Console.WriteLine($"Car travelled {distance} km");
        }

        public override void Refuel(double liters)
        {
            this.FuelQuantity += liters;
            if (this.TankCapacity < this.FuelQuantity)
            {
                throw new ArgumentException("Cannot fit in tank");
            }
        }
    }
}
