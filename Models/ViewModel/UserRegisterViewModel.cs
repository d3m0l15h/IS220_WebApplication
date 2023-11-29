using System.ComponentModel.DataAnnotations;
using IS220_WebApplication.Utils.ValidationAttribute;

namespace IS220_WebApplication.Models.ViewModel;

public class UserRegisterViewModel
{
    [Required(ErrorMessage = "Username is required.")]
    [UniqueUsername]
    public string Username { get; set; } = null!;
    
    [Required(ErrorMessage = "First name is required.")]
    public string FirstName { get; set; } = null!;
    
    [Required(ErrorMessage = "Last name is required.")]
    public string LastName { get; set; } = null!;
    
    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    [UniqueEmail]
    public string Email { get; set; } = null!;
    
    [Required(ErrorMessage = "Password is required.")]
    public string Password { get; set; } = null!;
    
    [Required(ErrorMessage = "Password confirmation is required.")]
    [Compare("Password", ErrorMessage = "Password and confirmation password do not match.")]
    public string? PasswordConfirm { get; set; }
}