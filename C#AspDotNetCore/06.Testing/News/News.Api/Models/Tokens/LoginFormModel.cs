namespace News.Api.Models.Tokens
{
    using System.ComponentModel.DataAnnotations;

    public class LoginFormModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
