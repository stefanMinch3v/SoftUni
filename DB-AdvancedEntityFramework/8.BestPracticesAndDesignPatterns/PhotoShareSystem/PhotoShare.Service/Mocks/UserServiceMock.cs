
namespace PhotoShare.Service.Mocks
{
    using PhotoShare.Data;
    using PhotoShare.Models;
    using PhotoShare.Service;
    using System;
    using System.Linq;

    public class UserServiceMock : UserService
    {
        private readonly PhotoShareContext context;

        public UserServiceMock(PhotoShareContext context)
        {
            this.context = context;
        }
        public override void RegisterUser(string username, string password, string secondPassword, string email)
        {
            using (context)
            {
                User user = new User
                {
                    Username = username,
                    Password = password,
                    Email = email,
                    IsDeleted = false,
                    RegisteredOn = DateTime.Now,
                    LastTimeLoggedIn = DateTime.Now
                };

                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public override User GetUserByUsername(string username)
        {
            using (context)
            {
                return context.Users
                                    .Include("BornTown")
                                    .Include("CurrentTown")
                                    .SingleOrDefault(u => u.Username == username);
            }
        }

        public override User GetUserWithFriends(string username)
        {
            return base.GetUserWithFriends(username);
        }

        public override bool IsTakenUsername(string username)
        {
            using (context)
            {
                return context.Users.Any(u => u.Username == username);
            }
        }

        public override bool IsUserExisting(string username)
        {
            return base.IsUserExisting(username);
        }

        public override void MakeFriends(string user1, string user2)
        {
            base.MakeFriends(user1, user2);
        }

        public override void RemoveUser(User user)
        {
            base.RemoveUser(user);
        }

        public override void UpdateUser(User user, string prop, string value)
        {
            base.UpdateUser(user, prop, value);
        }
    }
}
