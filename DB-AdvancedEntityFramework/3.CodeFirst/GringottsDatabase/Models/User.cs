namespace GringottsDatabase.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;

    public class User
    {
        private string email;
        //private string password; make the checks in the setter if regularexpression attrubute doesn't exists, look at email field

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(30)]
        public string Username { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(50)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{8,}")]
        public string Password { get; set; }

        [Required]
        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                string pattern = "@{1}";
                Regex regex = new Regex(pattern);

                if (!regex.IsMatch(pattern))
                {
                    throw new ArgumentException("Invalid email");
                }

                this.email = value;
            }
        }

        [MaxLength(1024*1024)]
        public byte[] ProfilePicture { get; set; }

        public DateTime? RegisteredOn { get; set; }

        public DateTime? LastTimeLoggedIn { get; set; }

        [Range(1, 120)]
        public int Age { get; set; }

        public bool IsDeleted { get; set; }
    }
}
