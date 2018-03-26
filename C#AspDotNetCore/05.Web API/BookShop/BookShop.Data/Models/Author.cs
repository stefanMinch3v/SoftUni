﻿namespace BookShop.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Author
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(AuthorNameMaxLength)]
        [MinLength(AuthorNameMinLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(AuthorNameMaxLength)]
        [MinLength(AuthorNameMinLength)]
        public string LastName { get; set; }

        public List<Book> Books { get; set; } = new List<Book>();
    }
}