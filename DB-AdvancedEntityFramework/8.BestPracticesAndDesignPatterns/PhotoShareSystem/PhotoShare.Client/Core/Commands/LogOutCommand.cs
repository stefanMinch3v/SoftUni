namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Models;
    using PhotoShare.Service;
    using System;
    using Attributes;

    [Command("Logout")]
    public class LogOutCommand : Command
    {
        private readonly SecurityService securityService;

        public LogOutCommand(SecurityService securityService)
        {
            this.securityService = securityService;
        }

        public override string Execute()
        {
            User user = this.securityService.GetCurrentUser();

            if (user == null)
            {
                throw new InvalidOperationException("You should log in first in order to logout.");
            }

            this.securityService.LogoutUser();

            return ($"User {user.Username} successfully logged out!");
        }

        public override void InsertData(string[] data)
        {
            base.data = data;
        }
    }
}
