using System;

namespace Animals
{
    public class Cat : Animal, IProduceSound
    {
        public Cat(string name, string gender, int age)
            : base(name, gender, age)
        {
        }

        public virtual string ProduceSound()
        {
            return "MiauMiau";
        }

        public override string ToString()
        {
            return base.ToString() + ProduceSound();
        }
    }
}

