namespace PhotoShare.Client.Core.Commands
{
    using Models;
    using PhotoShare.Data;
    using System;
    using System.Linq;

    public class AddTownCommand : Command
    {
        public AddTownCommand(string[] data) 
            : base(data)
        {
        }

        public override Command Create(string[] data)
        {
            return new AddTownCommand(data);
        }

        // AddTown <townName> <countryName>
        public override void Execute()
        {
            string townName = base.data[1];
            string country = base.data[2];

            using (PhotoShareContext context = new PhotoShareContext())
            {
                Town town = new Town
                {
                    Name = townName,
                    Country = country
                };

                CheckExistingTown(context, town);

                context.Towns.Add(town);
                context.SaveChanges();

                Console.WriteLine(townName + " was added to database!");
            }
        }

        private void CheckExistingTown(PhotoShareContext context, Town town)
        {
            using (context)
            {
                if (context.Towns.Any(t => t.Name == town.Name))
                {
                    throw new ArgumentException($"Town[{town.Name}] was already added!");
                }
            }           
        }
    }
}
