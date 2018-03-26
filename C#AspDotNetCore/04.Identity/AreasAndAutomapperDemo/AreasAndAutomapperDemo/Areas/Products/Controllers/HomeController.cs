namespace AreasAndAutomapperDemo.Areas.Products.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [Area("Products")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
