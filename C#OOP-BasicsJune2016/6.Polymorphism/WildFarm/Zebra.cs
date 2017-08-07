using System;

namespace WildFarm
{
    class Zebra : Mammal
    {
        public Zebra(string animalType, string animalName, double animalWeight, string livingRegion) 
            : base(animalType, animalName, animalWeight, livingRegion)
        {
        }

        public override void EatFood(Food food)
        {
            if (food.GetType() != typeof(Vegetable))
            {
                throw new ArgumentException("Zebras are not eating that type of food!");
            }
            base.FoodEaten = food.Quantity;
        }

        public override void MakeSound()
        {
            Console.WriteLine("Zs");
        }
    }
}
