using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class UserFriend
    {
        [Key, Column(Order = 0)]
        public int UserId { get; set; }

        [Key, Column(Order = 1)]
        public int FriendId { get; set; }

        public virtual User User { get; set; }

        public virtual User Friend { get; set; }

    }
}
