using CleanArchMvc.Domain.Account;
using Microsoft.AspNetCore.Identity;

namespace CleanArchMvc.Infra.Data.Identity;

public class SeedUserRoleInitial : ISeedUserRoleInitial
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;

    public SeedUserRoleInitial(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public void SeedRoles()
    {

        throw new NotImplementedException();
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

            IdentityResult result = _userManager.CreateAsync(user, "Numsey#2021").Result;

            if (result.Succeeded)
            {
                _userManager.AddToRoleAsync(user, "User").Wait();
            }

            if (_userManager.FindByEmailAsync("admin@localhost").Result == null)
            {
                ApplicationUser userManager = new();
                user.UserName = "admin@localhost";
                user.Email = "admin@localhost";
                user.NormalizedUserName = "ADMIN@LOCALHOST";
                user.NormalizedEmail = "ADMIN@LOCALHOST";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult resultado = _userManager.CreateAsync(userManager, "Numsey#2021").Result;

                if (resultado.Succeeded) _userManager.AddToRoleAsync(userManager, "Admin").Wait();


            }
        }
    }
}
