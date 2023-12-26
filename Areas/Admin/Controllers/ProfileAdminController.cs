using AspNetCoreHero.ToastNotification.Abstractions;
using IS220_WebApplication.Areas.Admin.Models;
using IS220_WebApplication.Areas.Admin.Models.Authentication;
using IS220_WebApplication.Context;
using IS220_WebApplication.Models;
using IS220_WebApplication.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V5.Pages.Account.Manage.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using IEmailSender = IS220_WebApplication.Utils.IEmailSender;

namespace IS220_WebApplication.Areas.Admin.Controllers;

[Area("Admin")]
[Authentication]
public class ProfileAdminController : Controller
{
    private readonly MyDbContext _db;
    private readonly UserManager<Aspnetuser> _userManager;
    private readonly IEmailSender _emailSender;
    private readonly INotyfService _notyf;
    public ProfileAdminController(MyDbContext db, UserManager<Aspnetuser> userManager, INotyfService notyf, IEmailSender emailSender)
    {
        _db = db;
        _userManager = userManager;
        _notyf = notyf;
        _emailSender = emailSender;
    }

    // GET
    [Route("/admin/profile")]
    public IActionResult Index()
    {
        var user = _userManager.GetUserAsync(User).Result;
        var viewModel = new ProfileAdminViewModel
        {
            UserViewModel = new UserViewModel
            {
                User = user
            }
        };
        return View(viewModel);
    }
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProfile(ProfileAdminViewModel viewModel)
        {
            
            ModelState.Remove("UserViewModel.User.PasswordHash");
            ModelState.Remove("UserViewModel.User.Status");

            var user = _userManager.GetUserAsync(User).Result;
            if (viewModel.UserViewModel.AvatarPath != null)
            {
                viewModel.UserViewModel.User.AvatarPath = "/images/user/" + Utils.Utils.SaveImage(viewModel.UserViewModel.AvatarPath, "wwwroot/images/user");
            }
            else
            {
                viewModel.UserViewModel.User.AvatarPath = user.AvatarPath;
                ModelState.Remove("UserViewModel.User.AvatarPath");
                ModelState.Remove("UserViewModel.AvatarPath");
            }
         
            Utils.Utils.CheckModelState(ModelState);
            switch (ModelState.IsValid)
            {
                case true:
                {
                    var existingUserWithUsername = await _userManager.FindByNameAsync(viewModel.UserViewModel.User.UserName);
                    if (existingUserWithUsername != null && existingUserWithUsername.Id != user.Id)
                    {
                        ModelState.AddModelError("Username", "Username already exists.");
                        _notyf?.Error("Username already exists.");
                        return RedirectToAction("Index");
                    }

                    var existingUserWithEmail = await _userManager.FindByEmailAsync(viewModel.UserViewModel.User.Email);
                    if (existingUserWithEmail != null && existingUserWithEmail.Id != user.Id)
                    {
                        ModelState.AddModelError("Email", "Email already exists.");
                        _notyf?.Error("Email already exists.");
                        return RedirectToAction("Index");
                    }

                    user.UserName = viewModel.UserViewModel.User.UserName;
                    user.Email = viewModel.UserViewModel.User.Email;
                    user.FirstName = viewModel.UserViewModel.User.FirstName;
                    user.LastName = viewModel.UserViewModel.User.LastName;
                    user.Phone = viewModel.UserViewModel.User.Phone;
                    user.Birth = viewModel.UserViewModel.User.Birth;
                    user.AvatarPath = viewModel.UserViewModel.User.AvatarPath;

                    await _userManager.UpdateAsync(user);
                    _notyf?.Success("Updated profile successfully.");
                    return RedirectToAction("Index");
                }
                default:
                    var errors = ModelState
                        .Where(x => x.Value is { Errors.Count: > 0 })
                        .Select(x => new
                        {
                            key = x.Key, errorMessage = x.Value?.Errors.Select(e => e.ErrorMessage).FirstOrDefault()
                        })
                        .OrderBy(x => x.key)
                        .ToList();
                    _notyf?.Error(errors.ToString());
                    // return Json(new { isValid = false, errors });
                    return RedirectToAction("Index");
            }
            
        }
        
        [Route("/admin/profile")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateAvatar(ProfileAdminViewModel profileAdminViewModel)
        {
         
            var user = await _userManager.GetUserAsync(User);
            if (user == null){ return NotFound(); }

            if (profileAdminViewModel?.UserViewModel?.AvatarPath != null)
            {
                user.AvatarPath = "/images/user/" +
                                  Utils.Utils.SaveImage(profileAdminViewModel.UserViewModel.AvatarPath,
                                      "wwwroot/images/user");




                await _userManager.UpdateAsync(user);
                _notyf?.Success("Updated Avatar successfully.");
            }
            else
            {
                _notyf?.Warning("No Image to update Avatar.");
            }

            return RedirectToAction("Index");
            

        }
        
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ProfileAdminViewModel profileAdminViewModel)
        {
            var user = await _userManager.GetUserAsync(User);
         
                profileAdminViewModel.UserViewModel = new UserViewModel
                {
                    User = user
                };
            
            
            ViewBag.PasswordChangeAttempted = true;
            if (!ModelState.IsValid) { return View("index", profileAdminViewModel); }
            var isCurrentPasswordValid = await _userManager.CheckPasswordAsync(user, profileAdminViewModel.ChangePasswordViewModel.CurrentPassword);
            
            if (!isCurrentPasswordValid)
            {
                ModelState.AddModelError("ChangePassword.CurrentPassword", "Current password is incorrect");
                _notyf.Error("Current password is incorrect");
                return View("index", profileAdminViewModel);
            }
            

            var changePasswordResult = await _userManager.ChangePasswordAsync(user, profileAdminViewModel.ChangePasswordViewModel.CurrentPassword, profileAdminViewModel.ChangePasswordViewModel.NewPassword);
            if (!changePasswordResult.Succeeded) return RedirectToAction("index", profileAdminViewModel);

            _notyf.Success("Password changed successfully");
            return RedirectToAction("index", "profileadmin");
        }
}