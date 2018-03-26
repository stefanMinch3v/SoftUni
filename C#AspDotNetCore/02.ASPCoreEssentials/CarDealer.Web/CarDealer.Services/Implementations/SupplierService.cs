namespace CarDealer.Services.Implementations
{
    using Data;
    using Data.Models;
    using Models.Suppliers;
    using System.Collections.Generic;
    using System.Linq;

    public class SupplierService : ISupplierService
    {
        private readonly CarDealerDbContext db;

        public SupplierService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public void Create(string name, bool isImporter)
        {
            var supplier = new Supplier
            {
                Name = name,
                IsImporter = isImporter
            };

            this.db.Suppliers.Add(supplier);
            this.db.SaveChanges();
        }

        public void Edit(int id, string name, bool isImporter)
        {
            var supplier = this.db.Suppliers.Find(id);

            if (supplier == null)
            {
                return;
            }

            supplier.Name = name;
            supplier.IsImporter = isImporter;

            this.db.SaveChanges();
        }

        public void Delete(int id)
        {
            var supplier = this.db.Suppliers.Find(id);

            if (supplier == null)
            {
                return;
            }

            this.db.Suppliers.Remove(supplier);
            this.db.SaveChanges();
        }

        public IEnumerable<SupplierModel> All()
            => this.db.Suppliers
                .OrderBy(s => s.Name)
                .Select(s => new SupplierModel
                {
                    Id = s.Id,
                    Name = s.Name
                })
                .ToList();

        public IEnumerable<SupplierBasicModel> AllBasic()
            => this.db.Suppliers
                .OrderBy(s => s.Id)
                .Select(s => new SupplierBasicModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    IsImporter = s.IsImporter
                })
                .ToList();

        public bool Exists(int id)
            => this.db.Suppliers
                .Any(s => s.Id == id);

        public bool ExistingName(string name)
            => this.db.Suppliers
                .Any(s => s.Name == name);

        public SupplierBasicModel ById(int id)
            => this.db.Suppliers
                .Where(s => s.Id == id)
                .Select(s => new SupplierBasicModel
                {
                    Id = s.Id,
                    IsImporter = s.IsImporter,
                    Name = s.Name
                })
                .FirstOrDefault();

        public IEnumerable<SupplierListingModel> Filtered(bool isImporter)
            => this.db.Suppliers
                    .OrderByDescending(s => s.Id)
                    .Where(s => s.IsImporter == isImporter)
                    .Select(fs => new SupplierListingModel
                    {
                        Id = fs.Id,
                        Name = fs.Name,
                        NumberOfParts = fs.Parts.Count
                    })
                    .ToList();
    }
}

