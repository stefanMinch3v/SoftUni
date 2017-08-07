using System;

namespace WildFarm
{
    abstract class Mammal : Animal
    {
        private string livingRegion;

        public Mammal(string animalType, string animalName, double animalWeight, string livingRegion) 
            : base(animalType, animalName, animalWeight)
        {
            LivingRegion = livingRegion;
        }

        public string LivingRegion
        {
            get
            {
                return this.livingRegion;
            }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid region");
                }
                this.livingRegion = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + $", {LivingRegion}, {base.FoodEaten}]";
        }
    }
}
