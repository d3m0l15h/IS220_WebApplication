using System.Security.Claims;
using AspNetCoreHero.ToastNotification.Abstractions;
using IS220_WebApplication.Context;
using IS220_WebApplication.Models;
using IS220_WebApplication.Models.ViewModel;
using IS220_WebApplication.Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace IS220_WebApplication.Controllers;

public class AccountController : Controller
{
    private readonly MyDbContext _db;
    private readonly INotyfService? _notyf;
    private readonly UserManager<Aspnetuser> _userManager;
    private readonly SignInManager<Aspnetuser> _signInManager;

    public AccountController(MyDbContext db, INotyfService notyf, SignInManager<Aspnetuser> signInManager,
        UserManager<Aspnetuser> userManager)
    {
        _db = db;
        _notyf = notyf;
        _signInManager = signInManager;
        _userManager = userManager;
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(string ue, string password)
    {
        var originalUrl = HttpContext.Request.Headers["Referer"].ToString();

        // Find the user by email or username
        var user = await _userManager.FindByEmailAsync(ue) ?? await _userManager.FindByNameAsync(ue);
        if (user != null)
        {
            if (user.Status.Equals("block"))
            {
                _notyf?.Error("Your account has been locked.");
                return Redirect(originalUrl);
            }

            // Check the password
            var result = await _signInManager.CheckPasswordSignInAsync(user, password, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                // Sign in the user
                await _signInManager.SignInAsync(user, false);
                _notyf?.Success("Logged in successfully.");
                return Redirect(originalUrl);
            }
        }

        _notyf?.Error("Invalid username or password.");
        return Redirect(originalUrl);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(UserRegisterViewModel model)
    {
        var originalUrl = HttpContext.Request.Headers["Referer"].ToString();
        Utils.Utils.CheckModelState(ModelState);
        ModelState.Remove("Status");
        switch (ModelState.IsValid)
        {
            case true:
            {
                var existingUserWithUsername = await _userManager.FindByNameAsync(model.Username);
                if (existingUserWithUsername != null)
                {
                    ModelState.AddModelError("Username", "Username already exists.");
                    return Json(new { isValid = false, errors = new List<string> { "Username already exists." } });
                }

                var existingUserWithEmail = await _userManager.FindByEmailAsync(model.Email);
                if (existingUserWithEmail != null)
                {
                    ModelState.AddModelError("Email", "Email already exists.");
                    return Json(new { isValid = false, errors = new List<string> { "Email already exists." } });
                }
                var user = new Aspnetuser
                {
                    UserName = model.Username,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    LockoutEnabled = false,
                };
                var result = await _userManager.CreateAsync(user, model.Password!);
                if (!result.Succeeded)
                {
                    return Json(new { isValid = false, errors = result.Errors.Select(e => e.Description).ToList() });
                }
                _notyf?.Success("Register successfully.");
                return Json(new { isValid = true, message = "Register successfully."});
            }
            default:
                var errors = ModelState
                    .Where(x => x.Value is { Errors.Count: > 0 })
                    .Select(x => new { key = x.Key, errorMessage = x.Value?.Errors.Select(e => e.ErrorMessage).FirstOrDefault() })
                    .OrderBy(x => x.key) 
                    .ToList();
                return Json(new { isValid = false, errors });
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        var originalUrl = HttpContext.Request.Headers["Referer"].ToString();
        await _signInManager.SignOutAsync();
        _notyf?.Success("You have been logged out");
        return Redirect(originalUrl);
    }
}