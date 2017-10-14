namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Models;
    using PhotoShare.Service;
    using System;
    using Attributes;

    [Command("DeleteUser")]
    public class DeleteUser : Command
    {
        private readonly UserService userService;

        public DeleteUser(UserService userService)
        {
            this.userService = userService;
        }

        public override string Execute()
        {
            string username = data[0];

            if (!this.userService.IsTakenUsername(username))
            {
                throw new InvalidOperationException($"User with {username} was not found!");
            }

            User user = this.userService.GetUserByUsername(username);

            if (user.IsDeleted == true)
            {
                throw new InvalidOperationException($"User [{username}] is already deleted!");
            }

            if (!SecurityService.Instance.IsAuthenticated() || SecurityService.Instance.GetCurrentUser().Username != username)
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            user.IsDeleted = true;
            this.userService.RemoveUser(user);

            return ($"User {username} was deleted from the database!");
        }

        public override void InsertData(string[] data)
        {
            base.data = data;
        }
    }
}
