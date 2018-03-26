namespace BookShop.Api.Models.Authors
{
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class AuthorRequestModel
    {
        [Required]
        [MaxLength(AuthorNameMaxLength)]
        [MinLength(AuthorNameMinLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(AuthorNameMaxLength)]
        [MinLength(AuthorNameMinLength)]
        public string LastName { get; set; }
    }
}
