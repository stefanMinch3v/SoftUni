using PhotoShare.Data;
using PhotoShare.Models;
using System.Linq;

namespace PhotoShare.Service
{
    public class TownService
    {
        public void AddTown(string name, string countryName)
        {
            using (PhotoShareContext context = new PhotoShareContext())
            {
                Town town = new Town
                {
                    Name = name,
                    Country = countryName
                };

                context.Towns.Add(town);
                context.SaveChanges();
            }
        }

        public bool IsTownExisting(string townName)
        {
            using (var context = new PhotoShareContext())
            {
                return context.Towns.Any(t => t.Name == townName);
            }
        }

        public Town GetTownByName(string townName)
        {
            using (var context = new PhotoShareContext())
            {
                return context.Towns.SingleOrDefault(t => t.Name == townName);
            }
        }
    }
}
