namespace CarDealer.Web.Models.Sales
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class SaleFormModel
    {
        [Range(0, 100, ErrorMessage = "Integer number from 0 to 100.")]
        public int Discount { get; set; }

        public int CustomerId { get; set; }

        [Display(Name = "Customer")]
        public IEnumerable<SelectListItem> DropDownCustomers { get; set; }

        public int CarId { get; set; }

        [Display(Name = "Car")]
        public IEnumerable<SelectListItem> DropDownCars { get; set; }
    }
}
