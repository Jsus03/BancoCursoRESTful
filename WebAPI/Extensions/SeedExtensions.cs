using Identity.Models;
using Identity.Seeds;
using Microsoft.AspNetCore.Identity;

namespace WebAPI.Extensions
{
    public static class SeedExtensions
    {
        public static async Task<WebApplication> Seed(this WebApplication app)
        {
            using IServiceScope scope = app.Services.CreateScope();

            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            await DefaultRoles.SeedAsync(userManager, roleManager);
            await DefaultAdminUser.SeedAsync(userManager, roleManager);
            await DefaultBasicUser.SeedAsync(userManager, roleManager);

            return app;
        }
    }
}