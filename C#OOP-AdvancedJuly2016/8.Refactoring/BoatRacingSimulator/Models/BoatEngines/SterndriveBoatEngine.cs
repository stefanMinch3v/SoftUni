namespace BoatRacingSimulator.Models.BoatEngines
{
    internal class SterndriveBoatEngine : BoatEngine
    {
        private const int Multiplier = 7;

        public SterndriveBoatEngine(string model, int horsepower, int displacement) 
            : base(model, horsepower, displacement)
        {
        }

        public override int Output
        {
            get
            {
                if (this.CachedOutput != 0)
                {
                    return this.CachedOutput;
                }

                this.CachedOutput = (this.Horsepower * Multiplier) + this.Displacement;
                return this.CachedOutput;
            }
        }
    }
}
