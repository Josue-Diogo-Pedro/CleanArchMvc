using System.ComponentModel.DataAnnotations;

namespace CleanArchMvc.WebUI.Models;

public class LoginViewModel
{
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid format email")]
    public string? Emial { get; set; }

    [Required(ErrorMessage = "The password is required")]
    [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
    [DataType(DataType.Password)]
    public string? Password { get; set; }
    public string? ReturnUrl { get; set; }

}
