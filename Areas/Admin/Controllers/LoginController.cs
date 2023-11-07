using AspNetCoreHero.ToastNotification.Abstractions;
using AspNetCoreHero.ToastNotification.Notyf;
using IS220_WebApplication.Areas.Admin.Models.Authentication;
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
            if (HttpContext.Session.GetString("email") != null) return RedirectToAction("index", "dashboard");
            return View();

        }

        [HttpPost]
        public IActionResult Index(User user, string? returnUrl = null)
        {
            if (HttpContext.Session.GetString("email") == null)
            {
                var u = _db.Users.FirstOrDefault(x => x.Username.Equals(user.Username) &&
                                                      x.Password.Equals(user.Password) &&
                                                      x.Role == 1);
                if (u != null)
                {
                    HttpContext.Session.SetString("email", u.Email);
                    var originalUrl = HttpContext.Request.Cookies["OriginalUrl"];
                    HttpContext.Response.Cookies.Delete("OriginalUrl");

                    if (!string.IsNullOrEmpty(originalUrl))
                    {
                        return LocalRedirect(originalUrl);
                    }
                    _notyf?.Success("Login success");
                    return RedirectToAction("index", "dashboard");
                }
            }
            _notyf?.Error("Login failed");
            return View();
        }
    }
}