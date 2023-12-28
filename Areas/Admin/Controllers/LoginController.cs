using AspNetCoreHero.ToastNotification.Abstractions;
using IS220_WebApplication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace IS220_WebApplication.Areas.Admin.Controllers
{
    [Area("admin")]
    public class LoginController : Controller
    {
        private readonly INotyfService? _notyf;
        private readonly UserManager<Aspnetuser> _userManager;
        private readonly SignInManager<Aspnetuser> _signInManager;


        public LoginController(INotyfService notyf, UserManager<Aspnetuser> userManager, SignInManager<Aspnetuser> signInManager)
        {
            _notyf = notyf;
            _userManager = userManager;
            _signInManager = signInManager; 
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (User.Identity is { IsAuthenticated: true }) return RedirectToAction("index", "dashboard");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Aspnetuser user)
        {
            ModelState.Remove("Status");
            if (!ModelState.IsValid) return View();

            // Check if the user exists
            var existingUser = await _userManager.FindByNameAsync(user.UserName!);
            if (existingUser == null)
            {
                _notyf?.Error("Login failed");
                return View();
            }
            
            var result = await _signInManager.PasswordSignInAsync(user.UserName!, user.PasswordHash!, false, false);
            if (result.Succeeded)
            {
                if (existingUser.Role != 1)
                {
                    _notyf?.Error("Permission Invalid");
                    await _signInManager.SignOutAsync();
                    return View();
                }
                
                var originalUrl = HttpContext.Request.Cookies["OriginalUrl"];
                HttpContext.Response.Cookies.Delete("OriginalUrl");
               
                
                if (!string.IsNullOrEmpty(originalUrl))
                {
                    return LocalRedirect(originalUrl);
                }
                _notyf?.Success("Login successful");

                @ViewData["User"] = "1234567";
                
                return RedirectToAction("index", "dashboard");
            }
            
            
            _notyf?.Error("Wrong username or password");
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            _notyf?.Success("You have been logged out");
            return RedirectToAction("index", "login", new { area = "admin" });
        }
    }
}