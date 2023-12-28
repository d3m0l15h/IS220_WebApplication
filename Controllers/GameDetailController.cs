using IS220_WebApplication.Context;
using IS220_WebApplication.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
namespace IS220_WebApplication.Controllers;

public class GameDetailController : Controller
{
    private readonly MyDbContext _db;

    public GameDetailController(MyDbContext db)
    {
        _db = db;
    }

    [Route("game/{title}-{id}")]
    public async Task<IActionResult> Index(string title, uint id)
    {
        var model = new CombinedViewModel
        {
            Game = await _db.Games
                .Include(g => g.DeveloperNavigation)
                .Include(g => g.PublisherNavigation)
                .Include(g => g.Categories)
                .FirstOrDefaultAsync(g => g.Id == id),

            StorageViewModel = new StorageViewModel
            {
                purchasedGame = _db.OrderDetails.Include(x => x.Order)
                    .Include(x => x.Game)
                    .Where(x => x.Order.Uid.ToString() == User.FindFirstValue(ClaimTypes.NameIdentifier) && x.GameType == 0)
                    .Select(x => new
                    {
                        x.Game.Title,
                    })
                    .Distinct()
                    .ToList()
                    .Cast<object>()
                    .ToList(),

            }
        };

        return View(model);
    }
}