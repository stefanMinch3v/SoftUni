namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Models;
    using PhotoShare.Service;
    using System;
    using System.Linq;
    using Attributes;

    [Command("ModifyUser")]
    public class ModifyUserCommand : Command
    {
        private readonly UserService userService;
        private readonly TownService townService;

        public ModifyUserCommand(UserService userService, TownService townService)
        {
            this.userService = userService;
            this.townService = townService;
        }

        public override string Execute()
        {
            string username = data[0];
            string property = data[1];
            string newValue = data[2];

            User user = this.userService.GetUserByUsername(username);

            if (user == null)
            {
                throw new ArgumentException($"User [{username}] not found!");
            }

            if (user.Username != SecurityService.Instance.GetCurrentUser().Username)
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            if (property == "Password")
            {
                if (!newValue.Any(c => char.IsLower(c)) || !newValue.Any(c => char.IsDigit(c)))
                {
                    throw new ArgumentException("Invalid Password");
                }

                user.Password = newValue;
            }
            else if (property == "BornTown")
            {
                Town town = this.townService.GetTownByName(newValue);

                if (town == null)
                {
                    throw new ArgumentException($"Town [{newValue}] not found!");
                }

                user.BornTown = town;
            }
            else if (property == "CurrentTown")
            {
                Town town = this.townService.GetTownByName(newValue);

                if (town == null)
                {
                    throw new ArgumentException($"Town [{newValue}] not found!");
                }

                user.CurrentTown = town;
            }
            else
            {
                throw new ArgumentException($"Property [{property}] not supported!");
            }

            this.userService.UpdateUser(user, property, newValue);

            return ($"User [{username}] [{property}] is [{newValue}].");
        }

        public override void InsertData(string[] data)
        {
            base.data = data;
        }
    }
}
