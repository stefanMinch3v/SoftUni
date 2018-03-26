namespace CarDealer.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Car
    {
        private const int StringMaxLength = 50;

        public int Id { get; set; }

        [Required]
        [MaxLength(StringMaxLength)]
        public string Make { get; set; }

        [Required]
        [MaxLength(StringMaxLength)]
        public string Model { get; set; }

        [Range(0, long.MaxValue)]
        public long TravelledDistance { get; set; }

        public ICollection<Sale> Sales { get; set; } = new List<Sale>();

        public ICollection<PartCar> Parts { get; set; } = new List<PartCar>();
    }
}
