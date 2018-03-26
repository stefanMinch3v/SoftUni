namespace CarDealer.Services.Models.Customers
{
    using Sales;
    using System.Collections.Generic;
    using System.Linq;

    public class CustomerWithMoneyAndCarModel
    {
        public string Name { get; set; }

        public bool IsYoungDriver { get; set; }

        public IEnumerable<SaleModel> BoughtCars { get; set; }

        public double? TotalSpendMoney
            => this.BoughtCars
                .Sum(c => c.Price * (1 - c.Discount))
                * (this.IsYoungDriver? 0.95 : 1);
    }
}