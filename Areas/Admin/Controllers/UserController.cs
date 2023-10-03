using IS220_WebApplication.Areas.Admin.Models.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace IS220_WebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        // GET
        [Authentication]
        public IActionResult Index()
        {
            return View();
        }
    }
}

