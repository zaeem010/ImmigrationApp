using Microsoft.AspNetCore.Identity;
using ImmigrationApp.Constant;
using System.Threading.Tasks;

namespace ImmigrationApp.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(UserManager<IdentityUser<int>> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole<int>(Roles.SuperAdmin.ToString()));
            await roleManager.CreateAsync(new IdentityRole<int>(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole<int>(Roles.Employeer.ToString()));
            await roleManager.CreateAsync(new IdentityRole<int>(Roles.Canidate.ToString()));
        }
    }
}
