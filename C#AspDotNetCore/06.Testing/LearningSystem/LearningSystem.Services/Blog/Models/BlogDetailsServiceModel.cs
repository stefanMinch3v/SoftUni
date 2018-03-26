﻿namespace LearningSystem.Services.Blog.Models
{
    using Common.Mapping;
    using Data.Models;
    using System;
    using AutoMapper;

    public class BlogDetailsServiceModel : IMapFrom<Article>, IHaveCustomMapping
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime PublishDate { get; set; }

        public string Author { get; set; }

        public void ConfigureMapping(Profile mapper)
            => mapper
                .CreateMap<Article, BlogListingServiceModel>()
                .ForMember(b => b.Author, cfg => cfg.MapFrom(a => a.Author.UserName));
    }
}
