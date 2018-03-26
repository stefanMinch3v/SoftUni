﻿namespace BookShop.Services.Models.Book
{
    using AutoMapper;
    using Common.Mapping;
    using Data.Models;
    using System.Linq;

    public class BookDetailsServiceModel 
        : BookWithCategoriesServiceModel, IMapFrom<Book>, IHaveCustomMapping
    {
        public string Author { get; set; }

        public int AuthorId { get; set; }

        public override void ConfigureMapping(Profile mapper)
            => mapper
                .CreateMap<Book, BookDetailsServiceModel>()
                .ForMember(b => b.Categories, cfg => cfg.MapFrom(b => b.Categories.Select(c => c.Category.Name)))
                .ForMember(b => b.Author, cfg => cfg.MapFrom(b => b.Author.FirstName + " " + b.Author.LastName));
    }
}
