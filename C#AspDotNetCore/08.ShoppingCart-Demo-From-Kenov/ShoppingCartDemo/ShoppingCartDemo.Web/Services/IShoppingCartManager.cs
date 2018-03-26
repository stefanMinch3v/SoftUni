namespace ShoppingCartDemo.Web.Services
{
    using Models;
    using System.Collections.Generic;

    public interface  IShoppingCartManager
    {
        void AddToCart(string id, int productId);

        // void UpdateQuantity(string id, CartItem cartItem);

        void RemoveFromCart(string id, int productId);

        IEnumerable<CartItem> GetItems(string id);

        void Clear(string id);
    }
}
