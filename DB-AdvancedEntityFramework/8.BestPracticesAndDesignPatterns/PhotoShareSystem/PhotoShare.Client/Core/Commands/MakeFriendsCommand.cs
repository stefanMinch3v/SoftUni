namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Service;
    using System;
    using System.Linq;
    using Attributes;

    [Command("MakeFriends")]
    public class MakeFriendsCommand : Command
    {
        private readonly UserService userService;

        public MakeFriendsCommand(UserService userService)
        {
            this.userService = userService;
        }

        // MakeFriends <username1> <username2>
        public override string Execute()
        {
            string firstUser = data[0];
            string secondUser = data[1];

            if (!SecurityService.Instance.IsAuthenticated())
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            var user1 = this.userService.GetUserWithFriends(firstUser) ?? throw new ArgumentException($"[{firstUser}] not found!");
            var user2 = this.userService.GetUserByUsername(secondUser) ?? throw new ArgumentException($"[{secondUser}] not found!");

            if (SecurityService.Instance.GetCurrentUser().Username != firstUser)
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            if (user1.Friends.Any(f => f.Username == secondUser))
            {
                throw new InvalidOperationException($"[{secondUser}] is already a friend to [{firstUser}]");
            }

            this.userService.MakeFriends(firstUser, secondUser);

            return ($"Friend [{secondUser}] added to [{firstUser}]");
        }

        public override void InsertData(string[] data)
        {
            base.data = data;
        }
    }
}
