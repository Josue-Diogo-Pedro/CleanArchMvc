using CleanArchMvc.Domain.Account;
using CleanArchMvc.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebUI.Controllers;

public class AccountController : Controller
{
    private readonly IAuthenticate _authenticate;

    public AccountController(IAuthenticate authenticate) => _authenticate = authenticate;

    public IActionResult Login(string returnUrl) => View(new LoginViewModel { ReturnUrl = returnUrl});

    [HttpPost]
    public async Task<ActionResult> Login(LoginViewModel loginViewModel)
    {
        var result = await _authenticate.Authenticate(loginViewModel.Emial ?? string.Empty, loginViewModel.Password ?? string.Empty);
        if (result)
        {
            if(string.IsNullOrEmpty(loginViewModel.ReturnUrl)) return RedirectToAction("Index", "Home");

            return Redirect(loginViewModel.ReturnUrl);
        }
        else
        {
            ModelState.AddModelError(string.Empty, "Invalid login attempt(password must be strong).");
            return View(loginViewModel);
        }
    }

    [HttpGet]
    public IActionResult Register() => View();

    [HttpPost]
    public async Task<ActionResult> Register(RegisterViewModel registerViewModel)
    {
        var result = await _authenticate.RegisterUser(registerViewModel.Email??string.Empty, registerViewModel.Password??string.Empty);

        if (result) 
            return Redirect("/");
        else
        {
            ModelState.AddModelError(string.Empty, "Invalid register attempt(password must be strong)");
            return View(registerViewModel);
        }
    }

    public async Task<ActionResult> Logout()
    {
        await _authenticate.Logout();
        return Redirect("Account/Login");
    }
}
