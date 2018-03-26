namespace CarDealer.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Logger
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        public OperationCode Operation { get; set; }

        [Required]
        [MaxLength(50)]
        public string ModifiedTable { get; set; }

        public DateTime Time { get; set; }
    }
}
