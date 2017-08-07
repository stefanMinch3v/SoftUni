using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InfernoInfinity
{
    public class Knife : Weapon
    {
        private const int minDamage = 3;
        private const int maxDamage = 4;
        private const int numOfSockets = 2;

        public Knife(string rareLevel, string name) 
            : base(rareLevel, name, maxDamage, minDamage, numOfSockets)
        {
        }
    }
}