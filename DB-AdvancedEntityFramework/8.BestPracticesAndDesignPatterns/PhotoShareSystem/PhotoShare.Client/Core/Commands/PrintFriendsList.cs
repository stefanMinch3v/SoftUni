namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Service;
    using System;
    using System.Linq;
    using System.Text;
    using Attributes;

    [Command("ListFriends")]
    public class PrintFriendsListCommand : Command
    {
        private readonly UserService userService;

        public PrintFriendsListCommand(UserService userService)
        {
            this.userService = userService;
        }

        // PrintFriendsList <username>

        public override string Execute()
        {
            string username = data[0];
            StringBuilder sb = new StringBuilder();

            if (!this.userService.IsUserExisting(username))
            {
                throw new ArgumentException($"User [{username}] not found!");
            }

            var user = this.userService.GetUserWithFriends(username);
            if (user.Friends.Count() == 0)
            {
                return ("No friends for this user. :(");
            }
            else
            {
                sb.AppendLine("Friends:");
                foreach (var friends in user.Friends)
                {
                    sb.AppendLine($"-{friends.Username}");
                }
            }

            return (sb.ToString());
        }

        public override void InsertData(string[] data)
        {
            base.data = data;
        }
    }
}
