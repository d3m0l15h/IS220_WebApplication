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

public class OrderController : Controller
{
    private readonly MyDbContext _db;
    private readonly INotyfService? _notyf;
    private readonly UserManager<Aspnetuser> _userManager;
    private readonly SignInManager<Aspnetuser> _signInManager;

    public OrderController(MyDbContext db, INotyfService notyf, SignInManager<Aspnetuser> signInManager,
        UserManager<Aspnetuser> userManager)
    {
        _db = db;
        _notyf = notyf;
        _signInManager = signInManager;
        _userManager = userManager;
    }
    [Route("order/{id}")]
    public async Task<IActionResult> Index(uint id)
    {
        var order = await _db.Orders
            .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Game)
            .Include(o => o.AddressNavigation)
            .FirstOrDefaultAsync(o => o.Id == id);
        if (order == null)
        {
            return NotFound();
        }
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var user = await _userManager.GetUserAsync(User);
        if (order.Uid != user.Id)
        {
            return Unauthorized();
        }
        var model = new CombinedViewModel
        {
            OrderDetailViewModel = new OrderDetailViewModel
            {
                Order = order,
                OrderDetails = order.OrderDetails,
            }
        };
        return View(model);
    }

    [Route("order")]
    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] CombinedViewModel model)
    {
        if (model == null || model.CheckoutViewModel == null)
        {
            return Json(new { isValid = false, message = "Model or CheckoutViewModel is null." });
        }

        string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var user = await _userManager.GetUserAsync(User);
        uint userIdValue;
        uint.TryParse(userId, out userIdValue);
        var order = new Order
        {
            Date = DateTime.Now,
            Uid = userIdValue,
            Status = 1,
            PaymentMethod = model.CheckoutViewModel.Paymentmethod,
            Address = model.CheckoutViewModel.SelectedAddress,
        };
        _db.Orders.Add(order);
        await _db.SaveChangesAsync();
        var cartItems = _db.Carts.Where(c => c.Uid == user.Id).ToList();
        var cartItemsWithPrice = from cartItem in cartItems
                                 join game in _db.Games on cartItem.GameId equals game.Id
                                 select new
                                 {
                                     CartItem = cartItem,
                                     Price = game.Price
                                 };
        foreach (var items in cartItemsWithPrice)
        {
            var orderDetail = new OrderDetail
            {
                OrderId = order.Id,
                GameId = items.CartItem.GameId,
                Quantity = items.CartItem.Quantity,
                GameType = items.CartItem.Type,
            };
            _db.OrderDetails.Add(orderDetail);
            await _db.SaveChangesAsync();
        }
        _db.Carts.RemoveRange(cartItems);
        await _db.SaveChangesAsync();
        _notyf?.Success("Order created successfully.");
        return Json(new { isValid = true, message = $"Order #{order.Id} created successfully.", orderId = order.Id });
    }

}