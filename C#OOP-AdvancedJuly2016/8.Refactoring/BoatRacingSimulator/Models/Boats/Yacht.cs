namespace BoatRacingSimulator.Models.Boats
{
    using System;
    using Interfaces;
    using Utility;

    public class Yacht : Boat, IEngineHolder
    {
        private int cargoWeight;
        private IBoatEngine boatEngine;

        public Yacht(string model, int weight, int cargoWeight, IBoatEngine boatEngine)
            : base(model, weight)
        {
            this.CargoWeight = cargoWeight;
            this.BoatEngine = boatEngine;
        }

        public int CargoWeight
        {
            get
            {
                return this.cargoWeight;
            }

            private set
            {
                Validator.ValidatePropertyValue(value, nameof(this.CargoWeight));
                this.cargoWeight = value;
            }
        }

        public IBoatEngine BoatEngine
        {
            get
            {
                return this.boatEngine;
            }

            private set
            {
                if (value == null)
                {
                    throw new System.ArgumentNullException();
                }

                this.boatEngine = value;
            }
        }

        public override double CalculateRaceSpeed(IRace race)
        {
            var speed = this.BoatEngine.Output - (this.Weight + this.CargoWeight) + (race.OceanCurrentSpeed / 2d);
            return speed;
        }
    }
}
