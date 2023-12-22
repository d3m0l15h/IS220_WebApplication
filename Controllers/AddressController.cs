using System.Security.Claims;
using IS220_WebApplication.Context;
using IS220_WebApplication.Models;
using IS220_WebApplication.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace IS220_WebApplication.Controllers;

public class AddressController : Controller
{
    private readonly MyDbContext _db;

    public AddressController(MyDbContext db)
    {
        _db = db;
    }
    [HttpGet]
    public IActionResult GetDefaultAddress()
    {
        string uid = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (uid == null)
        {
            return Unauthorized();
        }
        uint userId = uint.Parse(uid);
        var defaultAddress = _db.Addresses
            .Where(a => a.UserId == userId && a.IsDefault == true)
            .FirstOrDefault();

        if (defaultAddress == null)
        {
            return NotFound();
        }

        return Ok(defaultAddress);
    }
    // [HttpPost]
    // public IActionResult Add(uint game_id, uint type, uint quantity)
    // {
    //     if (ModelState.IsValid)
    //     {
    //         string uid = User.FindFirstValue(ClaimTypes.NameIdentifier);
    //         uint userId = uint.Parse(uid);

    //         // Check if the game_id as software type already exists in the cart for this user
    //         if (_db.Carts.Any(c => c.Uid == userId && c.GameId == game_id && type == GameType.Software && c.Type == type))
    //         {
    //             return Ok("The game is already in your cart.");
    //         }

    //         // Update the quantity if the game_id already exists in the cart for this user
    //         var eCartItem = _db.Carts.Where(c => c.Uid == userId && c.GameId == game_id && c.Type == type).FirstOrDefault();
    //         if (eCartItem != null)
    //         {
    //             eCartItem.Quantity += quantity;
    //             _db.SaveChanges();
    //             return Ok("Successfully updated cart.");
    //         }

    //         // Add the game to the cart
    //         var cartItem = new Cart()
    //         {
    //             Uid = userId,
    //             GameId = game_id,
    //             Type = type,
    //             Quantity = quantity
    //         };
    //         _db.Carts.Add(cartItem);
    //         _db.SaveChanges();
    //         return Ok("Successfully added to cart.");
    //     }
    //     else
    //     {
    //         return View();
    //     }
    // }
    // [HttpGet]
    // public IActionResult Get()
    // {
    //     if (ModelState.IsValid)
    //     {
    //         string uid = User.FindFirstValue(ClaimTypes.NameIdentifier);
    //         var userCart = _db.Carts
    //             .Where(c => c.Uid == uint.Parse(uid))
    //             .Join(
    //                 _db.Games,
    //                 cart => cart.GameId,
    //                 game => game.Id,
    //                 (cart, game) => new CartDetail
    //                 {
    //                     GameId = game.Id,
    //                     GameTitle = game.Title,
    //                     GameImg = game.ImgPath,
    //                     GamePrice = game.Price,
    //                     GameType = cart.Type,
    //                     GameTypeStr = GameType.Get(cart.Type),
    //                     Quantity = cart.Quantity,
    //                     UpdatedAt = cart.UpdatedAt
    //                 }
    //             )
    //             // .OrderByDescending(c => c.UpdatedAt)
    //             .ToList();
    //         return Ok(userCart);
    //     }
    //     else
    //     {
    //         return View();
    //     }
    // }
    // [HttpPost]
    // public IActionResult Remove(uint game_id, uint type)
    // {
    //     var cartItem = _db.Carts.Where(c => c.GameId == game_id && c.Type == type).FirstOrDefault();
    //     if (cartItem == null)
    //     {
    //         return NotFound();
    //     }

    //     _db.Carts.Remove(cartItem);
    //     _db.SaveChanges();

    //     return Ok("Successfully removed from cart.");
    // }

    // [HttpPost]
    // public IActionResult Update(uint game_id, uint type, uint quantity)
    // {
    //     var cartItem = _db.Carts.Where(c => c.GameId == game_id && c.Type == type).FirstOrDefault();
    //     if (cartItem == null)
    //     {
    //         return NotFound();
    //     }

    //     cartItem.Quantity = quantity;
    //     _db.SaveChanges();

    //     return Ok("Successfully updated cart.");
    // }
}