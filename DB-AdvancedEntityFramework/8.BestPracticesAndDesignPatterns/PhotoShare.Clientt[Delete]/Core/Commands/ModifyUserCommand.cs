namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Data;
    using System;
    using System.Linq;
    using System.Reflection;

    public class ModifyUserCommand : Command
    {
        public ModifyUserCommand(string[] data) 
            : base(data)
        {
        }

        // ModifyUser <username> <property> <new value>
        // For example:
        // ModifyUser <username> Password <NewPassword>
        // ModifyUser <username> BornTown <newBornTownName>
        // ModifyUser <username> CurrentTown <newCurrentTownName>
        // !!! Cannot change username
        public override void Execute()
        {
            string username = base.data[1];
            string property = base.data[2];
            string newValue = base.data[3];

            using (var context = new PhotoShareContext())
            {
                CheckExistingUser(username, context);

                var currentUser = context.Users.First(u => u.Username == username);

                CheckInExistingProperties(property, currentUser);

                CheckExistingTownAndCorrectPassword(property, context);

                currentUser.GetType().GetProperty(property, BindingFlags.Public).SetValue(property, newValue);
                context.SaveChanges();
                Console.WriteLine($"User [{currentUser.Username}] [{property}] is [{newValue}].");
            }
        }

        private static void CheckExistingTownAndCorrectPassword(string property, PhotoShareContext context)
        {
            using (context)
            {
                if (property == "Password")
                {
                    if (!property.Any(c => char.IsLower(c)) || !property.Any(c => char.IsDigit(c)))
                    {
                        throw new ArgumentException("Invalid Password");
                    }
                }
                else if (property == "BornTown" || property == "CurrentTown")
                {
                    if (!context.Towns.Any(t => t.Name == property))
                    {
                        throw new ArgumentException($"Town [{property}] not found!");
                    }
                }
            }   
        }

        private static void CheckInExistingProperties(string property, Models.User currentUser)
        {
            if (!currentUser.GetType().GetProperties().Equals(property))
            {
                throw new ArgumentException($"Property [{property}] not supported!");
            }
        }

        private static void CheckExistingUser(string username, PhotoShareContext context)
        {
            using (context)
            {
                var user = context.Users.FirstOrDefault(u => u.Username == username);
                if (user == null)
                {
                    throw new ArgumentException($"User [{username}] not found!");
                }
            }
            
        }

        public override Command Create(string[] data)
        {
            return new ModifyUserCommand(data);
        }
    }
}
