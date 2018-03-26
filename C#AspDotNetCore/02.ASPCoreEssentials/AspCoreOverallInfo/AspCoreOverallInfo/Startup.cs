using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AspCoreOverallInfo.Data;
using AspCoreOverallInfo.Models;
using AspCoreOverallInfo.Services;

namespace AspCoreOverallInfo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            // services.AddTransient<Interface, Class>(); // Standart way. This means that everytime you want this service (Interface) you will get a completely new instance of it (the class).

            // var someService = this.HttpContext.RequestServices.GetService(typeof(ISomeService)); // another way but this variable should be in the class that needs the service. So if you use both transient(inject it in the constructor) and var of the service in some class you will get 2 objects of the service. 

            // services.AddSingleton<Interface, Class>(); // here if you use the above var again in the class you will get only 1 object (the same) everytime.

            // services.AddScoped<Interface, Class>(); // here means that in 1 request y will have 1 object, exmp. the object life is in the request, every request has its own object. Very useful for Database requests (keep the caash only for the current request).

            // when to use asychronic methods? For example if the application doesnt have many users you can use the synhronized method for queries to the DB, but if your application gets bigger and you have many users its crutial to change your queries to asynchoronic !!!!! async Task<> await and so on

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment()) // running debug mode and so on
            {
                app.UseBrowserLink(); // for example if you update some css file to refresh automatically the server and show it
                app.UseDeveloperExceptionPage(); // show exceptions sometimes doesnt work perhaps is a bug
                app.UseDatabaseErrorPage(); // if the db gets exception you'll get some button helper to solve the issue
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles(); // in order to get everthing public in wwwroot folder and to use it (grant access)

            app.UseAuthentication();

            // 2 types: attribute routing and the default one which is below
            app.UseMvc(routes =>
            {
                routes.MapRoute( 
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"); // ? in id means optional
                // controller=Home - means that the default controller is Home and we ca leave it without anything, if we write it without "=" this means that we must write some controller there is no default one! The same rule is for the action.
            });
        }
    }
}
