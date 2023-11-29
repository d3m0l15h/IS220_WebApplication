using Microsoft.AspNetCore.Mvc;

namespace IS220_WebApplication.Controllers;

public class UserProfileController : Controller
{
    // GET
    public IActionResult UserProfile()
    {
        return View();
    }
}