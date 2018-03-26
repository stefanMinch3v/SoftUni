namespace CarDealer.Services
{
    using Models.Parts;
    using System.Collections.Generic;

    public interface IPartService
    {
        IEnumerable<PartBasicModel> All();

        IEnumerable<PartListingModel> AllListings(int page = 1, int pageSize = 10);

        void Create(string name, double price, int supplierId, int quantity = 1);

        void Delete(int id);

        PartDetailsModel ById(int id);

        bool Exists(int id);

        void Edit(int id, double price, int quantity);

        int Total();
    }
}
