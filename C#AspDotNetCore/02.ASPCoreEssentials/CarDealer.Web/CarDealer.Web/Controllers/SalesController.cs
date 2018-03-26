namespace CarDealer.Web.Controllers
{
    using Data.Models;
    using Infrastructure.Extensions;
    using Infrastructure.Filters;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Models.Sales;
    using Services;
    using Services.Models.Sales;
    using System;
    using System.Linq;

    [Route("sales")]
    public class SalesController : Controller
    {
        private readonly ISaleService sales;
        private readonly ICarService cars;
        private readonly ICustomerService customers;

        public SalesController(
            ISaleService sales, 
            ICarService cars, 
            ICustomerService customers)
        {
            this.sales = sales;
            this.cars = cars;
            this.customers = customers;
        }

        [Route("")]
        public IActionResult All()
            => View(this.sales.AllListings());

        [Route("{id}")]
        public IActionResult Details(int id)
            => this.ViewOrNotFound(this.sales.Details(id));

        [Route(nameof(Discounted))]
        public IActionResult Discounted()
            => View(this.sales.AllWithDiscount());

        [Route("discounted/{percent}")]
        public IActionResult Discounted(double percent)
            => this.ViewOrNotFound(this.sales.AllByGivenDiscount(percent));

        [Route(nameof(Create))]
        public IActionResult Create() => View(GetSaleModel());

        [Route(nameof(ReviewCreate))]
        public IActionResult ReviewCreate(SaleFormModel saleModel)
        {
            if (!ModelState.IsValid)
            {
                saleModel = this.GetSaleModel();
                return View(saleModel);
            }

            var car = this.cars.ById(saleModel.CarId);
            var customer = this.customers.ByIdBasic(saleModel.CustomerId);

            var reviewModel = new SaleReviewModel
            {
                Car = car.MakeModel,
                CarId = car.Id,
                Customer = customer.Name,
                CustomerId = customer.Id,
                Discount = saleModel.Discount,
                Price = car.Price,
                IsYoungDriver = customer.IsYoungDriver
            };

            return View(reviewModel);
        }

        [HttpPost]
        [Route(nameof(FinalizeCreate))]
        [Log(OperationCode.Create)] // filter recording changes
        public IActionResult FinalizeCreate(SaleReviewModel saleModel)
        {
            var existingCustomer = this.customers.Exists(saleModel.CustomerId);
            var existingCar = this.cars.Exists(saleModel.CarId);

            if (!existingCustomer || !existingCar)
            {
                return NotFound();
            }

            if (saleModel.Discount > 100)
            {
                saleModel.Discount = 100;
            }

            this.sales.Create(
                saleModel.CustomerId,
                saleModel.CarId,
                saleModel.Discount);

            return RedirectToAction(nameof(All));
        }

        private SaleFormModel GetSaleModel()
        {
            var saleModel = this.sales.All();

            return new SaleFormModel
            {
                DropDownCars = saleModel.Cars
                    .Select(sm => new SelectListItem
                    {
                        Value = sm.Id.ToString(),
                        Text = sm.MakeModel
                    }),
                DropDownCustomers = saleModel.Customers
                    .Select(sm => new SelectListItem
                    {
                        Value = sm.Id.ToString(),
                        Text = sm.Name
                    })
            };
        }
    }
}
