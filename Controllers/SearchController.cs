using Microsoft.AspNetCore.Mvc;

namespace IS220_WebApplication.Controllers;

public class SearchController : Controller
{
    [Route("/developer/{developer}")]
    public IActionResult Developer(string developer)
    {
        return View("Index");
    }
    
    [Route("/publisher/{publisher}")]
    public IActionResult Publisher(string publisher)
    {
        return View("Index");
    }
    
    [Route("/category/{category}")]
    public IActionResult Category(string category)
    {
        return View("Index");
    }
}