using Microsoft.AspNetCore.Mvc;

namespace AreasAndAutomapperDemo.Areas.Products.Controllers
{
    // create this class in order not to write in every controller the magic string area("products").
    [Area("Products")]
    public abstract class ProductsBaseController : Controller
    {
    }
}
