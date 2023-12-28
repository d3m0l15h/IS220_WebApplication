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
                    .Where(game => game.Status == "active")
                    .Take(8).ToList(),
                ConsoleGame = _db.Games.Where(game => game.Type == 1 && game.Status == "active")
                    .Include(game => game.Categories)
                    .ToList(),
                SoftwareGame = _db.Games.Where(game => game.Type == 1 )
                    .Include(game => game.Categories)
                    .ToList(),
                HotGame = _db.Games
                    .Where(game => game.Status == "active")
                    .GroupJoin(_db.OrderDetails,
                        game => game.Id,
                        orderDetail => orderDetail.GameId,
                        (game, orderDetails) => new { game, orderDetails })
                    .SelectMany(x => x.orderDetails.DefaultIfEmpty(), (x, y) => new { x.game, OrderDetail = y })
                    .GroupBy(x => x.game)
                    .OrderByDescending(g => g.Count())
                    .Take(8)
                    .Select(g => g.Key)
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