namespace ShoppingCartDemo.Web.Controllers
{
    using Data;
    using Data.Models;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Models.ShoppingCart;
    using Services;
    using ShoppingCartDemo.Web.Services.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartManager shoppingCartManager;
        private readonly ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> userManager;

        public ShoppingCartController(
            IShoppingCartManager shoppingCartManager,
            ApplicationDbContext db,
            UserManager<ApplicationUser> userManager)
        {
            this.shoppingCartManager = shoppingCartManager;
            this.db = db;
            this.userManager = userManager;
        }

        public IActionResult Items()
        {
            var shoppingCartId = this.HttpContext.Session.GetShoppingCartId();

            var items = this.shoppingCartManager.GetItems(shoppingCartId);

            var itemsWithDetails = this.GetCartItems(items);

            return View(itemsWithDetails);
        }

        public IActionResult AddToCart(int id)
        {
            var shoppingCartId = this.HttpContext.Session.GetShoppingCartId();

            this.shoppingCartManager.AddToCart(shoppingCartId, id);

            return RedirectToAction(nameof(Items));
        }

        [Authorize]
        public IActionResult FinishOrder()
        {
            var shoppingCartId = this.HttpContext.Session.GetShoppingCartId();

            var items = this.shoppingCartManager.GetItems(shoppingCartId);

            // if items == null badrequest/return/notfound

            var itemsWithDetails = this.GetCartItems(items);

            var order = new Order
            {
                UserId = this.userManager.GetUserId(User),
                TotalPrice = itemsWithDetails.Sum(i => i.Price * i.Quantity)
            };

            foreach (var item in itemsWithDetails)
            {
                order.Items.Add(new OrderItem
                {
                    ProductId = item.ProductId,
                    ProductPrice = item.Price,
                    Quantity = item.Quantity
                });
            }

            this.db.Orders.Add(order);
            this.db.SaveChanges();

            this.shoppingCartManager.Clear(shoppingCartId);

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        private List<CartItemViewModel> GetCartItems(IEnumerable<CartItem> cartItems)
        {
            var itemIds = cartItems.Select(ci => ci.ProductId);

            var items = this.db.Products
                  .Where(p => itemIds.Contains(p.Id))
                  .Select(p => new CartItemViewModel
                  {
                      ProductId = p.Id,
                      Title = p.Title,
                      Price = p.Price
                  })
                  .ToList();

            var itemQuantities = cartItems.ToDictionary(i => i.ProductId, i => i.Quantity);

            items.ForEach(i => i.Quantity = itemQuantities[i.ProductId]);

            return items;
        }
    }
}
