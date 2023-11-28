using Microsoft.AspNetCore.Mvc;

namespace IS220_WebApplication.Controllers;

public class UserStorageController : Controller
{
    // GET
    public IActionResult UserStorage()
    {
        return View();
    }
}