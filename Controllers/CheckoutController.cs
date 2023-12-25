using IS220_WebApplication.Context;
using IS220_WebApplication.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace IS220_WebApplication.Controllers;

public class CheckoutController : Controller
{
    private readonly MyDbContext _db;

    public CheckoutController(MyDbContext db)
    {
        _db = db;
    }

    [Route("checkout")]
    public async Task<IActionResult> Index()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var model = new CombinedViewModel();
        uint userIdValue;
        uint.TryParse(userId, out userIdValue);
        model.CheckoutItems = await _db.Carts
            .Join(_db.Games,
                cart => cart.GameId,
                game => game.Id,
                (cart, game) => new { Cart = cart, Game = game })
            .Where(c => c.Cart.Uid == userIdValue)
            .Select(c => new CheckoutItems
            {
                Title = c.Game.Title,
                Quantity = c.Cart.Quantity,
                Price = c.Game.Price,
                Type = c.Cart.Type,
                Image = c.Game.ImgPath
            })
            .ToListAsync();

        model.DefaultAddress = await _db.Addresses
            .FirstOrDefaultAsync(a => a.UserId == userIdValue && a.IsDefault == true);
        model.NonDefaultAddresses = await _db.Addresses
            .Where(a => a.UserId == userIdValue && a.IsDefault == false)
            .ToListAsync();
        return View(model);
    }
}