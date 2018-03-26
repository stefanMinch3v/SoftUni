namespace CarDealer.Services.Implementations
{
    using Data;
    using Data.Models;
    using Models.Cars;
    using Models.Parts;
    using System.Collections.Generic;
    using System.Linq;

    public class CarService : ICarService
    {
        private readonly CarDealerDbContext db;

        public CarService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public void Create(string make, string model, long travelledDistance, IEnumerable<int> parts)
        {
            var existingPartIds = this.db.Parts
                .Where(p => parts.Contains(p.Id))
                .Select(p => p.Id)
                .ToList();

            var car = new Car
            {
                Make = make,
                Model = model,
                TravelledDistance = travelledDistance
            };

            foreach (var partId in existingPartIds)
            {
                car.Parts.Add(new PartCar
                {
                    PartId = partId
                });
            }

            this.db.Cars.Add(car);
            this.db.SaveChanges();
        }

        public IEnumerable<CarModel> ByMake(string make)
            => this.db.Cars
                .Where(c => c.Make.ToLower() == make.ToLower())
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new CarModel
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .ToList();

        public IEnumerable<CarWithPartsModel> WithAllParts()
            => this.db.Cars
                    .OrderByDescending(c => c.Id)
                    .Select(c => new CarWithPartsModel
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TravelledDistance = c.TravelledDistance,
                        Parts = c.Parts
                        .Select(p => new PartModel
                        {
                            Name = p.Part.Name,
                            Price = p.Part.Price
                        })
                    })
                .ToList();

        public CarBasicModel ById(int id)
        {
            var price = this.db.Cars
                .Where(c => c.Id == id)
                .Select(c => c.Parts.Sum(p => p.Part.Price))
                .Sum();

            var cars = this.db.Cars
                .Where(c => c.Id == id)
                .Select(c => new CarBasicModel
                {
                    Id = c.Id,
                    MakeModel = $"{c.Make} {c.Model}",
                    Price = price.Value
                })
                .FirstOrDefault();

            return cars;
        }

        public bool Exists(int id)
            => this.db.Cars.Any(c => c.Id == id);
    }
}
