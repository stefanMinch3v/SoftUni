using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingCartDemo.Web.Models;
using ShoppingCartDemo.Web.Data;
using Microsoft.AspNetCore.Http;

namespace ShoppingCartDemo.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext db;

        public HomeController(ApplicationDbContext db)
        {
            this.db = db;
        }


        // its a good idea to keep all the items from the shopping cart into the memory/session til the moment user go for a real purchase of the cart - then its a good idea to have class cart with all its properties and table in the db in order to buy the products

        public IActionResult Index()
        {
            var products = this.db.Products.OrderByDescending(p => p.Id).ToList();

            return View(products);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
