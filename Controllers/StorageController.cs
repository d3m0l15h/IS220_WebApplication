using IS220_WebApplication.Context;
using System.Security.Claims;
using AspNetCoreHero.ToastNotification.Abstractions;
using IS220_WebApplication.Context;
using IS220_WebApplication.Models;
using IS220_WebApplication.Models.ViewModel;
using IS220_WebApplication.Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
namespace IS220_WebApplication.Controllers;

public class StorageController : Controller
{
    private readonly MyDbContext _context;

    public StorageController(MyDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var purchasedGame = _context.OrderDetails
            .Include(x => x.Order)
            .Include(x => x.Game)
            .Where(x => x.Order.Uid.ToString() == userId && x.GameType == 0)
            .Select(x => new
            {
                x.Game.ImgPath,
                x.Game.DownloadLink,
            })
            .Distinct()
            .ToList()
            .Cast<object>()
            .ToList();
        var order = _context.Orders
            .Include(x => x.OrderDetails)
            .Include(x => x.StatusNavigation)
            .Where(x => x.Uid.ToString() == userId)
            .Select(x => new
            {
                date = x.Date,
                id = x.Id,
                total = x.OrderDetails.Sum(x => x.Price * x.Quantity),
                status = x.StatusNavigation.Name,
            })
            .ToList()
            .Cast<object>()
            .ToList();
        return View(new CombinedViewModel
        {
            StorageViewModel = new StorageViewModel
            {
                purchasedGame = purchasedGame,
                order = order
            }
        });
    }
    public IActionResult DownloadGame(string url)
    {
        return Redirect(url);
    }
}