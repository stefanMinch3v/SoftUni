namespace CameraBazaar.Services
{
    using Models.Users;
    using System.Collections.Generic;

    public interface IUserService
    {
        UserDetailsModel ByUsername(string username);

        bool Existing(string username);

        void Update(string id, string email, string phone, string newPassword);

        void UpdateLastLogin(string username);

        IEnumerable<ListUserRolesModel> All();

        bool ExistingById(string id);      
    }
}
