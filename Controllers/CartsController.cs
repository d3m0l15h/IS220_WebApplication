using System.Security.Claims;
using IS220_WebApplication.Context;
using IS220_WebApplication.Models;
using IS220_WebApplication.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace IS220_WebApplication.Controllers;

public class CartsController : Controller
{
    private readonly MyDbContext _db;

    public CartsController(MyDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        //return View();
        return RedirectToAction("index", "home");
    }
    [HttpPost]
    public IActionResult Add(uint game_id)
    {
        if (!ModelState.IsValid) return RedirectToAction("index", "home");
        var uid = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var userId = uint.Parse(uid);

        // Check if the game_id already exists in the cart for this user
        if (_db.Carts.Any(c => c.Uid == userId && c.GameId == game_id))
        {
            return Ok("The game is already in your cart.");
        }

        var cartItem = new Cart()
        {
            Uid = userId,
            GameId = game_id
        };
        _db.Carts.Add(cartItem);
        _db.SaveChanges();
        return Ok("Successfully added to cart.");

        // return View();
    }
    [HttpGet]
    public IActionResult Get()
    {
        if (!ModelState.IsValid) return RedirectToAction("index","home");
        var uid = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var userCart = _db.Carts
            .Where(c => c.Uid == uint.Parse(uid))
            .Join(
                _db.Games,
                cart => cart.GameId,
                game => game.Id,
                (cart, game) => new CartDetail
                {
                    GameId = game.Id,
                    GameTitle = game.Title,
                    GameImg = game.ImgPath,
                    GamePrice = game.Price,
                    Quantity = cart.Quantity
                }
            )
            .ToList();
        return Ok(userCart);

    }
    [HttpPost]
    public IActionResult Remove(uint game_id)
    {
        var cartItem = _db.Carts.Where(c => c.GameId == game_id).FirstOrDefault();
        if (cartItem == null)
        {
            return NotFound();
        }

        _db.Carts.Remove(cartItem);
        _db.SaveChanges();

        return Ok("Successfully removed from cart.");
    }
}