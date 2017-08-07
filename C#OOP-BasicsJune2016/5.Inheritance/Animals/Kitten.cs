using System;

namespace Animals
{
    public class Kitten : Cat, IProduceSound
    {
        public Kitten(string name, int age)
            : base(name, "Female", age)
        {
        }

        public new string ProduceSound() // can be either "override" or "new"
        {
            return "Miau";
        }

        public override string ToString()
        {
            return base.ToString() + ProduceSound();
        }
    }
}
