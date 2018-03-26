namespace IdentityDemo.Infrastructure.Extensions
{
    using Data;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Models;
    using System;
    using System.Threading.Tasks;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseDataBaseMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope
                    .ServiceProvider
                    .GetService<ApplicationDbContext>()
                    .Database
                    .Migrate();

                var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();
                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

                Task.Run(async () =>
                {
                    var adminRole = GlobalConstants.AdministratorRole;

                    var roleExists = await roleManager.RoleExistsAsync(adminRole);

                    if (!roleExists)
                    {
                        var result = await roleManager.CreateAsync(new IdentityRole
                        {
                            Name = adminRole
                        });
                    }

                    var adminEmail = "admin@mywebsite.com";
                    var adminUser = await userManager.FindByNameAsync(adminEmail);

                    if (adminUser == null)
                    {
                        adminUser = new User
                        {
                            UserName = adminEmail,
                            Email = adminEmail
                        };

                        await userManager.CreateAsync(adminUser, "admin12"); // make sure that the password requirements are set to false (Upper,Lowercase and so on in the startup config file! otherwise gets exception of the security stamp == null)

                        await userManager.AddToRoleAsync(adminUser, adminRole);
                    }
                })
                .Wait(); // either GetAwaiter().GetResult() or Wait()
            }

            return app;
        }
    }
}
