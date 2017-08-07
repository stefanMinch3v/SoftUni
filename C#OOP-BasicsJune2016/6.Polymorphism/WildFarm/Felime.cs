using System;

namespace WildFarm
{
    abstract class Felime : Mammal
    {
        public Felime(string animalType, string animalName, double animalWeight, string livingRegion) 
            : base(animalType, animalName, animalWeight, livingRegion)
        {
        }
    }
}
