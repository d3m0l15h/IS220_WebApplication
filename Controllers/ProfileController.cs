using AspNetCoreHero.ToastNotification.Abstractions;
using IS220_WebApplication.Models;
using IS220_WebApplication.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IS220_WebApplication.Controllers;

public class ProfileController : Controller
{
    private readonly UserManager<Aspnetuser> _userManager;
    private readonly SignInManager<Aspnetuser> _signInManager;
    private readonly INotyfService _notyf;
    public ProfileController(UserManager<Aspnetuser> userManager, SignInManager<Aspnetuser> signInManager, INotyfService notyf)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _notyf = notyf;
    }

    // GET
    [HttpGet]
    public IActionResult Index()
    {
        if (User.Identity is { IsAuthenticated: false })
        {
            return RedirectToAction("index", "Home");
        }
        var user = new CombinedViewModel
        {
            User = _userManager.GetUserAsync(User).Result
        };
        
        return View(user);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(CombinedViewModel model)
    {
        Utils.Utils.CheckModelState(ModelState);
        var user = await _userManager.GetUserAsync(User);
        if (!ModelState.IsValid)
        {
            _notyf.Error("Update failed");
            return View("Index", model);
        }

        if (user == null)
        {
            return NotFound();
        }

        user.FirstName = model.User?.FirstName;
        user.LastName = model.User?.LastName;
        user.Email = model.User?.Email;
        user.Phone = model.User?.Phone;
        user.Birth = model.User?.Birth;

        var result = await _userManager.UpdateAsync(user);
        if (result.Succeeded)
        {
            _notyf.Success("Profile updated successfully");
            return RedirectToAction("Index");
        }
        _notyf.Error("Update failed");
        return View("Index",model);
    }
}