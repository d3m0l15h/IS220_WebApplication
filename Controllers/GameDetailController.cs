using Microsoft.AspNetCore.Mvc;

namespace IS220_WebApplication.Controllers;

public class GameDetailController : Controller
{
    // GET
    public IActionResult Index(string slug)
    {
        var id = int.Parse(slug.Split('-').Last());
        return View();
    }
}