namespace CarDealer.Services.Models.Sales
{
    public class SaleListModel : SaleModel
    {
        public int Id { get; set; }

        public string CustomerName { get; set; }

        public bool IsYoungDriver { get; set; }

        public decimal DiscountedPrice =>
            (decimal)(this.Price.Value - (this.Price.Value * ( this.Discount / 100)));
    }
}
