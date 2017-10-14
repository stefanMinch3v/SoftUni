namespace RelicFinder.Data.Stores
{
    using RelicFinder.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System;

    public class RelicStore
    {

        private RelicFinderContext context = new RelicFinderContext();
        //new feautre - to add virtual collection which will save our temporary changes and right after click button save changes then we will iterate through this collection check if the property IsDirty was changed to true and if it is then take only them to avoid override the existing entries which the default IsDirty is equal to false.This option should have cancel button as well as save changes and also edit button because it has to be read only. After savechanges is called then go through the collection again and make IsDirty to false to all elements.
        public void Initialize()
        {

            context.Database.Initialize(true);
        }

        public List<Relic> GetAllRelics()
        {
            return this.context.Relics.ToList();
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        public Relic AddNewRelic()
        {
            var newRelic = new Relic()
            {
                Name = "New Relic"
            };

            this.context.Relics.Add(newRelic);
            return newRelic;
        }
    }
}
