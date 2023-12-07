using System.Globalization;
using AspNetCoreHero.ToastNotification.Abstractions;
using IS220_WebApplication.Models;
using IS220_WebApplication.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using IEmailSender = IS220_WebApplication.Utils.IEmailSender;

namespace IS220_WebApplication.Controllers;

public class ProfileController : Controller
{
    private readonly UserManager<Aspnetuser> _userManager;
    private readonly IEmailSender _emailSender;
    private readonly INotyfService _notyf;
    public ProfileController(UserManager<Aspnetuser> userManager, INotyfService notyf, IEmailSender emailSender)
    {
        _userManager = userManager;
        _notyf = notyf;
        _emailSender = emailSender;
    }

    // GET
    [HttpGet]
    public IActionResult Index()
    {
        if (User.Identity is { IsAuthenticated: false })
        {
            return RedirectToAction("index", "home");
        }
        var user = new CombinedViewModel
        {
            User = _userManager.GetUserAsync(User).Result
        };
        return View(user);
    }
    
    [HttpGet]
    public async Task<IActionResult> ConfirmEmail(string userId, string token)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return NotFound();
        }

        var result = await _userManager.ConfirmEmailAsync(user, token);
        return View(result.Succeeded ? "EmailConfirmed" : "Error");
    }
    
    [HttpPost]
    public async Task<IActionResult> SendVerificationEmail()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return NotFound();
        }

        var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        var callbackUrl = Url.Action("ConfirmEmail", "Profile", new { userId = user.Id, token = token }, protocol: HttpContext.Request.Scheme);

        var emailContent = $"Please confirm your account by <a href='{callbackUrl}'>clicking here</a>.";

        await _emailSender.SendEmailAsync(user.Email!, "Confirm your email", emailContent);

        return Json(new { success = true });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(CombinedViewModel model)
    {
        var user = await _userManager.GetUserAsync(User);
        ModelState.Remove("User.Status");
        if (!ModelState.IsValid)
        {
            _notyf.Error("Update failed");
            return View("Index", model);
        }

        if (user == null)
        {
            return NotFound();
        }

        user.FirstName = model.User!.FirstName;
        user.LastName = model.User!.LastName;
        user.Phone = model.User!.Phone;
        user.Birth = model.User!.Birth;

        var result = await _userManager.UpdateAsync(user);
        if (result.Succeeded)
        {
            _notyf.Success("Profile updated successfully");
            return RedirectToAction("index","profile");
        }
        _notyf.Error("Update failed");
        return RedirectToAction("index","profile");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ResetPwd(CombinedViewModel model)
    {
        var user = await _userManager.GetUserAsync(User);
        model.User = user;
        
        ViewBag.PasswordChangeAttempted = true;
        if (!ModelState.IsValid){return View("index", model);}
        
        var isCurrentPasswordValid = await _userManager.CheckPasswordAsync(user!, model.ChangePassword!.CurrentPassword);
        if (!isCurrentPasswordValid)
        {
            ModelState.AddModelError("ChangePassword.CurrentPassword", "Current password is incorrect");
            return View("index", model);
        }

        var changePasswordResult = await _userManager.ChangePasswordAsync(user!, model.ChangePassword!.CurrentPassword, model.ChangePassword.NewPassword);
        if (!changePasswordResult.Succeeded) return RedirectToAction("index", model);
        
        _notyf.Success("Password changed successfully");
        return RedirectToAction("index","profile");
    }
}