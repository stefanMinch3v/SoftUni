namespace CarDealer.Services
{
    using Models;
    using Models.Customers;
    using System;
    using System.Collections.Generic;

    public interface ICustomerService
    {
        IEnumerable<CustomerModel> Ordered(OrderDirection order);

        CustomerWithMoneyAndCarModel TotalSales(int id);

        void Create(string name, DateTime dateOfBirth, bool isYoungDriver);

        void Edit(int id, string name, DateTime dateOfBirth, bool isYoungDriver);

        bool Exists(int id);

        CustomerModel ById(int id);

        CustomerBasicModel ByIdBasic(int id);
    }
}
