namespace CarDealer.Services.Models.Sales
{
    using System.ComponentModel.DataAnnotations;

    public class SaleReviewModel
    {
        public bool IsYoungDriver { get; set; }

        public string Customer { get; set; }

        public int CustomerId { get; set; }

        public string Car { get; set; }

        public int CarId { get; set; }

        public int Discount { get; set; }

        public double Price { get; set; }

        [Display(Name = "Final price")]
        public double FinalPrice
            => this.Price - (this.Price * (this.SumYoungDriverDiscount() / 100));

        private double SumYoungDriverDiscount()
            => this.IsYoungDriver ? this.Discount + 5 : this.Discount;
    }
}
