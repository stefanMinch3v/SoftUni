﻿namespace BookShop.Services.Models.Category
{
    using Common.Mapping;
    using Data.Models;

    public class CategoryListingServiceModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
