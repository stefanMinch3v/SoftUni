﻿namespace LearningSystem.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class User : IdentityUser
    {
        [Required]
        [StringLength(UsernameMaxLength, MinimumLength = UsernameMinLength)]
        public string Name { get; set; }

        public DateTime Birthdate { get; set; }

        public List<StudentCourse> Courses { get; set; } = new List<StudentCourse>();

        public List<Article> Articles { get; set; } = new List<Article>();

        public List<Course> Trainings { get; set; } = new List<Course>();
    }
}
