
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
    [Area("Admin")]
    [Authentication]
    public class DashboardController : Controller
    {
        private readonly MyDbContext _db;
        private readonly INotyfService? _notyf;
        private readonly UserManager<Aspnetuser> _userManager;

        public DashboardController(MyDbContext db, INotyfService notyf, UserManager<Aspnetuser> userManager)
        {
            _db = db;
            _notyf = notyf;
            _userManager = userManager;
        }
        
        
        
        public IActionResult Index()
        {
            var viewModel = new DashboardViewModel
            {
                User = _db.Aspnetusers.ToList(),
                Game = _db.Games.ToList(),
                Order = _db.Orders.ToList()
            };
            return View(viewModel);
        }

        public double AggregateSales()
        {
            var sum = 0;
            
            return sum;
        }

        
    }
}