namespace CameraBazaar.Web.Models.Users
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class EditUserViewModel
    {
        [StringLength(20, MinimumLength = 4)]
        [RegularExpression("[a-zA-Z]+", ErrorMessage = "Username must contain only letters.")]
        public string Username { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^\+[0-9]{10,12}$", ErrorMessage = "Phone must start with a '+' sign and contain from 10 to 12 digits.")]
        public string Phone { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Last login:")]
        public DateTime? LastLoginTime { get; set; }
    }
}
