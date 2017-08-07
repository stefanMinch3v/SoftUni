using System;

namespace FoodShortage
{
    public abstract class Person : IBuyer
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
            this.Food = 0;
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                this.age = value;
            }
        }

        public int Food { get; protected set; }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public abstract void BuyFood();
    }
}
