using AspNetCoreHero.ToastNotification.Abstractions;
using IS220_WebApplication.Areas.Admin.Models;
using IS220_WebApplication.Areas.Admin.Models.Authentication;
using IS220_WebApplication.Context;
using IS220_WebApplication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
    // [HttpGet]
    public IActionResult Index()
    {
        var user = _userManager.GetUserAsync(User).Result;
        var viewModel = new UserViewModel
        {
            User = user
        };
        return View(viewModel);
    }
    
    [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProfile(UserViewModel viewModel)
        {
            
            ModelState.Remove("User.PasswordHash");
            ModelState.Remove("User.Status");

            var user = _userManager.GetUserAsync(User).Result;
            if (viewModel.AvatarPath != null)
            {
                viewModel.User.AvatarPath = "/images/user/" + Utils.Utils.SaveImage(viewModel.AvatarPath, "wwwroot/images/user");
            }
            else
            {
                viewModel.User.AvatarPath = user.AvatarPath;
                ModelState.Remove("User.AvatarPath");
                ModelState.Remove("AvatarPath");
            }
         
            Utils.Utils.CheckModelState(ModelState);
            switch (ModelState.IsValid)
            {
                case true:
                {
                    var existingUserWithUsername = await _userManager.FindByNameAsync(viewModel.User.UserName);
                    if (existingUserWithUsername != null && existingUserWithUsername.Id != user.Id)
                    {
                        ModelState.AddModelError("Username", "Username already exists.");
                        _notyf?.Error("Username already exists.");
                        return RedirectToAction("Index");
                    }

                    var existingUserWithEmail = await _userManager.FindByEmailAsync(viewModel.User.Email);
                    if (existingUserWithEmail != null && existingUserWithEmail.Id != user.Id)
                    {
                        ModelState.AddModelError("Email", "Email already exists.");
                        _notyf?.Error("Email already exists.");
                        return RedirectToAction("Index");
                    }

                    user.UserName = viewModel.User.UserName;
                    user.Email = viewModel.User.Email;
                    user.FirstName = viewModel.User.FirstName;
                    user.LastName = viewModel.User.LastName;
                    user.Phone = viewModel.User.Phone;
                    user.Birth = viewModel.User.Birth;
                    user.AvatarPath = viewModel.User.AvatarPath;

                     _db.Aspnetusers.Update(user);
                    await _db.SaveChangesAsync();
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
}