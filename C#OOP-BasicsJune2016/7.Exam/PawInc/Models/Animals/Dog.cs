using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PawInc
{
    public class Dog : Animals
    {
        private int amountOfCommands;

        public Dog(string name, int age, string adoptionCenterName, int amountOfCommands) 
            : base(name, age, adoptionCenterName)
        {
            this.amountOfCommands = amountOfCommands;
        }
    }
}