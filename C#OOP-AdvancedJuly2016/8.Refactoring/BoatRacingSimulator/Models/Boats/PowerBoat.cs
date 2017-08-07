namespace BoatRacingSimulator.Models.Boats
{
    using System;
    using BoatRacingSimulator.Models.BoatEngines;
    using Interfaces;

    public class PowerBoat : Boat, IEngineHolder
    {
        private IBoatEngine firstEngine;
        private IBoatEngine secondEngine;

        public PowerBoat(string model, int weight, IBoatEngine firstEngine, IBoatEngine secondEngine)
            : base(model, weight)
        {
            this.FirstEngine = firstEngine;
            this.SecondEngine = secondEngine;
        }

        internal IBoatEngine FirstEngine
        {
            get
            {
                return this.firstEngine;
            }

            private set
            {
                if (value == null)
                {
                    throw new System.ArgumentNullException();
                }

                this.firstEngine = value;
            }
        }

        internal IBoatEngine SecondEngine
        {
            get
            {
                return this.secondEngine;
            }

            private set
            {
                if (value == null)
                {
                    throw new System.ArgumentNullException();
                }

                this.secondEngine = value;
            }
        }

        public override double CalculateRaceSpeed(IRace race)
        {
            var speed = this.FirstEngine.Output + this.SecondEngine.Output - this.Weight + (race.OceanCurrentSpeed / 5d);
            return speed;
        }
    }
}
