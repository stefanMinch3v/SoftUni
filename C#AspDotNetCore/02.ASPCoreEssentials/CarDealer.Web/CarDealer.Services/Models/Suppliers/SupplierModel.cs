﻿namespace CarDealer.Services.Models.Suppliers
{
    using System.ComponentModel.DataAnnotations;

    public class SupplierModel
    {
        public int Id { get; set; }
        
        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
