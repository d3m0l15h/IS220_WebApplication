using AspNetCoreHero.ToastNotification.Abstractions;
using IS220_WebApplication.Areas.Admin.Models.Authentication;
using IS220_WebApplication.Context;
using IS220_WebApplication.Models;
using Microsoft.AspNetCore.Mvc;


namespace IS220_WebApplication.Areas.Admin.Controllers
{
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
        [Authentication]
        public IActionResult Index()
        {
            IEnumerable<Aspnetuser> objUsers = _db.Users.ToList();
            return View(objUsers);
        }

        [Authentication]
        public IActionResult Profile()
        {
            return View();
        }

        [Authentication]
        public IActionResult AddUser()
        {
            return View();
        }
    }
}

