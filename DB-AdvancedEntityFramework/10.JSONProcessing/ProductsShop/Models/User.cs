namespace Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class User
    {
        public User()
        {
            this.BoughtProducts = new HashSet<Product>();
            this.SoldProducts = new HashSet<Product>();
            this.Friends = new HashSet<UserFriend>();
        }

        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }
        
        [Required]
        [MinLength(3)]
        public string LastName { get; set; }

        public int? Age { get; set; }

        public virtual ICollection<Product> BoughtProducts { get; set; }

        public virtual ICollection<Product> SoldProducts { get; set; }

        public virtual ICollection<UserFriend> Friends { get; set; }

        [NotMapped]
        public string FullName => this.FirstName + " " + this.LastName;

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} {this.Age}";
        }
    }
}
