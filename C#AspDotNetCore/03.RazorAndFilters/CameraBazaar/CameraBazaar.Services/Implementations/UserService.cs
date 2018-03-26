namespace CameraBazaar.Services.Implementations
{
    using Data;
    using Models.Cameras;
    using Models.Users;
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class UserService : IUserService
    {
        private readonly BazaarDbContext db;

        public UserService(BazaarDbContext db)
        {
            this.db = db;
        }

        public UserDetailsModel ByUsername(string username)
            => this.db.Users
                .Where(u => u.UserName == username)
                .Select(u => new UserDetailsModel
                {
                    Id = u.Id,
                    Username = u.UserName,
                    Email = u.Email,
                    Phone = u.PhoneNumber,
                    LastLoginTime = u.LastLoginTime,
                    Cameras = u.Cameras
                        .Select(c => new CameraListModel
                        {
                            Id = c.Id,
                            ImageUrl = c.ImageUrl,
                            Make = c.Make,
                            Model = c.Model,
                            Price = c.Price,
                            Quantity = c.Quantity
                        })
                })
                .FirstOrDefault();

        public void Update(string id, string email, string phone, string newPassword)
        {
            var user = this.db.Users.Find(id);

            if (user == null)
            {
                return;
            }

            if (!string.IsNullOrEmpty(newPassword))
            {
                user.PasswordHash = newPassword;
            }

            // might create one more check of an existing email
            user.Email = email;
            user.PhoneNumber = phone;

            this.db.SaveChanges();
        }

        public bool Existing(string username)
            => this.db.Users.Any(u => u.UserName == username);

        public void UpdateLastLogin(string username)
        {
            var user = this.db.Users.FirstOrDefault(u => u.UserName == username);

            if (user == null)
            {
                return;
            }

            if (user.CountSuccessfulLogin != 0)
            {
                user.LastLoginTime = DateTime.UtcNow;
            }

            user.CountSuccessfulLogin++;

            this.db.Users.Update(user);
            this.db.SaveChanges();
        }

        public IEnumerable<ListUserRolesModel> All()
        {
            var userRoles = this.db.UserRoles.ToList();
            var roles = this.db.Roles.ToList();

            // working but it might be improved ?
            return this.db.Users
                    .OrderBy(u => u.UserName)
                    .Select(u => new ListUserRolesModel
                    {
                        Id = u.Id,
                        Username = u.UserName,
                        Role = roles
                            .FirstOrDefault(r => r.Id == (userRoles
                                .FirstOrDefault(ur => ur.UserId == u.Id).RoleId)).Name
                    })
                    .ToList();
        }

        public bool ExistingById(string id)
            => this.db.Users.Any(u => u.Id == id);

        //public void UpdateUserRoleToRestrict(string username)
        //{
        //    var userId = this.db.Users.FirstOrDefault(u => u.UserName == username).Id;

        //    var userRole = this.db.UserRoles.FirstOrDefault(ur => ur.UserId == userId).RoleId;

        //    var role = this.db.Roles.FirstOrDefault(r => r.Name == "RestrictedToAddCameras");
        //}
    }
}
