using Microsoft.AspNetCore.Identity;

namespace QuoteBook.DAL.Seed
{

    public class DbInitializer
    {
        public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            string[] roleNames = { "Admin", "Customer" };

            foreach (var role in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }
        }
    }
}