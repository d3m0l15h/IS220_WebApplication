using IS220_WebApplication.Context;
using IS220_WebApplication.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IS220_WebApplication.Controllers;

public class ConsoleGameController : Controller
{
    private readonly MyDbContext _db;

    public ConsoleGameController(MyDbContext db)
    {
        _db = db;
    }

    // GET
    public IActionResult Index(int page = 1, int pageSize = 10)
    {
        var consoleGame = new CombinedViewModel()
        {
            ConsoleGame = _db.Games.Where(game => game.Type == 1 && game.Status == "active")
                .Include(game => game.Categories)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList(),
            TotalCount = _db.Games.Count()
        };
        return View(consoleGame);
    }
}