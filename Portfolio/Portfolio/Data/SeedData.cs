using Microsoft.AspNetCore.Identity;
using Portfolio.Entities;

public static class SeedData
{
    public static async Task Initialize(IServiceProvider services)
    {
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        // Create Admin role
        if (!await roleManager.RoleExistsAsync("Admin"))
            await roleManager.CreateAsync(new IdentityRole("Admin"));

        // Create admin user (username: admin, password: 1234)
        if (await userManager.FindByNameAsync("admin") == null)
        {
            var user = new ApplicationUser { UserName = "admin", Email = "admin@portfolio.com", FullName = "Admin" };
            var result = await userManager.CreateAsync(user, "1234");
            if (result.Succeeded)
                await userManager.AddToRoleAsync(user, "Admin");
        }
    }
}
