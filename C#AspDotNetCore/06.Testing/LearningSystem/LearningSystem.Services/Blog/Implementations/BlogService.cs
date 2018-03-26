namespace LearningSystem.Services.Blog.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using static ServiceConstants;

    public class BlogService : IBlogService
    {
        private readonly LearningSystemDbContext db;

        public BlogService(LearningSystemDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<BlogListingServiceModel>> AllAsync(int page = 1)
            => await this.db.Articles
                .OrderByDescending(a => a.PublishDate)
                .Skip((page - 1) * BlogPageSize)
                .Take(BlogPageSize)
                .ProjectTo<BlogListingServiceModel>()
                .ToListAsync();

        public async Task<BlogDetailsServiceModel> ByIdAsync(int id)
            => await this.db.Articles
                .Where(a => a.Id == id)
                .ProjectTo<BlogDetailsServiceModel>()
                .FirstOrDefaultAsync();

        public async Task<IEnumerable<BlogListingServiceModel>> FindAsync(string searchText)
        {
            searchText = searchText ?? string.Empty;

            return await this.db.Articles
                .OrderByDescending(a => a.Id)
                .Where(a => a.Title.ToLower().Contains(searchText.ToLower())
                    || a.Content.ToLower().Contains(searchText.ToLower()))
                .ProjectTo<BlogListingServiceModel>()
                .ToListAsync();
        }

        public async Task<int> TotalAsync()
            => await this.db.Articles.CountAsync();

        public async Task CreateAsync(string title, string content, string authorId)
        {
            var article = new Article
            {
                Title = title,
                Content = content,
                PublishDate = DateTime.UtcNow,
                AuthorId = authorId
            };

            this.db.Articles.Add(article);
            await this.db.SaveChangesAsync();
        }
    }
}
