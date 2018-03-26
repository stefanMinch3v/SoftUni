namespace ShoppingCartDemo.Web.Data.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public decimal ProductPrice { get; set; } // current price if changes later you will see what was before

        public int Quantity { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }
    }
}
