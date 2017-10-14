namespace PhotoShare.Service
{
    using Models;
    using Data;
    using System;
    using System.Linq;
    using System.Data.Entity;

    public class UserService
    {
        public virtual void RegisterUser(string username, string password, string secondPassword, string email)
        {
            using (PhotoShareContext context = new PhotoShareContext())
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

        public virtual bool IsTakenUsername(string username)
        {
            using (var context = new PhotoShareContext())
            {
                return context.Users.Any(u => u.Username == username);
            }
        }

        public virtual User GetUserByUsername(string username)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                return context.Users
                                    .Include("BornTown")
                                    .Include("CurrentTown")
                                    .SingleOrDefault(u => u.Username == username);
            }
        }

        public virtual void UpdateUser(User user, string prop, string value)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                //TODO: doesnt work if the current and born towns are the same !!!
                TownService townService = new TownService();
                var town = townService.GetTownByName(value);
                var dummyTown = new Town()
                {
                    Name = "FailTest",
                    Country = "Exception"
                };

                context.Towns.Add(dummyTown);

                var userToBeChanged = context.Users
                                                .Include("BornTown")
                                                .Include("CurrentTown")
                                                .First(u => u.Username == user.Username);

                try
                {
                    if (userToBeChanged.CurrentTown.Name == null)
                    {
                    }
                }
                catch (Exception)
                {
                    userToBeChanged.CurrentTown = dummyTown;
                }

                try
                {
                    if (userToBeChanged.BornTown.Name == null)
                    {
                    }
                }
                catch (Exception)
                {
                    userToBeChanged.BornTown = dummyTown;
                }

                if (userToBeChanged.BornTown.Name != value)
                {
                    if (prop == "BornTown")
                    {
                        userToBeChanged.BornTown = town;
                        context.Entry(town).State = EntityState.Unchanged;
                    }
                }

                if (userToBeChanged.CurrentTown.Name != value)
                {
                    if (prop == "CurrentTown")
                    {
                        userToBeChanged.CurrentTown = town;
                        context.Entry(town).State = EntityState.Unchanged;
                    }
                }

                context.Towns.Remove(dummyTown);

                context.Entry(userToBeChanged).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public virtual void RemoveUser(User user)
        {
            using (var context = new PhotoShareContext())
            {
                context.Users.Attach(user);
                context.Entry(user).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public virtual void MakeFriends(string user1, string user2)
        {
            using (var context = new PhotoShareContext())
            {
                var firstUser = context.Users.SingleOrDefault(u => u.Username == user1);
                var secondUserToAdd = context.Users.SingleOrDefault(u => u.Username == user2);

                firstUser.Friends.Add(secondUserToAdd);

                context.SaveChanges();
            }
        }

        public virtual bool IsUserExisting(string username)
        {
            using (var context = new PhotoShareContext())
            {
                return context.Users.Any(u => u.Username == username);
            }
        }

        public virtual User GetUserWithFriends(string username)
        {
            using (var context = new PhotoShareContext())
            {
                return context.Users.Include("Friends").FirstOrDefault(u => u.Username == username);
            }
        }
    }
}
