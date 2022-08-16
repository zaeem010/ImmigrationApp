using Microsoft.AspNetCore.Identity;
using ImmigrationApp.Constant;
using ImmigrationApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ImmigrationApp.Seeds
{
    public static class DefaultUsers
    {
        public static async Task SeedBasicUserAsync(UserManager<IdentityUser<int>> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            var defaultUser = new User
            {
                UserName = "Basic@gmail.com",
                Email = "Basic@gmail.com",
                EmailConfirmed = true,
                FirstName = "Basic",
                LastName = "User",
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "123Pa$$word!");
                    await userManager.AddToRoleAsync(defaultUser, Roles.Admin.ToString());
                }
            }
        }
        public static async Task SeedSuperAdminAsync(UserManager<IdentityUser<int>> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            var defaultUser = new User
            {
                UserName = "superadmin@gmail.com",
                Email = "superadmin@gmail.com",
                EmailConfirmed = true,
                FirstName = "SuperAdmin",
                LastName = "",
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "123Pa$$word!");
                    await userManager.AddToRoleAsync(defaultUser, Roles.SuperAdmin.ToString());
                }
                await roleManager.SeedClaimsForSuperAdmin();
            }
        }
        private async static Task SeedClaimsForSuperAdmin(this RoleManager<IdentityRole<int>> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync("SuperAdmin");
            List<string> GetAllModulesList = ListofAllModules();
            foreach (var Module in GetAllModulesList) 
            {
                await roleManager.AddPermissionClaim(adminRole, Module);
            }
        }
        public static async Task AddPermissionClaim(this RoleManager<IdentityRole<int>> roleManager, IdentityRole<int> role, string module)
        {
            var allClaims = await roleManager.GetClaimsAsync(role);
            var allPermissions = Permissions.GeneratePermissionsForModule(module);
            foreach (var permission in allPermissions)
            {
                if (!allClaims.Any(a => a.Type == "Permission" && a.Value == permission))
                {
                    await roleManager.AddClaimAsync(role, new Claim("Permission", permission));
                }
            }
        }
        public static List<string> ListofAllModules() 
        {
            List<string> AllModulesList = new List<string>();
            AllModulesList.Add("AdminPortal");
            AllModulesList.Add("Roles");
            return AllModulesList;
        }
    }
}
