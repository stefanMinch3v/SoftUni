using System;

namespace WildFarm
{
    class Cat : Felime
    {
        private string breed;

        public Cat(string animaType, string animalName, double animalWeight, string livingRegion, string breed) 
            : base(animaType, animalName, animalWeight, livingRegion)
        {
            Breed = breed;
        }

        public string Breed
        {
            get
            {
                return this.breed;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid breed");
                }
                this.breed = value;
            }

        }

        public override void EatFood(Food food)
        {
            base.FoodEaten = food.Quantity;
        }

        public override void MakeSound()
        {
            Console.WriteLine("Meowwww");
        }

        public override string ToString()
        {
            return $"{AnimalType}[{AnimalName}, {Breed}, {AnimalWeight}, {base.LivingRegion}, {FoodEaten}]";
        }
    }
}
