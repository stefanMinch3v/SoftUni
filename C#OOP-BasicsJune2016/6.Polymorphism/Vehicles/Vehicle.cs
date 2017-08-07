using System;

namespace Vehicles
{
    abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;
    
        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;  
        }

        public virtual double TankCapacity
        {
            get
            {
                return this.tankCapacity;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid tank capacity");
                }
                this.tankCapacity = value;
            }
        }
        public virtual double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value.ToString()) || value < 1)
                {
                    throw new ArgumentException("Fuel must be a positive number");
                }
                this.fuelQuantity = value;
            }
        }
        public virtual double FuelConsumption
        {
            get
            {
                return this.fuelConsumption;
            }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value.ToString()) || value < 0)
                {
                    throw new ArgumentException("Consumption cannot be negative or zero");
                }
                this.fuelConsumption = value;
            }
        }

        public abstract void Drive(double distance);

        public abstract void Refuel(double liters);

    }
}
