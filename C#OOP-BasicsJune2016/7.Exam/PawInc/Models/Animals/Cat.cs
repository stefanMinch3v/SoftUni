using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PawInc
{
    public class Cat : Animals
    {
        private int intelligenceCoefficient;

        public Cat(string name, int age, string adoptionCenterName, int intelligenceCoefficient)
            : base(name, age, adoptionCenterName)
        {
            this.intelligenceCoefficient = intelligenceCoefficient;
        }
    }
}