using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InfernoInfinity
{
    public class Axe : Weapon
    {
        private const int minDamage = 5;
        private const int maxDamage = 10;
        private const int numOfSockets = 4;

        public Axe(string rareLevel, string name) 
            : base(rareLevel, name, maxDamage, minDamage, numOfSockets)
        {
        }
    }
}