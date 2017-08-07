using System;

namespace Animals
{
    public class Tomcat : Cat, IProduceSound
    {
        public Tomcat(string name, int age)
            : base(name, "Male", age)
        {
        }

        public override string ProduceSound() // can be either "override" or "new"
        {
            return "Give me one million b***h";
        }

        public override string ToString()
        {
            return base.ToString() + ProduceSound();
        }
    }
}
