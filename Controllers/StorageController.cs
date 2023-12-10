using Microsoft.AspNetCore.Mvc;

namespace IS220_WebApplication.Controllers;

public class StorageController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult DownloadGame()
    {
        var fileId = "17irDaIm3MhkIgBgX9dWe-EnDyepmwgYa"; // cái file id của cái game đó
        var url = $"https://drive.google.com/uc?export=download&id={fileId}";
        return Redirect(url);
    }
}