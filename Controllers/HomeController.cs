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
        public async Task<IActionResult> Index()
        {
            var viewModel = new CombinedViewModel
            {
                NewGame = _db.Games.OrderByDescending(game => game.ReleaseDate)
                    .Include(game => game.Categories)
                    .Take(8).ToList(),
                ConsoleGame = _db.Games.Where(game => game.Type == 1)
                    .Include(game => game.Categories)
                    .ToList(),
                SoftwareGame = _db.Games.Where(game => game.Type == 1)
                    .Include(game => game.Categories)
                    .ToList(),
                HotGame = _db.Games
                    .Join(_db.OrderDetails,
                        game => game.Id,
                        orderDetail => orderDetail.GameId,
                        (game, orderDetail) => new { game, orderDetail })
                    .GroupBy(x => x.game.Id)
                    .OrderByDescending(g => g.Count())
                    .Take(8)
                    .Select(g => g.First().game)
                    .ToList()
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