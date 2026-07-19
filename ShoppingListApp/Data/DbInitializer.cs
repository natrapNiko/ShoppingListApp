using Microsoft.AspNetCore.Identity;
using ShoppingListApp.Models;

namespace ShoppingListApp.Data;

public class DbInitializer
{
    public static async Task SeedAsync(IServiceProvider services)
    {
        var roleMenager = services.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
        var context = services.GetRequiredService<ApplicationDbContext>();

        if (!await roleMenager.RoleExistsAsync("Admin"))
        {
            await roleMenager.CreateAsync(new IdentityRole("Admin"));
        }

        if (!await roleMenager.RoleExistsAsync("User"))
        {
            await roleMenager.CreateAsync(new IdentityRole("User"));
        }

        var adminEmail = "admin@shopping.com";

        var admin = await userManager.FindByEmailAsync(adminEmail);

        if (admin == null)
        {
            admin = new ApplicationUser
            {
                firstName = "System",
                lastName = "Administrator",
                UserName = adminEmail,
                EmailConfirmed = true,
            };
            await userManager.CreateAsync(admin, "Admin123!");
            await userManager.AddToRoleAsync(admin, "Admin");
        }

        if (!context.Categories.Any()) { 
            context.Categories.AddRange(
                new Category { Name = "Fruits" },
                new Category { Name = "Vegetables" },
                new Category { Name = "Drinks" },
                new Category { Name = "Dairy" },
                new Category { Name = "Bakery" },
                new Category { Name = "Frozen Food" }
            );

            await context.SaveChangesAsync();
        }
    }
}
