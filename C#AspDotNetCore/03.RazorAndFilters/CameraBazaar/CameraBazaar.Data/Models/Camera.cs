﻿namespace CameraBazaar.Data.Models
{
    using Enums;
    using System.ComponentModel.DataAnnotations;

    public class Camera
    {
        public int Id { get; set; }

        public CameraMakeType Make { get; set; }

        [Required]
        [MaxLength(100)]
        [RegularExpression(@"^[A-Z0-9-]+$")]
        public string Model { get; set; }

        public decimal Price { get; set; }

        [Range(0, 100)]
        public int Quantity { get; set; }

        [Range(1, 30)]
        public int MinShutterSpeed { get; set; }

        [Range(2000, 8000)]
        public int MaxShutterSpeed { get; set; }

        public MinISO MinISO { get; set; }

        [Range(200, 409600)]
        // validation attr dividable 100
        public int MaxISO { get; set; }

        public bool IsFullFrame { get; set; }

        [Required]
        [MaxLength(15)]
        public string VideoResolution { get; set; }

        public LightMetering LightMetering { get; set; }

        [Required]
        [MaxLength(6000)]
        public string Description { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(2000)]
        [RegularExpression(@"^(http|https):\/\/.*$")]
        public string ImageUrl { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }
    }
}
