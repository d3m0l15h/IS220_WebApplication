using System.Diagnostics;
using IS220_WebApplication.Context;
using Microsoft.AspNetCore.Mvc;
using IS220_WebApplication.Models;
using IS220_WebApplication.Models.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace IS220_WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyDbContext _db;

        public HomeController(MyDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var viewModel = new CombinedViewModel
            {
                NewGame = _db.Games.OrderByDescending(game => game.ReleaseDate)
                    .Include(game => game.Categories)
                    .Take(8).ToList()
            };
            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}