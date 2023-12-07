using IS220_WebApplication.Context;
using Microsoft.AspNetCore.Mvc;

namespace IS220_WebApplication.Controllers;

public class ConsoleGameController : Controller
{
    private readonly MyDbContext _db;

    public ConsoleGameController(MyDbContext db)
    {
        _db = db;
    }
    // GET
    public IActionResult Index()
    {
        return View();
    }
    //GameDetail
    [Route("download/{title}-{id}")]
    public async Task<IActionResult> Index(string title, uint id)
    {
        var game = await _db.Games.FindAsync(id);
        if (game == null)
        {
            return NotFound();
        }
        ViewBag.Game = game;
        return View();
    }
}