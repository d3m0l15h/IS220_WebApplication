using Microsoft.AspNetCore.Mvc;

namespace IS220_WebApplication.Controllers;

public class TransactionInfoController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}