namespace CarDealer.Web
{
    using Data;
    using Data.Models;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddDbContext<CarDealerDbContext>(options => options
                    .UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDomainServices(); // add all services below automatically with reflection - extension method

            //services.AddTransient<ICustomerService, CustomerService>();
            //services.AddTransient<ICarService, CarService>();
            //services.AddTransient<ISupplierService, SupplierService>();
            //services.AddTransient<ISaleService, SaleService>();

            services
                .AddIdentity<User, IdentityRole>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                })
                .AddEntityFrameworkStores<CarDealerDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc(options =>
            {
                options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>(); // validating whenever we changing the DB that no one steal our sending data. It makes global this filter for the whole app
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvcWithDefaultRoute();

            //app.UseMvc(routes =>
            //{
            //    //routes.MapRoute(
            //    //    name: "customers",
            //    //    template: "customers/all/{order}",
            //    //    defaults: new { controller = "Customers", action = "All" }); // attribute [Route] in the controller

            //    routes.MapRoute(
            //        name: "cars",
            //        template: "cars/{make}",
            //        defaults: new {controller = "Cars", action = "ByMake"}); // attribute [Route] in the controller

            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");
            //});
        }
    }
}
