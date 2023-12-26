
using IS220_WebApplication.Areas.Admin.Models.Authentication;
using Microsoft.AspNetCore.Mvc;


namespace IS220_WebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authentication]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
    }
}