namespace CarDealer.Services
{
    using Models.Cars;
    using System.Collections.Generic;

    public interface ICarService
    {
        void Create(string make, string model, long travelledDistance, IEnumerable<int> parts);

        IEnumerable<CarModel> ByMake(string make);

        CarBasicModel ById(int id);

        IEnumerable<CarWithPartsModel> WithAllParts();

        bool Exists(int id);
    }
}
