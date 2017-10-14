using RelicFinder.Models;
using System.Data.Entity;

namespace RelicFinder.Data
{
    internal class RelicDbInitializer : DropCreateDatabaseAlways<RelicFinderContext>
    {
        protected override void Seed(RelicFinderContext context)
        {
            var myRelic = new Relic()
            {
                Name = "The Ark",
                Description = "A mythical box, containing the Ten Comandments",
                Type = "Container"
            };

            var secondRelic = new Relic()
            {
                Name = "The Grail",
                Description = "The cup that gives an immortality",
                Type = "Utensil"
            };

            var anotherRelic = new Relic()
            {
                Name = "Crystal Skull",
                Description = "The severed head of an extraterrestrial",
                Type = "Remains"
            };

            context.Relics.Add(myRelic);
            context.Relics.Add(secondRelic);
            context.Relics.Add(anotherRelic);

            context.SaveChanges();
        }
    }
}
