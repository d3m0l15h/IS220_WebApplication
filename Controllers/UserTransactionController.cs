using Microsoft.AspNetCore.Mvc;

namespace IS220_WebApplication.Controllers;

public class UserTransactionController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}