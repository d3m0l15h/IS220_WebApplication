using Microsoft.AspNetCore.Mvc;

namespace IS220_WebApplication.Controllers;

public class StorageController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}