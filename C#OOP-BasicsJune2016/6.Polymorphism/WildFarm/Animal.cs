using System;

namespace WildFarm
{
    abstract class Animal
    {
        private string animalName;
        private string animalType;
        private double animalWeight;
        private int foodEaten;

        public Animal(string animalType, string animalName, double animalWeight)
        {            
            AnimalType = animalType;
            AnimalName = animalName;
            AnimalWeight = animalWeight;
            this.foodEaten = 0;
        }

        public string AnimalName
        {
            get
            {
                return this.animalName;
            }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid name");
                }
                this.animalName = value;
            }
        }
        public string AnimalType
        {
            get
            {
                return this.animalType;
            }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid type");
                }
                this.animalType = value;
            }
        }
        public double AnimalWeight
        {
            get
            {
                return this.animalWeight;
            }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value.ToString()) || value < 0)
                {
                    throw new ArgumentException("Invalid weight");
                }
                this.animalWeight = value;
            }
        }
        public int FoodEaten
        {
            get
            {
                return this.foodEaten;
            }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value.ToString()) || value < 0)
                {
                    throw new ArgumentException("Invalid food");
                }
                this.foodEaten = value;
            }
        }

        public abstract void MakeSound();
        public abstract void EatFood(Food food);

        public override string ToString()
        {
            return $"{AnimalType}[{AnimalName}, {AnimalWeight}";
        }
    }
}
