using System;

namespace Animals
{
    public class Dog : Animal, IProduceSound
    {
        public Dog(string name, string gender, int age)
            : base(name, gender, age)
        {
            base.Name = name;
        }

        public string ProduceSound()
        {
            return "BauBau";
        }

        public override string ToString()
        {
            return base.ToString() + ProduceSound();
        }
    }
}

