using AspNetCoreHero.ToastNotification.Abstractions;
using AspNetCoreHero.ToastNotification.Notyf;
using IS220_WebApplication.Areas.Admin.Models.Authentication;
using IS220_WebApplication.Context;
using IS220_WebApplication.Database;
using IS220_WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using static IS220_WebApplication.Database.UsersProcessor;

namespace IS220_WebApplication.Areas.Admin.Controllers
{
    [Area("admin")]
    public class LoginController : Controller
    {
        private readonly MyDbContext _db;

        private readonly INotyfService? _notyf;
        private ProcessorManager _processorManager;
       

        public LoginController(MyDbContext db, INotyfService notyf)
        {
            _db = db;
            _notyf = notyf;
            _processorManager = new ProcessorManager(db);
            
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
               
                var query = $"Username = '{user.Username}' AND Password = '{user.Password}' AND Role = 1 AND Status = 'active'";
                 var data = _processorManager.GetUsersProcessor().GetData(0, -1, query,"").GetData();
                 
                if (!data.IsNullOrEmpty())
                {
                    var email = Utils.Utils.GetDataValuesByColumnName(data, "Email")[0];
                
                    {
                        HttpContext.Session.SetString("email", email);
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
                
                
            }
            _notyf?.Error("Login failed");
            return View();
        }
    }
}