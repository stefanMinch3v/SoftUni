namespace BookLy.ViewModels.Account
{
    using System.Collections.Generic;
    using System.ComponentModel;

    using BookLy.Models;

    public class AccountDetailsViewModel
    {
        [DisplayName("Username")]
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public Gender Gender { get; set; }

        [DisplayName("Profile Picture")]
        public string ProfilePictureBase64Url { get; set; }

        public IEnumerable<Book> Books { get; set; }
    }
}
