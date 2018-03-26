namespace CarDealer.Services.Models.Suppliers
{
    using System.ComponentModel.DataAnnotations;

    public class SupplierBasicModel : SupplierModel
    {
        [Display(Name = "Importer")]
        public bool IsImporter { get; set; }
    }
}
