using IS220_WebApplication.Context;
using IS220_WebApplication.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using IS220_WebApplication.Models;
using Microsoft.AspNetCore.Identity;

namespace IS220_WebApplication.Controllers;

public class CheckoutController : Controller
{
    private readonly MyDbContext _db;
    private readonly UserManager<Aspnetuser> _userManager;

    public CheckoutController(MyDbContext db, UserManager<Aspnetuser> userManager)
    {
        _db = db;
        _userManager = userManager;
    }
    
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var userId = _userManager.GetUserAsync(User).Result.Id;
        var model = new CombinedViewModel
        {
            CheckoutItems = await _db.Carts
                .Join(_db.Games,
                    cart => cart.GameId,
                    game => game.Id,
                    (cart, game) => new { Cart = cart, Game = game })
                .Where(c => c.Cart.Uid == userId)
                .Select(c => new CheckoutItems
                {
                    Title = c.Game.Title,
                    Quantity = c.Cart.Quantity,
                    Price = c.Game.Price,
                    Type = c.Cart.Type,
                    Image = c.Game.ImgPath
                })
                .ToListAsync(),
            DefaultAddress = await _db.Addresses
                .FirstOrDefaultAsync(a => a.UserId == userId && a.IsDefault == true),
            NonDefaultAddresses = await _db.Addresses
                .Where(a => a.UserId == userId && a.IsDefault == false)
                .ToListAsync()
        };

        return View(model);
    }
}