namespace CarDealer.Services.Implementations
{
    using Data;
    using Data.Models;
    using Models;
    using Models.Customers;
    using Models.Sales;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CustomerService : ICustomerService
    {
        private readonly CarDealerDbContext db;

        public CustomerService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public void Create(string name, DateTime dateOfBirth, bool isYoungDriver)
        {
            var customer = new Customer
            {
                Name = name,
                BirthDate = dateOfBirth,
                IsYoungDriver = isYoungDriver
            };

            this.db.Customers.Add(customer);
            this.db.SaveChanges();
        }

        public void Edit(int id, string name, DateTime dateOfBirth, bool isYoungDriver)
        {
            var existingCustomer = this.db.Customers.Find(id);

            if (existingCustomer == null)
            {
                return;
            }

            existingCustomer.Name = name;
            existingCustomer.BirthDate = dateOfBirth;
            existingCustomer.IsYoungDriver = isYoungDriver;

            this.db.SaveChanges();
        }

        public bool Exists(int id)
            => this.db.Customers.Any(c => c.Id == id);

        public CustomerModel ById(int id)
            => this.db.Customers
                .Where(c => c.Id == id)
                .Select(c => new CustomerModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    BirthDate = c.BirthDate,
                    IsYoungDriver = c.IsYoungDriver
                })
                .FirstOrDefault();

        public CustomerBasicModel ByIdBasic(int id)
            => this.db.Customers
                .Where(c => c.Id == id)
                .Select(c => new CustomerBasicModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    IsYoungDriver = c.IsYoungDriver
                })
                .FirstOrDefault();

        public IEnumerable<CustomerModel> Ordered(OrderDirection order)
        {
            var customersQuery = this.db.Customers.AsQueryable();

            switch (order)
            {
                case OrderDirection.Ascending:
                    customersQuery = customersQuery
                        .OrderBy(c => c.BirthDate)
                        .ThenBy(c => c.IsYoungDriver);

                    break;
                case OrderDirection.Descending:
                    customersQuery = customersQuery
                        .OrderByDescending(c => c.BirthDate)
                        .ThenByDescending(c => c.IsYoungDriver);

                    break;
                default:
                    throw new InvalidOperationException($"Invalid order direction {order}.");
            }

            return customersQuery
                .Select(c => new CustomerModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    BirthDate = c.BirthDate,
                    IsYoungDriver = c.IsYoungDriver
                })
                .ToList();
        }

        public CustomerWithMoneyAndCarModel TotalSales(int id)
             => this.db.Customers
                    .Where(c => c.Id == id)
                    .Select(c => new CustomerWithMoneyAndCarModel
                    {
                        Name = c.Name,
                        IsYoungDriver = c.IsYoungDriver,
                        BoughtCars = c.Sales.Select(s => new SaleModel
                        {
                            Price = s.Car.Parts.Sum(p => p.Part.Price),
                            Discount = s.Discount
                        })
                    })
                    .FirstOrDefault();
    }
}
