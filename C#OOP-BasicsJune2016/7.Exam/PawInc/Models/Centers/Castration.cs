namespace PawInc.Models.Centers
{
    using System.Collections.Generic;

    public class Castration : PawCenters
    {
        private List<Animals> animalsToBeCastrated;
        private List<Animals> castratedAnimals;
        private int countCastrated;

        public Castration(string name) 
            : base(name)
        {
            this.animalsToBeCastrated = new List<Animals>();
            this.castratedAnimals = new List<Animals>();
        }

        public List<Animals> AlreadyCastrated => this.castratedAnimals;

        public int CountCastrated => this.countCastrated;

        public void AddAnimalsToCastrate(Animals animal)
        {
            animalsToBeCastrated.Add(animal);
        }

        public void CastrateAnimals()
        {
            animalsToBeCastrated.ForEach(x => { x.Castrate = true; castratedAnimals.Add(x); countCastrated++; });
            //foreach (var item in animalsToBeCastrated)
            //{
            //    item.Castrate = true;
            //    castratedAnimals.Add(item);
            //    countCastrated++;
            //}

            animalsToBeCastrated.Clear();
        }
    }
}
