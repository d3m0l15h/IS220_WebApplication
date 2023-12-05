using Microsoft.AspNetCore.Mvc;

namespace IS220_WebApplication.Controllers;

public class ConsoleGamePageController : Controller
{
    // GET
    public IActionResult ConsoleGamePage()
    {
        return View();
    }
}