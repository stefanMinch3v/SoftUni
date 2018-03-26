namespace ShoppingCartDemo.Web.Services.Models
{
    public class CartItem
    {
        // save the extra properties here (for example discounts for specific items)

        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
