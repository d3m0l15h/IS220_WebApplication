using Microsoft.AspNetCore.Mvc;

namespace IS220_WebApplication.Controllers;

public class VietHoaGameController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}