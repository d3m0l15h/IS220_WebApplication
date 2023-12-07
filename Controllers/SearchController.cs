using IS220_WebApplication.Context;
using IS220_WebApplication.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace IS220_WebApplication.Controllers;

public class SearchController : Controller
{
    private readonly MyDbContext _db;

    public SearchController(MyDbContext db)
    {
        _db = db;
    }

    [Route("/developer/{developer}/{page:int?}")]
    public IActionResult Developer(string developer, int page = 1, int pageSize = 10)
    {
        var originalDeveloperName = FromUrlFriendly(developer);
        var games = _db.Games.Where(g => g.DeveloperNavigation.Name.Equals(originalDeveloperName));
        var viewModel = new CombinedViewModel
        {
            SearchGame = games.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
            TotalCount = games.Count()
        };

        return View("Index",viewModel);
    }

    [Route("/publisher/{publisher}/{page:int?}")]
    public IActionResult Publisher(string publisher, int page = 1, int pageSize = 10)
    {
        var originalPublisherName = FromUrlFriendly(publisher);
        var games = _db.Games.Where(g => g.PublisherNavigation.Name.Equals(originalPublisherName));
        var viewModel = new CombinedViewModel
        {
            SearchGame = games.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
            TotalCount = games.Count()
        };

        return View("Index", viewModel);
    }

    [Route("/category/{category}/{page:int?}")]
    public IActionResult Category(string category, int page = 1, int pageSize = 10)
    {
        var games = _db.Games.Where(g => g.Categories.Any(c => c.Name.Equals(category)));
        var viewModel = new CombinedViewModel
        {
            SearchGame = games.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
            TotalCount = games.Count()
        };

        return View("Index", viewModel);
    }
    public static string FromUrlFriendly(string str)
    {
        return System.Net.WebUtility.UrlDecode(str.Replace('-', ' '));
    }
}