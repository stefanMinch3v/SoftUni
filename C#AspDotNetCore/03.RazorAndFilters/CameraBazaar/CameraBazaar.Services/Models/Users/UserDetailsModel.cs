namespace CameraBazaar.Services.Models.Users
{
    using Cameras;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class UserDetailsModel
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public bool IsOwner { get; set; }
        
        public DateTime? LastLoginTime { get; set; }

        public int InStock() => this.Cameras.Where(c => c.Quantity > 0).Count();

        public int OutOfStock() => this.Cameras.Where(c => c.Quantity < 1).Count();

        public IEnumerable<CameraListModel> Cameras { get; set; }
    }
}
