namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Data;
    using System;
    using System.Linq;

    public class MakeFriendsCommand : Command
    {
        public MakeFriendsCommand(string[] data) 
            : base(data)
        {
        }

        // MakeFriends <username1> <username2>
        public override void Execute()
        {
            string firstUser = base.data[1];
            string secondUser = base.data[2];

            using (var context = new PhotoShareContext())
            {
                CheckUsers(firstUser, secondUser, context);
                CheckExistingFriends(firstUser, secondUser, context);

                var secondUserToAdd = context.Users.First(u => u.Username == secondUser);
                context.Users.First(u => u.Username == firstUser).Friends.Add(secondUserToAdd);
                context.SaveChanges();

                Console.WriteLine($"Friend [{secondUser}] added to [{firstUser}]");
            }
        }

        private static void CheckExistingFriends(string firstUser, string secondUser, PhotoShareContext context)
        {
            using (context)
            {
                if (context.Users.First(u => u.Username == firstUser).Friends.Any(f => f.Username == secondUser))
                {
                    throw new InvalidOperationException($"[{secondUser}] is already a friend to [{firstUser}]");
                }
            }           
        }

        private static void CheckUsers(string firstUser, string secondUser, PhotoShareContext context)
        {
            using (context)
            {
                var allUsers = context.Users.ToArray();
                if (!allUsers.Any(u => u.Username == firstUser))
                {
                    throw new ArgumentException($"[{firstUser}] not found!");
                }
                else if (!allUsers.Any(u => u.Username == secondUser))
                {
                    throw new ArgumentException($"[{secondUser}] not found!");
                }
            } 
        }

        public override Command Create(string[] data)
        {
            return new MakeFriendsCommand(data);
        }
    }
}
