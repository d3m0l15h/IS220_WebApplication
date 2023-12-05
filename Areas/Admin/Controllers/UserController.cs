using AspNetCoreHero.ToastNotification.Abstractions;
using IS220_WebApplication.Areas.Admin.Models;
using IS220_WebApplication.Areas.Admin.Models.Authentication;
using IS220_WebApplication.Context;
using IS220_WebApplication.Models;
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

        public UserController(MyDbContext db, INotyfService notyf)
        {
            _db = db;
            _notyf = notyf;
        }
        // GET
        
        public IActionResult Index()
        {
            IEnumerable<Aspnetuser> objUsers = _db.Users.ToList();
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
            
            
                if (viewModel.AvatarPath != null)
                {
                    viewModel.User.AvatarPath = SaveImage(viewModel.AvatarPath);
                }
                else
                {
                    viewModel.User.AvatarPath = "/admin/img/svg/userExtra.svg";
                }

                viewModel.User.Status = viewModel.UserStatus;
                // viewModel.User.Password = "123456";
                viewModel.User.Role = 1;
                CheckModelState();
                
                await _db.Users.AddAsync(viewModel.User);

                _notyf?.Success("Add game successfully!");
                await _db.SaveChangesAsync();
                
            
            
                return RedirectToAction("Index");
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
        private static string SaveImage(IFormFile? imageFile)
        {
            string fileName = null!;
            if (imageFile is not { Length: > 0 }) return fileName;
            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
            fileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
            var filePath = Path.Combine(uploadsFolder, fileName);
            using var fileStream = new FileStream(filePath, FileMode.Create);
            imageFile.CopyTo(fileStream);
            return fileName;
        }
    }
    
}

