using Microsoft.AspNetCore.Mvc;

namespace AreasAndAutomapperDemo.Areas.Products.Controllers
{
    public class CategoriesController : ProductsBaseController
    {
        public IActionResult Create() => View();
    }
}
