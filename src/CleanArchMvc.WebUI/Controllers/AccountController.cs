using CleanArchMvc.Domain.Account;
using CleanArchMvc.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebUI.Controllers;

public class AccountController : Controller
{
    private readonly IAuthenticate _authenticate;

    public AccountController(IAuthenticate authenticate) => _authenticate = authenticate;

    public IActionResult Login(string returnUrl) => View(new LoginViewModel { ReturnUrl = returnUrl});


}
