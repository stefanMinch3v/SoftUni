using System;

namespace WildFarm
{
    class Mouse : Mammal
    {
        public Mouse(string animalType, string animalName, double animalWeight, string livingRegion) 
            : base(animalType, animalName, animalWeight, livingRegion)
        {
        }

        public override void EatFood(Food food)
        {
            if (food.GetType() != typeof(Vegetable))
            {
                throw new ArgumentException("Mouses are not eating that type of food!");
            }
            base.FoodEaten = food.Quantity;
        }

        public override void MakeSound()
        {
            Console.WriteLine("SQUEEEAAAK!");
        }
    }
}
