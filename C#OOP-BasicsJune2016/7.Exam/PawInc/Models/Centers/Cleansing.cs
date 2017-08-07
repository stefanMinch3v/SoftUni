using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PawInc
{
    public class Cleansing : PawCenters
    {
        private List<Animals> cleanedAnimals;
        private List<Animals> uncleanedAnimals;

        public Cleansing(string name) 
            : base(name)
        {
            cleanedAnimals = new List<Animals>();
            uncleanedAnimals = new List<Animals>();
        }

        public List<Animals> CleanedAnimals { get { return this.cleanedAnimals; } }
        public List<Animals> UncleanedAnimals { get { return this.uncleanedAnimals; } }

        public void CleanAnimals()
        {
            //// cleans animals and send it to the startup to handle with it
            uncleanedAnimals.ForEach(x => 
            {
                x.ChangeStatusToClean();
                cleanedAnimals.Add(x);
            });
            uncleanedAnimals.Clear();
        }

        public void AddUncleanedAnimal(List<Animals> animalsToBeCleaned)
        {
            uncleanedAnimals.AddRange(animalsToBeCleaned);
            //return uncleanedAnimals;
        }
    }
}