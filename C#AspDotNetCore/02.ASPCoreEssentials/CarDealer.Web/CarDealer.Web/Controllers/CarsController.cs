namespace CarDealer.Web.Controllers
{
    using Data.Models;
    using Infrastructure.Filters;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Models.Cars;
    using Services;
    using System.Collections.Generic;
    using System.Linq;

    [Route("cars")]
    public class CarsController : Controller
    {
        private readonly ICarService cars;
        private readonly IPartService parts;

        public CarsController(
            ICarService cars, 
            IPartService parts)
        {
            this.cars = cars;
            this.parts = parts;
        }

        [Route("{make}" , Order = 2)]
        public IActionResult ByMake(string make)
        {
            var cars = this.cars.ByMake(make);

            return View(new CarsByMakeModel
            {
                Make = make,
                Cars = cars
            });
        }

        [Route("parts", Order = 1)]
        public IActionResult WithAllParts()
            => View(this.cars.WithAllParts());

        [Authorize]
        [Route(nameof(Create))]
        public IActionResult Create() 
            => View(new CarFormModel
            {
                DropDownParts = this.GetPartsListItems()
            });

        [Authorize]
        [HttpPost]
        [Log(OperationCode.Create)] // filter recording changes
        [Route(nameof(Create))]
        public IActionResult Create(CarFormModel carModel) // changed it from model to carModel cuz asp binding cannot bind properly if the name of the model is equal to some of the properties of the model in our case (car form)"model" to "Model"(car) its an old inherited issue, doesnt come from the core version
        {
            if (!ModelState.IsValid)
            {
                carModel.DropDownParts = GetPartsListItems();
                return View(carModel);
            }

            this.cars.Create(
                carModel.Make,
                carModel.Model,
                carModel.TravelledDistance,
                carModel.ChosenParts);

            return RedirectToAction(nameof(WithAllParts));
        }

        private IEnumerable<SelectListItem> GetPartsListItems()
            => this.parts
                .All()
                .Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.Name,
                });
    }
}
