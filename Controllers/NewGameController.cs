using IS220_WebApplication.Context;
using IS220_WebApplication.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IS220_WebApplication.Controllers;

public class NewGameController : Controller
{
    private readonly MyDbContext _db;

    public NewGameController(MyDbContext db)
    {
        _db = db;
    }
    [HttpGet]
    public IActionResult Index(int page = 1, int pageSize = 10)
    {
        var newGame = new CombinedViewModel
        {
            NewGame = _db.Games.OrderByDescending(game => game.ReleaseDate)
                .Include(game => game.Categories)
                .Where(game =>game.Status == "active" )
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList(),
            TotalCount = _db.Games.Count()
        };
        return View(newGame);
    }
}