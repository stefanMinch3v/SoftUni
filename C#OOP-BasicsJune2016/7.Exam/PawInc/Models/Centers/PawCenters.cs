using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PawInc
{
    public abstract class PawCenters
    {
        private string name;

        protected PawCenters(string name)
        {
            this.name = name;
        }

        public string Name { get { return this.name; } }
    }
}