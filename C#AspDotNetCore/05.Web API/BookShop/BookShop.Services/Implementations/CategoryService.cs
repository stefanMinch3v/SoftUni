namespace BookShop.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Models.Category;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CategoryService : ICategoryService
    {
        private readonly BookShopDbContext db;

        public CategoryService(BookShopDbContext db)
        {
            this.db = db;
        }

        public async Task<int> Create(string name)
        {
            var category = new Category
            {
                Name = name
            };

            this.db.Categories.Add(category);
            await this.db.SaveChangesAsync();

            return category.Id;
        }

        public async Task Edit(int id, string name)
        {
            var category = await this.db.Categories.FindAsync(id);

            if (category == null)
            {
                return;
            }

            category.Name = name;

            this.db.Categories.Update(category);
            await this.db.SaveChangesAsync();
        }

        public async Task<IEnumerable<CategoryListingServiceModel>> All()
            => await this.db.Categories
                .ProjectTo<CategoryListingServiceModel>()
                .ToListAsync();

        public async Task<CategoryListingServiceModel> Details(int id)
            => await this.db.Categories
                .Where(c => c.Id == id)
                .ProjectTo<CategoryListingServiceModel>()
                .FirstOrDefaultAsync();

        public async Task Delete(int id)
        {
            var category = await this.db.Categories.FindAsync(id);

            if (category == null)
            {
                return;
            }

            this.db.Categories.Remove(category);
            await this.db.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
            => await this.db.Categories.AnyAsync(c => c.Id == id);

        public async Task<bool> Exists(string name)
            => await this.db.Categories.AnyAsync(c => c.Name == name);
    }
}
