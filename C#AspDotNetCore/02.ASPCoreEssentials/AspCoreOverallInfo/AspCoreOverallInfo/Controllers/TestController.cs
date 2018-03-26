namespace AspCoreOverallInfo.Controllers
{
    using AspCoreOverallInfo.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class TestController : Controller
    {
        [Authorize] // means it will works only with logged in users !!!
        public IActionResult Create()
        {
            var email = User.Identity.Name; // to get the current user email address

            //if (User.Identity.IsAuthenticated) // check autorization another way 
            //{
            //    ///
            //}

            //ViewData["Name"] = "Gosho"; // way of displaying info but not quite good
            //ViewBag.Name = "Gosho" // way of displaying info but again not quite good

            //return View();

            var model = new CatTestModel // another way of displaying , the correct way of using it !!
            {
                Id = 1,
                Name = "Ivan"
            };

            return View(model);
        }

        public IActionResult Index() => View();

        [HttpPost]
        public IActionResult Index(CatTestModel model)
        {
            if (ModelState.IsValid) // check the attribute validations on the model !
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            return View(model);
        }

        public IActionResult Image()
        {
            return File("/images/cat.jpg", "image/jpeg"); // for example if you want to return imgaes or pdf or whatever to the user.
        }
    }
}
