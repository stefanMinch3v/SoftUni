namespace CarDealer.Services
{
    using Models.Sales;
    using System.Collections.Generic;

    public interface ISaleService
    {
        void Create(int customerId, int carId, double discount);

        SaleCustomerCarModel All();

        IEnumerable<SaleListModel> AllListings();

        SaleDetailsModel Details(int id);

        IEnumerable<SaleListModel> AllByGivenDiscount(double discount);

        IEnumerable<SaleListModel> AllWithDiscount();
    }
}
