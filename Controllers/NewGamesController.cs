using Microsoft.AspNetCore.Mvc;

namespace IS220_WebApplication.Controllers;

public class NewGamesController : Controller
{
    // GET
    public IActionResult NewGamePage()
    {
        return View();
    }
}