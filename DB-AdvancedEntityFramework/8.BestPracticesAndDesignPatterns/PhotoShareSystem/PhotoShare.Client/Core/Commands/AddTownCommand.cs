namespace PhotoShare.Client.Core.Commands
{
    using System;
    using PhotoShare.Service;
    using Attributes;

    [Command("AddTown")]
    public class AddTownCommand : Command
    {
        private readonly TownService townService;
        public AddTownCommand(TownService townService) 
        {
            this.townService = townService;
        }

        public override string Execute()
        {
            string townName = data[0];
            string country = data[1];

            if (this.townService.IsTownExisting(townName))
            {
                throw new ArgumentException($"Town[{townName}] was already added!");
            }

            if (!SecurityService.Instance.IsAuthenticated())
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            this.townService.AddTown(townName, country);

            return ((townName + " was added to database!"));
        }

        public override void InsertData(string[] data)
        {
            base.data = data;
        }
    }
}
