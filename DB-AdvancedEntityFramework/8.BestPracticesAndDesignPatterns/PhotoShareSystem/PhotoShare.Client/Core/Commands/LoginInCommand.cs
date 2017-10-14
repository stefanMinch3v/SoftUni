namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Service;
    using System;
    using Attributes;

    [Command("Login")]
    public class LoginInCommand : Command
    {
        private readonly SecurityService securityService;

        public LoginInCommand(SecurityService securityService)
        {
            this.securityService = securityService;
        }

        public override string Execute()
        {
            string username = data[0];
            string password = data[1];

            this.securityService.LoginUser(username, password);

            return ($"User [{username}] successfully logged in!");
        }

        public override void InsertData(string[] data)
        {
            base.data = data;
        }
    }
}
