using ProjetoMyTeDev.Data;
using Microsoft.AspNetCore.Identity;
using ProjetoMyTeDev.Models;

public class DbInitializer
{
    public static async Task Initialize(IServiceProvider serviceProvider)
    {
        var context = serviceProvider
            .GetRequiredService<ApplicationDbContext>();

        context.Database.EnsureCreated();

        var roleManager = serviceProvider
            .GetRequiredService<RoleManager<IdentityRole>>();

        var userManager = serviceProvider
            .GetRequiredService<UserManager<ApplicationUser>>();

        var config = serviceProvider
            .GetRequiredService<IConfiguration>();

        var roleName = "Administrator";

        if (!await roleManager.RoleExistsAsync(roleName))
        {
            await roleManager.CreateAsync(new IdentityRole(roleName));
        }

        var adminEmail = config["AdminCredentials:Email"];
        var adminPassword = config["AdminCredentials:Password"];

        var admin = await userManager.FindByEmailAsync(adminEmail);

        if (admin == null)
        {
            admin = new ApplicationUser { UserName = adminEmail, Email = adminEmail, EmailConfirmed = true };
            var result = await userManager.CreateAsync(admin, adminPassword);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(admin, roleName);
            }
        }
        else
        {
            if (!await userManager.IsInRoleAsync(admin, roleName))
            {
                await userManager.AddToRoleAsync(admin, roleName);
            }
        }
    }
}