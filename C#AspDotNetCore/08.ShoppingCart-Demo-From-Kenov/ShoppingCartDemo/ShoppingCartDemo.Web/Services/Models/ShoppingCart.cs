﻿namespace ShoppingCartDemo.Web.Services.Models
{
    using System.Collections.Generic;
    using System.Linq;

    public class ShoppingCart
    {
        private readonly IList<CartItem> items;

        public ShoppingCart()
        {
            this.items = new List<CartItem>();
        }

        public void AddToCart(int productId)
        {
            var cartItem = this.items.FirstOrDefault(i => i.ProductId == productId);

            if (cartItem == null)
            {
                cartItem = new CartItem
                {
                    ProductId = productId,
                    Quantity = 1
                };

                this.items.Add(cartItem);
            }
            else
            {
                cartItem.Quantity++;
            }
        }

        public void RemoveFromCart(int productId)
        {
            var cartItem = this.items.FirstOrDefault(i => i.ProductId == productId);

            if (cartItem != null)
            {
                this.items.Remove(cartItem);
            }
        }

        public IEnumerable<CartItem> Items => new List<CartItem>(this.items);

        public void Clear() => this.items.Clear();
    }
}
