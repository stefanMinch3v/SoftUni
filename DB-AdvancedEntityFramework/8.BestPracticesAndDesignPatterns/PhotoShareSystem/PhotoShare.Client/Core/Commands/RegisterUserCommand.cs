namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Service;
    using System;
    using Attributes;

    [Command("RegisterUser")]
    public class RegisterUserCommand : Command
    {
        private readonly UserService userService;

        public RegisterUserCommand(UserService userService) 
        {
            this.userService = userService;
        }

        // RegisterUser <username> <password> <repeat-password> <email>
        public override string Execute()
        {
            if (data.Length != 4)
            {
                throw new InvalidOperationException("Invalid Command");
            }

            string username = data[0];
            string password = data[1];
            string repeatPassword = data[2];
            string email = data[3];

            if (password != repeatPassword)
            {
                throw new ArgumentException("Passwords do not match!");
            }

            if (this.userService.IsTakenUsername(username))
            {
                throw new InvalidOperationException($"Username [{username}] is already taken!");
            }

            this.userService.RegisterUser(username, password, repeatPassword, email);

            return ("User " + username + " was registered successfully!");
        }

        public override void InsertData(string[] data)
        {
            base.data = data;
        }
    }
}
