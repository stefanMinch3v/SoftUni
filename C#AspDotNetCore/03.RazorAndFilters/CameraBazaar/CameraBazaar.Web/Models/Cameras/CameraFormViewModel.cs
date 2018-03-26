namespace CameraBazaar.Web.Models.Cameras
{
    using Data.Models.Enums;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CameraFormViewModel
    {
        public CameraMakeType Make { get; set; }

        [Required]
        [StringLength(100)]
        [RegularExpression(@"^[A-Z0-9-]+$", ErrorMessage = "Model must have only capital letters, allowed a '-' and/or numbers.")]
        public string Model { get; set; }

        public decimal Price { get; set; }

        [Range(0, 100)]
        public int Quantity { get; set; }

        [Range(1, 30)]
        [Display(Name = "Min Shutter Speed")]
        public int MinShutterSpeed { get; set; }

        [Display(Name = "Max Shutter Speed")]
        [Range(2000, 8000)]
        public int MaxShutterSpeed { get; set; }

        [Display(Name = "Min ISO")]
        public MinISO MinISO { get; set; }

        [Range(200, 409600)]
        [Display(Name = "Max ISO")]
        // validation attr dividable 100
        public int MaxISO { get; set; }

        [Display(Name = "Full Frame")]
        public bool IsFullFrame { get; set; }

        [Required]
        [StringLength(15)]
        [Display(Name = "Video Resolution")]
        public string VideoResolution { get; set; }

        public IEnumerable<LightMetering> LightMeterings { get; set; }

        [Required]
        [StringLength(6000)]
        public string Description { get; set; }

        [Required]
        [StringLength(2000, MinimumLength = 10)]
        [Display(Name = "Image URL")]
        [RegularExpression(@"^(http|https):\/\/.*$", ErrorMessage = "The url must start with either 'http://' or 'https://' .")]
        public string ImageUrl { get; set; }
    }
}
