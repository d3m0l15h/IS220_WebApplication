using Microsoft.AspNetCore.Mvc;

namespace IS220_WebApplication.Controllers;

public class ConsoleGamesController : Controller
{
    // GET
    public IActionResult ConsoleGamePage()
    {
        return View();
    }
}