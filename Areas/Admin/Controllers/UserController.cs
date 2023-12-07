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

        public IActionResult Index()
        {
            IEnumerable<Aspnetuser> objUsers = _db.Aspnetusers.ToList();
            return View(objUsers);
        }


        public IActionResult Profile()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            var viewModel = new UserViewModel();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUser(UserViewModel viewModel)
        {
            viewModel.User.AvatarPath = Utils.Utils.SaveImage(viewModel.AvatarPath, "wwwroot/images/user");
            if (viewModel.AvatarPath == null)
                viewModel.User.AvatarPath = "/admin/img/svg/userExtra.svg";
            viewModel.User.Role = 1;
            ModelState.Remove("User.PasswordHash");
            ModelState.Remove("User.AvatarPath");
            if (viewModel.AvatarPath == null)
                ModelState.Remove("AvatarPath");
            Console.WriteLine("heheeehehehe" + viewModel.User.AvatarPath);
            Utils.Utils.CheckModelState(ModelState);

            switch (ModelState.IsValid)
            {
                case true:
                {
                    var existingUserWithUsername = await _userManager.FindByNameAsync(viewModel.User.UserName);
                    if (existingUserWithUsername != null)
                    {
                        ModelState.AddModelError("Username", "Username already exists.");
                        return Json(new { isValid = false, errors = new List<string> { "Username already exists." } });
                    }

                    var existingUserWithEmail = await _userManager.FindByEmailAsync(viewModel.User.Email);
                    if (existingUserWithEmail != null)
                    {
                        ModelState.AddModelError("Email", "Email already exists.");
                        return Json(new { isValid = false, errors = new List<string> { "Email already exists." } });
                    }

                    var user = new Aspnetuser
                    {
                        UserName = "viewModel.User.UserName",
                        Email = "truongducquoc5881@gmail.com",
                        FirstName = "FirstName",
                        LastName ="LastName",
                        Phone = "viewModel.User.Phone",
                       
                        Status = "viewModel.User.Status",
                        LockoutEnabled = false,
                    };
                    CheckModelState();
                    var result = await _userManager.CreateAsync(user, "123456");
                    if (!result.Succeeded)
                    {
                        return Json(new
                            { isValid = false, errors = result.Errors.Select(e => e.Description).ToList() });
                    }
                    
                    _notyf?.Success("Add new user successfully.");
                    return Json(new { isValid = true, message = user });
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
                    return Json(new { isValid = false, errors });
            }
        }


        [HttpGet]
        public async Task<IActionResult> EditUser(uint id)
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