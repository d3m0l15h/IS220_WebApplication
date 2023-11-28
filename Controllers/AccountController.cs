using System.Security.Claims;
using AspNetCoreHero.ToastNotification.Abstractions;
using IS220_WebApplication.Context;
using IS220_WebApplication.Models;
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
    public async Task<IActionResult> Register(Aspnetuser model)
    {
        var originalUrl = HttpContext.Request.Headers["Referer"].ToString();
        CheckModelState();
        switch (ModelState.IsValid)
        {
            case true:
            {
                var user = new Aspnetuser
                {
                    UserName = model.UserName,
                    Email = model.Email,
                };
                var result = await _userManager.CreateAsync(user, model.PasswordHash!);
                if (!result.Succeeded) return Redirect(originalUrl);
                _notyf?.Success("Your account has been created.");
                return Redirect(originalUrl);
            }
            default:
                return Redirect(originalUrl);
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

    public void CheckModelState()
    {
        foreach (var modelStateKey in ModelState.Keys)
        {
            var modelStateVal = ModelState[modelStateKey];
            foreach (var error in modelStateVal?.Errors!)
            {
                // Log or print the error message
                Console.WriteLine($"-------{modelStateKey}: {error.ErrorMessage}");
            }
        }
    }
}