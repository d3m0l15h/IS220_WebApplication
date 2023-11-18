using Microsoft.AspNetCore.Mvc;

namespace IS220_WebApplication.Controllers;

public class DownloadPageController : Controller
{
    // GET
    public IActionResult DownloadGame()
    {
        return View();
    }
}