namespace News.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;

    public class User : IdentityUser
    {
        public List<News> News { get; set; } = new List<News>();
    }
}
