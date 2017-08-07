using System;

namespace WildFarm
{
    class Tiger : Felime
    {
        public Tiger(string animaType, string animalName, double animalWeight, string livingRegion) 
            : base(animaType, animalName, animalWeight, livingRegion)
        {
        }

        public override void EatFood(Food food)
        {
            if (food.GetType() != typeof(Meat))
            {
                throw new ArgumentException("Tigers are not eating that type of food!");
            }
            base.FoodEaten = food.Quantity;
        }

        public override void MakeSound()
        {
            Console.WriteLine("ROAAR!!!");
        }
    }
}
