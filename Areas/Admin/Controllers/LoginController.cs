using AspNetCoreHero.ToastNotification.Abstractions;
using AspNetCoreHero.ToastNotification.Notyf;
using IS220_WebApplication.Context;
using IS220_WebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace IS220_WebApplication.Areas.Admin.Controllers
{
    [Area("admin")]
    public class LoginController : Controller
    {
        private readonly MyDbContext _db;

        private readonly INotyfService? _notyf;

        public LoginController(MyDbContext db, INotyfService notyf)
        {
            _db = db;
            _notyf = notyf;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("email") == null)
                return View();

            return RedirectToAction("Index", "Dashboard");
        }

        [HttpPost]
        public IActionResult Index(User user)
        {
            if (HttpContext.Session.GetString("email") == null)
            {
                var u = _db.Users.FirstOrDefault(x => x.Username.Equals(user.Username) &&
                                                      x.Password.Equals(user.Password) &&
                                                      x.Role == 1);
                if (u != null)
                {
                    HttpContext.Session.SetString("email", u.Email);
                    _notyf?.Success("Login success");
                    return RedirectToAction("index", "dashboard");
                }
            }

            _notyf?.Error("Login failed");
            return View();
        }
    }
    
}

