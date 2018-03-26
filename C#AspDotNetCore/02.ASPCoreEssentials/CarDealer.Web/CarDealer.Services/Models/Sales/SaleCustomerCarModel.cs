namespace CarDealer.Services.Models.Sales
{
    using Cars;
    using Customers;
    using System.Collections.Generic;

    public class SaleCustomerCarModel
    {
        public IEnumerable<CustomerBasicModel> Customers { get; set; }

        public IEnumerable<CarBasicModel> Cars { get; set; }
    }
}
