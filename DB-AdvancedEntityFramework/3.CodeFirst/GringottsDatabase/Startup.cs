namespace GringottsDatabase
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            //task1 with wizzard database

            //var context = new GringottsContext();
            //context.Database.Initialize(true);

            #region CreateNewWizzardCommented
            /*var wizzard = new WizzardDeposit()
            {
                FirstName = "Ivan",
                LastName = "Hristov",
                Notes = "Nai golemiq prestypnik v Bylgaria",
                Age = 24,
                MagicWandCreator = "Abra kadabra sim salabim",
                MagiWandSize = 20,
                DepositGroup = "Gold Diggers",
                DepositStartDate = DateTime.Now,
                DepositAmount = 250000,
                DepositInterest = 1.5,
                DepositCharge = 500,
                DepositExpirationDate = DateTime.Parse("2018-01-01"),
                IsDepositExpired = false
            };

            var wizzardSecond = new WizzardDeposit()
            {
                FirstName = "Gosho",
                LastName = "Peshev",
                Notes = "Nai golemiq kradec v Bylgaria",
                Age = 64,
                MagicWandCreator = "Open sezami",
                MagiWandSize = 10,
                DepositGroup = "Diamond league",
                DepositStartDate = DateTime.Now,
                DepositAmount = 2500000,
                DepositInterest = 1.6,
                DepositCharge = 100,
                DepositExpirationDate = DateTime.Parse("2018-07-08"),
                IsDepositExpired = false
            };*/
            #endregion

            //context.WizzardDeposits.Add(wizzardSecond);
            //context.SaveChanges();
            //context.WizzardDeposits.ToList().ForEach(w => Console.WriteLine(w));

            //task2 with user database
            var context = new UserContext();
            //context.Database.Initialize(true);

            var user = new User()
            {
                Username = "Pesho",
                Age = 33,
                Email = "sssr@edu.com",
                IsDeleted = false,
                Password = "aaaaaaaA7e@",
                LastTimeLoggedIn = DateTime.Now,
                RegisteredOn = DateTime.Parse("2011-01-01"),
                ProfilePicture = File.ReadAllBytes(@"C:\Users\Admin\Desktop\cat.png")
            };

            //context.Users.Add(user);
            //context.SaveChanges();

            //task 11
            //PrintUsersByEmailProvider(context);

            //task 12
            //RemoveInactiveUsers(context);
        }

        private static void RemoveInactiveUsers(UserContext context)
        {
            Console.WriteLine("Format yyyy-mm-dd");
            var removeDate = DateTime.Parse(Console.ReadLine());

            int deletedUsers = 0;

            foreach (var user in context.Users)
            {
                if (user.LastTimeLoggedIn < removeDate)
                {
                    user.IsDeleted = true;
                    deletedUsers++;
                }
            }

            context.SaveChanges();

            if (deletedUsers == 0)
            {
                Console.WriteLine("No users have been deleted");
            }
            else if(deletedUsers == 1)
            {
                Console.WriteLine($"{deletedUsers} user has been deleted");
            }
            else
            {
                Console.WriteLine($"{deletedUsers} users have been deleted");
            }
        }

        private static void PrintUsersByEmailProvider(UserContext context)
        {
            var input = Console.ReadLine();
            var result = context.Users.Where(u => u.Email.EndsWith(input)).Select(u => u.Username + " " + u.Email);
            Console.WriteLine(string.Join(Environment.NewLine, result));
        }
    }
}
