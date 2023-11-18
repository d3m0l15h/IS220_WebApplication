using Microsoft.AspNetCore.Mvc;

namespace IS220_WebApplication.Controllers;

public class VietHoaGamePageController : Controller
{
    // GET
    public IActionResult VietHoaGamePage()
    {
        return View();
    }
}