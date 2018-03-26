namespace CarDealer.Services
{
    using Models.Suppliers;
    using System.Collections.Generic;

    public interface ISupplierService
    {
        IEnumerable<SupplierListingModel> Filtered(bool isImporter);

        IEnumerable<SupplierModel> All();

        IEnumerable<SupplierBasicModel> AllBasic();

        bool Exists(int id);

        bool ExistingName(string name);

        SupplierBasicModel ById(int id);

        void Create(string name, bool isImporter);

        void Edit(int id, string name, bool isImporter);

        void Delete(int id);
    }
}
