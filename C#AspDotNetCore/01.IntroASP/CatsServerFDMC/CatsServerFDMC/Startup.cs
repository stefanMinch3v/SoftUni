namespace CatsServerFDMC
{
    using Data;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CatsDbContext>(options =>
            options.UseSqlServer(AppSettings.DatabaseConnectionString));
        }

        public void Configure(IApplicationBuilder app)
            => app
                .UseDatabaseMigration() // an extension method that we wrote
                .UseStaticFiles() // all the folders/classes in the current project become public
                .UseHtmlContentType() // an extension method that we wrote
                .UseRequestHandlers() // method that we wrote which includes all the mapping routes with reflection
                .UseNotFoundHandler(); // an extension method that we wrote 
        
    }
}
