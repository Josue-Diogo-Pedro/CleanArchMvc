using CleanArchMvc.Domain.Account;
using Microsoft.AspNetCore.Identity;

namespace CleanArchMvc.Infra.Data.Identity;

public class AuthenticateService : IAuthenticate
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AuthenticateService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<bool> Authenticate(string email, string password) 
    {
        var result = await _signInManager.PasswordSignInAsync(email, password, false, lockoutOnFailure: false);
        return result.Succeeded;
    }

    public async Task<bool> RegisterUser(string email, string password)
    {
        ApplicationUser user = new()
        {
            UserName = email,
            Email = email
        };

        var result = await _userManager.CreateAsync(user, password);

        if (result.Succeeded) await _signInManager.SignInAsync(user, false);

        return result.Succeeded;
    }

    public async Task Logout() => await _signInManager.SignOutAsync();
}
