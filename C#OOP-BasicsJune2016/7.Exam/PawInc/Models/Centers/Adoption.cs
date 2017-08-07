using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PawInc
{
    public class Adoption : PawCenters
    {
        private List<Animals> adoptedAnimals;
        private List<Animals> uncleanedAnimals;
        private List<Animals> cleanedAnimals;

        public Adoption(string name)
            : base(name)
        {
            adoptedAnimals = new List<Animals>();
            uncleanedAnimals = new List<Animals>();
            cleanedAnimals = new List<Animals>();
        }

        public List<Animals> AdoptedAnimals{ get { return this.adoptedAnimals; } }
        public List<Animals> UncleanedAnimals { get { return this.uncleanedAnimals; } }
        public List<Animals> CleanedAnimals { get { return this.cleanedAnimals; } }

        public void AdpotAnimal()
        {
            //animal = (Animals)cleanedAnimals.Where(x => x.Name == name);
            adoptedAnimals.AddRange(cleanedAnimals);
            cleanedAnimals.Clear();
        }

        public void AddAnimal(Animals animal)
        {
            uncleanedAnimals.Add(animal);
        }

        public void SaveCleanedAnimals(Animals cleaned)
        {
            cleanedAnimals.Add(cleaned);
        }

    }
}