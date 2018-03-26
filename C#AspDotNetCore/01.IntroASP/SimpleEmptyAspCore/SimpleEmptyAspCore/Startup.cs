using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SimpleEmptyAspCore.Services;

namespace SimpleEmptyAspCore
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IMyService, MyService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // middlewares, usually if you have more its a good idea to extract them in a separate class

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Map("/cats", catsApp =>
            {
                catsApp.Run(async (context) =>
                {
                    await context.Response.WriteAsync("Cats area, be extremely careful!");
                });
            });

            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("Content-Type", "text/html");

                await next();
            });

            app.Use(async (context, next) =>
            {
                if (context.Request.Path.Value.StartsWith("/users"))
                {
                    await context.Response.WriteAsync("Users Area");
                }

                await next();
            });

            app.Run(async (context) =>
            {
                var service = context.RequestServices.GetService<IMyService>();

                Console.WriteLine($"{context.Request.Method} - {context.Request.Path}");
                await context.Response.WriteAsync("<h1>Hello ASP app</h1>");
                await context.Response.WriteAsync($"<h2>{service.Name}</h2>");
            });
        }
    }
}
