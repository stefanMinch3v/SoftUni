namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Data;
    using System;
    using System.Linq;

    public class DeleteUser : Command
    {
        public DeleteUser(string[] data) 
            : base(data)
        {
        }

        public override Command Create(string[] data)
        {
            return new DeleteUser(data);
        }

        // DeleteUser <username>
        public override void Execute()
        {
            string username = base.data[1];
            using (PhotoShareContext context = new PhotoShareContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Username == username);
                if (user == null)
                {
                    throw new InvalidOperationException($"User with {username} was not found!");
                }

                // TODO: Delete User by username (only mark him as inactive)
                if (user.IsDeleted == true)
                {
                    throw new InvalidOperationException($"User [{username}] is already deleted!");
                }

                user.IsDeleted = true;
                context.SaveChanges();

                Console.WriteLine($"User {username} was deleted from the database!");
            }
        }
    }
}
