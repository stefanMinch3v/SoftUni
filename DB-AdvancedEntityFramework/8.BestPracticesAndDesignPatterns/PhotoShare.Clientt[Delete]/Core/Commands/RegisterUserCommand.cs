namespace PhotoShare.Client.Core.Commands
{
    using System;

    using Models;
    using PhotoShare.Data;
    using System.Linq;

    public class RegisterUserCommand : Command
    {
        public RegisterUserCommand(string[] data) 
            : base(data)
        {
        }

        public override Command Create(string[] data)
        {
            return new RegisterUserCommand(data);
        }

        // RegisterUser <username> <password> <repeat-password> <email>
        public override void Execute()
        {
            string username = base.data[1];
            string password = base.data[2];
            string repeatPassword = base.data[3];
            string email = base.data[4];

            CheckPasswords(password, repeatPassword);

            User user = new User
            {
                Username = username,
                Password = password,
                Email = email,
                IsDeleted = false,
                RegisteredOn = DateTime.Now,
                LastTimeLoggedIn = DateTime.Now
            };

            using (PhotoShareContext context = new PhotoShareContext())
            {
                CheckExistingUsername(user, context);

                context.Users.Add(user);
                context.SaveChanges();
            }

            Console.WriteLine("User " + user.Username + " was registered successfully!");
        }

        private void CheckExistingUsername(User user, PhotoShareContext context)
        {
            using (context)
            {
                var existingUser = context.Users.FirstOrDefault(u => u.Username == user.Username);
                if (existingUser != null)
                {
                    throw new InvalidOperationException($"Username [{user.Username}] is already taken!");
                }
            }
        }

        private void CheckPasswords(string password, string repeatPassword)
        {
            if (password != repeatPassword)
            {
                throw new ArgumentException("Passwords do not match!");
            }
        }
    }
}
