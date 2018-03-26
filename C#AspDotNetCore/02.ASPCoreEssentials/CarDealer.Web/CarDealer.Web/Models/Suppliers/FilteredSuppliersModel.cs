namespace CarDealer.Web.Models.Suppliers
{
    using Services.Models.Suppliers;
    using System.Collections.Generic;

    public class FilteredSuppliersModel
    {
        public string Type { get; set; }

        public IEnumerable<SupplierListingModel> Suppliers { get; set; }
    }
}
