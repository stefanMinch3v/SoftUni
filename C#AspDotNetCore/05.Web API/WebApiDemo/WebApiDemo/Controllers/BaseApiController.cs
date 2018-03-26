using Microsoft.AspNetCore.Mvc;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    //[Produces("application/xml")] // for xml response only
    public class BaseApiController : Controller
    {
    }
}
