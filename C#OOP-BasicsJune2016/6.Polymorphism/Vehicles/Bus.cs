using System;

namespace Vehicles
{
    class Bus : Vehicle
    {
        private bool hasPeople = false;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public void PeopleOnBus()
        {
            hasPeople = true;
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
        public override void Refuel(double liters) 
        {
            this.FuelQuantity += liters;
            if (this.TankCapacity < this.FuelQuantity)
            {
                throw new ArgumentException("Cannot fit in tank");
            }
        }
        public override void Drive(double distance)
        {
            if (!hasPeople)
            {
                double consumptionPerKm = (this.FuelConsumption + 1.4) * distance;

                if (this.FuelQuantity < consumptionPerKm)
                {
                    throw new ArgumentException("Bus needs refueling");
                }

                this.FuelQuantity -= consumptionPerKm;
            }
            else
            {
                double consumptionPerKm = this.FuelConsumption * distance;

                if (this.FuelQuantity < consumptionPerKm)
                {
                    throw new ArgumentException("Bus needs refueling");
                }
                this.FuelQuantity -= consumptionPerKm;
            }
            Console.WriteLine($"Bus travelled {distance} km");
        }
    }
}
