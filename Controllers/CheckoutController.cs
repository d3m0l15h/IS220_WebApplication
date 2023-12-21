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
        var model = new CombinedViewModel
        {
            Checkout = await _db.Carts
                .FirstOrDefaultAsync(c => c.Uid == uint.Parse(userId))
        };
        return View(model);
    }
}