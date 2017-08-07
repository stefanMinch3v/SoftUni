using System;

namespace Animals
{
    public class Frog : Animal, IProduceSound
    {
        public Frog(string name, string gender, int age)
            : base(name, gender, age)
        {
            base.Name = name;
        }

        public string ProduceSound()
        {
            return "Frogggg";
        }

        public override string ToString()
        {
            return base.ToString() + ProduceSound();
        }
    }
}

