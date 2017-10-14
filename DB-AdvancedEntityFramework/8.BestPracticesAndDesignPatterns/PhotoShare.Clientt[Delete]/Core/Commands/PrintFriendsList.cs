namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Data;
    using System;
    using System.Linq;

    public class PrintFriendsListCommand : Command
    {
        public PrintFriendsListCommand(string[] data)
            : base(data)
        {
        }

        // PrintFriendsList <username>
        public override void Execute()
        {
            // TODO prints all friends of user with given username.
            string username = base.data[1];

            using (var context = new PhotoShareContext())
            {
                CheckExistUser(username, context);

                var user = context.Users.First(u => u.Username == username);
                if (user.Friends.Count() == 0)
                {
                    Console.WriteLine("No friends for this user. :(");
                }
                else
                {
                    foreach (var friends in user.Friends)
                    {
                        Console.WriteLine(friends.Username);
                    }
                }
            }
        }

        private static void CheckExistUser(string username, PhotoShareContext context)
        {
            using (context)
            {
                if (!context.Users.Any(u => u.Username == username))
                {
                    throw new ArgumentException($"User [{username}] not found!");
                }
            }
            
        }

        public override Command Create(string[] data)
        {
            return new PrintFriendsListCommand(data);
        }
    }
}
