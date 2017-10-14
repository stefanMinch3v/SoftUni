using PhotoShare.Data;
using PhotoShare.Models;
using System;
using System.Linq;

namespace PhotoShare.Service
{
    public class SecurityService
    {
        private static SecurityService instance;
        private User loggedUser;

        protected SecurityService()
        {
        }

        public static SecurityService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SecurityService();
                }

                return instance;
            }
        }

        // TODO : Move all exceptions to the client layer !!! Make the methods boolean and check it inside the commands
        public void LoginUser(string username, string password)
        {
            using (var context = new PhotoShareContext())
            {
                User user = context.Users.SingleOrDefault(u => u.Username == username && u.Password == password);

                if (loggedUser != null)
                {
                    throw new ArgumentException("You should logout first!");
                }

                if (user == null)
                {
                    throw new ArgumentException("Invalid username or password!");
                }

                loggedUser = user;
            }
        }

        public void LogoutUser()
        {
            if (loggedUser == null)
            {
                throw new InvalidOperationException("You should log in first in order to logout.");
            }

            loggedUser = null;
        }

        public  User GetCurrentUser()
        {
            return loggedUser;
        }

        public  bool IsAuthenticated()
        {
            return loggedUser != null;
        }
    }
}
