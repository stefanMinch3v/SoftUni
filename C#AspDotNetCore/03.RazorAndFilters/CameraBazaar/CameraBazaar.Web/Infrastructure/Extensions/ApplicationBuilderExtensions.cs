namespace CameraBazaar.Web.Infrastructure.Extensions
{
    using Data;
    using Data.Models;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System.Linq;
    using System.Threading.Tasks;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseDataBaseMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope
                    .ServiceProvider
                    .GetService<BazaarDbContext>()
                    .Database
                    .Migrate();

                //logic for adding roles to users, by default registered user role.Gets an exception whenever y try to add new migration, comment it if y want to modify the Database.

                var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();
                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
                var db = serviceScope.ServiceProvider.GetService<BazaarDbContext>();

                Task.Run(async () =>
                {
                    var adminRole = GlobalConstants.AdministratorRole;
                    var registeredUserRole = GlobalConstants.RegisteredRole;
                    var restrictedRole = GlobalConstants.RestrictedRole;

                    var existingAdminRole = await roleManager.RoleExistsAsync(adminRole);
                    var existingUserRole = await roleManager.RoleExistsAsync(registeredUserRole);
                    var existingRestrictedRole = await roleManager.RoleExistsAsync(restrictedRole);

                    if (!existingRestrictedRole)
                    {
                        var result = await roleManager.CreateAsync(new IdentityRole
                        {
                            Name = restrictedRole
                        });
                    }

                    if (!existingAdminRole)
                    {
                        var result = await roleManager.CreateAsync(new IdentityRole
                        {
                            Name = adminRole
                        });
                    }

                    if (!existingUserRole)
                    {
                        var result = await roleManager.CreateAsync(new IdentityRole
                        {
                            Name = registeredUserRole
                        });
                    }

                    // admin role
                    var adminUsername = "admin";
                    var adminEmail = "admin@abv.bg";
                    var adminUser = await userManager.FindByNameAsync(adminUsername);

                    if (adminUser == null)
                    {
                        adminUser = new User
                        {
                            UserName = adminUsername,
                            Email = adminEmail
                        };

                        await userManager.CreateAsync(adminUser, "admin1");

                        await userManager.AddToRoleAsync(adminUser, adminRole);
                    }

                    // registered users role
                    var usersInRoles = db.UserRoles
                        .Select(ur => ur.UserId)
                        .ToList();

                    var registeredUsers = db.Users
                        .Where(u => u.UserName != adminUsername
                            && !usersInRoles.Contains(u.Id))
                        .ToList();

                    if (registeredUsers.Count > 0)
                    {
                        foreach (var user in registeredUsers)
                        {
                            await userManager.AddToRoleAsync(user, registeredUserRole);
                        }
                    }
                })
                .Wait();
            }

            return app;
        }
    }
}
