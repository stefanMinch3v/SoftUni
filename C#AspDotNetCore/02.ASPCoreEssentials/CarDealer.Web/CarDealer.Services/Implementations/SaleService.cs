namespace CarDealer.Services.Implementations
{
    using Data;
    using Data.Models;
    using Infrastructure.Extensions;
    using Models.Cars;
    using Models.Customers;
    using Models.Sales;
    using System.Collections.Generic;
    using System.Linq;

    public class SaleService : ISaleService
    {
        private readonly CarDealerDbContext db;

        public SaleService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public void Create(int customerId, int carId, double discount)
        {
            var sale = new Sale
            {
                CarId = carId,
                CustomerId = customerId,
                Discount = discount
            };

            this.db.Sales.Add(sale);
            this.db.SaveChanges();
        }

        private IEnumerable<SaleListModel> SaleListModelQuerry()
            => this.db.Sales
                .OrderByDescending(s => s.Id)
                .Select(s => new SaleListModel
                {
                    Id = s.Id,
                    CustomerName = s.Customer.Name,
                    IsYoungDriver = s.Customer.IsYoungDriver, // these 5 can be mapped with automapper
                    Discount = s.Discount,
                    Price = s.Car.Parts.Sum(cp => cp.Part.Price),
                });

        public IEnumerable<SaleListModel> AllListings()
            => this.SaleListModelQuerry()
                .ToList();

        public SaleCustomerCarModel All()
        {
            var cars = this.db.Cars
                .Select(c => new CarBasicModel
                {
                    Id = c.Id,
                    MakeModel = $"{c.Make} {c.Model}"
                })
                .DistinctBy(c => c.MakeModel)
                .ToList();

            var customers = this.db.Customers
                .Select(c => new CustomerBasicModel
                {
                    Id = c.Id,
                    IsYoungDriver = c.IsYoungDriver,
                    Name = c.Name
                })
                .ToList();

            return new SaleCustomerCarModel
            {
                Cars = cars,
                Customers = customers
            };
        }

        public SaleDetailsModel Details(int id)
            => this.db.Sales
                .Where(s => s.Id == id)
                .Select(s => new SaleDetailsModel
                {
                    Id = s.Id,
                    CustomerName = s.Customer.Name,
                    IsYoungDriver = s.Customer.IsYoungDriver, // these 5 can be mapped with automapper
                    Discount = s.Discount,
                    Price = s.Car.Parts.Sum(cp => cp.Part.Price),
                    Car = new CarModel
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    }
                })
                .FirstOrDefault();

        public IEnumerable<SaleListModel> AllByGivenDiscount(double discount)
        => this.SaleListModelQuerry()
            .Where(s => s.Discount == discount)
            .ToList();

        public IEnumerable<SaleListModel> AllWithDiscount()
        => this.SaleListModelQuerry()
            .Where(s => s.Discount != 0)
            .ToList();
    }
}
