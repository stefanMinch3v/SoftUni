namespace LearningSystem.Web.Infrastructure.Extensions
{
    using Data;
    using Data.Models;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Threading.Tasks;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope
                    .ServiceProvider
                    .GetService<LearningSystemDbContext>()
                    .Database
                    .Migrate();

                var roleManager = serviceScope
                    .ServiceProvider
                    .GetService<RoleManager<IdentityRole>>();

                var userManager = serviceScope
                    .ServiceProvider
                    .GetService<UserManager<User>>();

                Task.Run(async () =>
                {
                    var roles = new[]
                    {
                        WebConstants.AdministratorRole,
                        WebConstants.BlogAuthorRole,
                        WebConstants.TrainerRole
                    };

                    foreach (var role in roles)
                    {
                        var existingRole = await roleManager.RoleExistsAsync(role);

                        if (!existingRole)
                        {
                            await roleManager.CreateAsync(new IdentityRole
                            {
                                Name = role
                            });
                        }
                    }                  

                    // add admin to the system
                    var adminUsername = "admin";
                    var adminEmail = "admin@abv.bg";
                    var adminUser = await userManager.FindByEmailAsync(adminEmail);

                    if (adminUser == null)
                    {
                        adminUser = new User
                        {
                            UserName = adminUsername,
                            Email = adminEmail,
                            Name = adminUsername,
                            Birthdate = DateTime.UtcNow
                        };

                        await userManager.CreateAsync(adminUser, "admin1");

                        await userManager.AddToRoleAsync(adminUser, WebConstants.AdministratorRole);
                    }
                })
                .GetAwaiter()
                .GetResult();
            }

            return app;
        }
    }
}
