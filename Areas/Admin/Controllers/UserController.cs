using System.Linq.Expressions;
using AspNetCoreHero.ToastNotification.Abstractions;
using IS220_WebApplication.Areas.Admin.Models;
using IS220_WebApplication.Areas.Admin.Models.Authentication;
using IS220_WebApplication.Context;
using IS220_WebApplication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace IS220_WebApplication.Areas.Admin.Controllers
{
    [Authentication]
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly MyDbContext _db;
        private readonly INotyfService? _notyf;
        private readonly UserManager<Aspnetuser> _userManager;

        public UserController(MyDbContext db, INotyfService notyf, UserManager<Aspnetuser> userManager)
        {
            _db = db;
            _notyf = notyf;
            _userManager = userManager;
        }
        // GET

        public IActionResult Index(string searchQuery, int page = 1, int pageSize = 3)
        {
            Console.WriteLine(searchQuery);
            IQueryable<Aspnetuser> users = _db.Aspnetusers.OrderBy(u => u.Id);
            if (!string.IsNullOrEmpty(searchQuery))
            {
                users = users.Where(u => u.UserName.Contains(searchQuery));
            }

            return View(users.ToList());
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(UserViewModel viewModel)
        {
            ModelState.Remove("User.PasswordHash");
            if (viewModel.AvatarPath != null)
            {
                viewModel.User.AvatarPath =
                    "/images/user/" + Utils.Utils.SaveImage(viewModel.AvatarPath, "wwwroot/images/user");
            }
            else
            {
                viewModel.User.AvatarPath = "/admin/img/svg/userExtra.svg";
                ModelState.Remove("User.AvatarPath");
                ModelState.Remove("AvatarPath");
            }

            viewModel.User.Role = 1;
            Utils.Utils.CheckModelState(ModelState);
            switch (ModelState.IsValid)
            {
                case true:
                {
                    var existingUserWithUsername = await _userManager.FindByNameAsync(viewModel.User.UserName);
                    if (existingUserWithUsername != null)
                    {
                        ModelState.AddModelError("Username", "Username already exists.");
                        _notyf?.Error("Username already exists.");
                        return View(viewModel);
                    }

                    var existingUserWithEmail = await _userManager.FindByEmailAsync(viewModel.User.Email);
                    if (existingUserWithEmail != null)
                    {
                        ModelState.AddModelError("Email", "Email already exists.");
                        _notyf?.Error("Email already exists.");
                        return View(viewModel);
                    }

                    var user = new Aspnetuser
                    {
                        UserName = viewModel.User.UserName,
                        Email = viewModel.User.Email,
                        FirstName = viewModel.User.FirstName,
                        LastName = viewModel.User.LastName,
                        Phone = viewModel.User.Phone,
                        Status = viewModel.User.Status,
                        Birth = viewModel.User.Birth,
                        AvatarPath = viewModel.User.AvatarPath,
                        LockoutEnabled = false,
                    };

                    var result = await _userManager.CreateAsync(user, "123456");
                    if (!result.Succeeded)
                    {
                        return Json(new
                            { isValid = false, errors = result.Errors.Select(e => e.Description).ToList() });
                    }

                    await _db.SaveChangesAsync();
                    _notyf?.Success("Add new user successfully.");
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
                    return View();
            }

        }


        [HttpGet]
        public async Task<IActionResult> Edit(uint id)
        {
            var user = await _db.Users
                .FirstOrDefaultAsync(g => g.Id == id);

            if (user == null) return NotFound();
            var viewModel = new UserViewModel()
            {
                User = user,
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserViewModel viewModel)
        {

            ModelState.Remove("User.PasswordHash");
            var user = await _db.Aspnetusers
                .FirstOrDefaultAsync(u => u.Id == viewModel.User.Id);
            if (user == null)
            {
                return NotFound();
            }

            if (viewModel.AvatarPath != null)
            {
                viewModel.User.AvatarPath =
                    "/images/user/" + Utils.Utils.SaveImage(viewModel.AvatarPath, "wwwroot/images/user");
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
                        return View(viewModel);
                    }

                    var existingUserWithEmail = await _userManager.FindByEmailAsync(viewModel.User.Email);
                    if (existingUserWithEmail != null && existingUserWithEmail.Id != user.Id)
                    {
                        ModelState.AddModelError("Email", "Email already exists.");
                        _notyf?.Error("Email already exists.");
                        return View(viewModel);
                    }

                    user.UserName = viewModel.User.UserName;
                    user.Email = viewModel.User.Email;
                    user.FirstName = viewModel.User.FirstName;
                    user.LastName = viewModel.User.LastName;
                    user.Phone = viewModel.User.Phone;
                    user.Status = viewModel.User.Status;
                    user.Birth = viewModel.User.Birth;
                    user.AvatarPath = viewModel.User.AvatarPath;
                    _db.Aspnetusers.Update(user);
                    await _db.SaveChangesAsync();
                    _notyf?.Success("Updated user successfully.");
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
                    return View();
            }

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Remove(uint id)
        {
            var user = await _db.Users.FirstOrDefaultAsync(g => g.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            // Soft delete by updating status
            user.Status = "deleted";
            user.Email = null;
            await _db.SaveChangesAsync();

            _notyf?.Success("User removed successfully.");
            return RedirectToAction("Index");
        }


    //     public IQueryable<Aspnetuser> FilterData(string column, IQueryable<Aspnetuser> users)
    //     {
    //         // Define the property to be used for sorting dynamically
    //         Expression<Func<Aspnetuser, object>> orderByProperty;
    //
    //         switch (column)
    //         {
    //             case "emaill":
    //                 orderByProperty = user => user.Email.OrderBy(Email);
    //                 break;
    //             case "birthday":
    //                 orderByProperty = user => user.birthday;
    //                 break;
    //             // Add other cases for additional columns
    //
    //             default:
    //                 // If the column name is not recognized, default to sorting by ID or another property
    //                 orderByProperty = user => user.Id;
    //                 break;
    //         }
    //
    //         // Order the users based on the specified column
    //         var newUsers = users.OrderBy(orderByProperty);
    //
    //         return ;
    //     }
    // }

    public void CheckModelState()
        {
            foreach (var modelStateKey in ModelState.Keys)
            {
                var modelStateVal = ModelState[modelStateKey];
                foreach (var error in modelStateVal?.Errors!)
                {
                    // Log or print the error message
                    Console.WriteLine($"{modelStateKey}: {error.ErrorMessage}");
                }
            }
        }
    }
}