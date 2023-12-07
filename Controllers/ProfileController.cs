using System.Globalization;
using System.Net;
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
    public async Task<IActionResult> ConfirmEmail([FromQuery] string userId, [FromQuery] string tokenWithTime)
    {   
        Console.WriteLine(userId);
        Console.WriteLine(tokenWithTime);
        if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(tokenWithTime))
        {
            return BadRequest("Invalid parameters");
        }

        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return NotFound("User not found");
        }
        
        tokenWithTime = WebUtility.UrlDecode(tokenWithTime).Replace("%2B", "+"); // decode '%2B' back to '+'
        var parts = tokenWithTime.Split('-');
        if (parts.Length < 2)
        {
            return BadRequest("Invalid token format");
        }

        var token = parts[0];
        Console.WriteLine(token);
        Console.WriteLine(parts[1]);
        const string format = "M/d/yyyy h:mm:ss tt";
        if (!DateTime.TryParseExact(parts[1], format, CultureInfo.InvariantCulture, DateTimeStyles.None, out var creationTime))
        {
            return BadRequest("Invalid token creation time");
        }

        var expirationTime = TimeSpan.FromDays(1);
        if (creationTime + expirationTime < DateTime.UtcNow)
        {
            return BadRequest("Token expired");
        }

        var result = await _userManager.ConfirmEmailAsync(user, token);
        if (!result.Succeeded) return NotFound();
        _notyf.Success("Email confirmed successfully");
        return RedirectToAction("index", "home");
    }
    
    [HttpPost]
    public async Task<IActionResult> SendVerificationEmail()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return NotFound();
        }

        var now = DateTime.UtcNow;
        var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        token = token.Replace("+", "%2B");
        var tokenWithTime = $"{token}-{now}";

        var callbackUrl = Url.Action("ConfirmEmail", "Profile", new { userId = user.Id, tokenWithTime = tokenWithTime }, protocol: HttpContext.Request.Scheme);

        var emailContent = $"Hello {user.UserName},<br>Please confirm your account by <a href='{callbackUrl}'>clicking here</a>.<br>Best Regards,<br>NETGame";

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