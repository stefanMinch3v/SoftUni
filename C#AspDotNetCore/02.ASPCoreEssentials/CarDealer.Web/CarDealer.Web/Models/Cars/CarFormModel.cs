namespace CarDealer.Web.Models.Cars
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CarFormModel
    {
        private const int StringMaxLength = 50;
        private const int StringMinLength = 2;

        [Required]
        [MaxLength(StringMaxLength)]
        [MinLength(StringMinLength)]
        public string Make { get; set; }

        [Required]
        [MaxLength(StringMaxLength)]
        [MinLength(StringMinLength)]
        public string Model { get; set; }

        [Display(Name = "Travelled distance")]
        [Range(0, long.MaxValue, ErrorMessage = "Travelled distance must be positive number.")]
        public long TravelledDistance { get; set; }

        public IEnumerable<int> ChosenParts { get; set; }

        [Display(Name = "Parts")]
        public IEnumerable<SelectListItem> DropDownParts { get; set; }
    }
}
