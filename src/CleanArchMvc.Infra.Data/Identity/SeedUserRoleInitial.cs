using CleanArchMvc.Domain.Account;
using Microsoft.AspNetCore.Identity;

namespace CleanArchMvc.Infra.Data.Identity;

public class SeedUserRoleInitial : ISeedUserRoleInitial
{
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<ApplicationUser> _userManager;

    public SeedUserRoleInitial(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
    {
        _roleManager = roleManager;
        _userManager = userManager;
    }

    public void SeedUsers()
    {
        if (_userManager.FindByEmailAsync("usuario@localhost").Result == null)
        {
            ApplicationUser user = new();
            user.UserName = "usuario@localhost";
            user.Email = "usuario@localhost";
            user.NormalizedUserName = "USUARIO@LOCALHOST";
            user.NormalizedEmail = "USUARIO@LOCALHOST";
            user.EmailConfirmed = true;
            user.LockoutEnabled = false;
            user.SecurityStamp = Guid.NewGuid().ToString();

            IdentityResult result = _userManager.CreateAsync(user, "Numsey#2024").Result;

            if (result.Succeeded) _userManager.AddToRoleAsync(user, "User").Wait();

        }

        if (_userManager.FindByEmailAsync("admin@localhost").Result == null)
        {
            ApplicationUser userManager = new();
            userManager.UserName = "admin@localhost";
            userManager.Email = "admin@localhost";
            userManager.NormalizedUserName = "ADMIN@LOCALHOST";
            userManager.NormalizedEmail = "ADMIN@LOCALHOST";
            userManager.EmailConfirmed = true;
            userManager.LockoutEnabled = false;
            userManager.SecurityStamp = Guid.NewGuid().ToString();

            IdentityResult resultado = _userManager.CreateAsync(userManager, "Numsey#2024").Result;

            if (resultado.Succeeded) _userManager.AddToRoleAsync(userManager, "Admin").Wait();


        }
    }

    public void SeedRoles()
    {

        if (!_roleManager.RoleExistsAsync("User").Result)
        {
            IdentityRole role = new IdentityRole();
            role.Name = "User";
            role.NormalizedName = "USER";
            IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
        }
        if (!_roleManager.RoleExistsAsync("Admin").Result)
        {
            IdentityRole role = new IdentityRole();
            role.Name = "Admin";
            role.NormalizedName = "ADMIN";
            IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
        }

    }
}


