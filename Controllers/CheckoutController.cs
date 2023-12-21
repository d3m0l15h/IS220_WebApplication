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
        string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var model = new CombinedViewModel();
        uint userIdValue;
        uint.TryParse(userId, out userIdValue);

        model.Checkouts = await _db.Carts
            .Join(_db.Games,
                cart => cart.GameId,
                game => game.Id,
                (cart, game) => new { Cart = cart, Game = game })
            .Where(c => c.Cart.Uid == userIdValue)
            .Select(c => new CheckoutViewModel
            {
                CheckoutItems = new List<CheckoutItems>
                {
                    new CheckoutItems
                    {
                        Title = c.Game.Title,
                        Quantity = c.Cart.Quantity,
                        Price = c.Game.Price,
                        Type = c.Game.Type
                    }
                }
            })
            .ToListAsync();

        return View(model);
    }
}