namespace News.Test.Mocks
{
    using Microsoft.EntityFrameworkCore;
    using News.Data;
    using System;

    public class InMemoryDatabase
    {
        public static NewsDbContext GetDatabaseInstance()
        {
            var dbOptions = new DbContextOptionsBuilder<NewsDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new NewsDbContext(dbOptions);
        }
    }
}
