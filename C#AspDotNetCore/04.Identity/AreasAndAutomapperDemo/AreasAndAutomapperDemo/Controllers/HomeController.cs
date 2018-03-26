using AreasAndAutomapperDemo.Data;
using AreasAndAutomapperDemo.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace AreasAndAutomapperDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;

        public HomeController(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var applicationUser = new ApplicationUser
            {
                Email = "user@user",
                UserName = "user",
                Id = "1"
            };

            var mappedObj = this.mapper.Map<UserViewModel>(applicationUser);

            var users = this.db.Users
                .ProjectTo<UserViewModel>()
                .ToList();

            return View();
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
