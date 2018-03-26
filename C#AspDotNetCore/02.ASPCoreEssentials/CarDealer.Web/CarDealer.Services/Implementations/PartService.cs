﻿namespace CarDealer.Services.Implementations
{
    using Data;
    using Data.Models;
    using Models.Parts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PartService : IPartService
    {
        private readonly CarDealerDbContext db;

        public PartService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public void Create(string name, double price, int supplierId, int quantity)
        {
            var part = new Part
            {
                Name = name,
                Price = price,
                SupplierId = supplierId,
                Quantity = quantity > 0 ? quantity : 1
            };

            this.db.Parts.Add(part);
            this.db.SaveChanges();
        }

        public void Delete(int id)
        {
            var part = this.db.Parts.Find(id);

            if (part == null)
            {
                return;
            }

            this.db.Parts.Remove(part);
            this.db.SaveChanges();
        }

        public PartDetailsModel ById(int id)
            => this.db.Parts
                .Where(p => p.Id == id)
                .Select(p => new PartDetailsModel
                {
                    Name = p.Name,
                    Price = p.Price.Value,
                    Quantity = p.Quantity
                })
                .FirstOrDefault();

        public bool Exists(int id)
            => this.db.Parts.Any(p => p.Id == id);

        public void Edit(int id, double price, int quantity)
        {
            var existingPart = this.db.Parts.Find(id);

            if (existingPart == null)
            {
                return;
            }

            existingPart.Price = price;
            existingPart.Quantity = quantity;

            this.db.SaveChanges();
        }

        public IEnumerable<PartListingModel> AllListings(int page = 1, int pageSize = 10)
            => this.db.Parts
                .OrderByDescending(p => p.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(p => new PartListingModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    SupplierName = p.Supplier.Name
                })
                .ToList();

        public IEnumerable<PartBasicModel> All()
            => this.db.Parts
                    .OrderByDescending(p => p.Id)
                    .Select(p => new PartBasicModel
                    {
                        Id = p.Id,
                        Name = p.Name
                    })
                    .ToList();

        public int Total() => this.db.Parts.Count();
    }
}
