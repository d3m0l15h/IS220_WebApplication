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

    // [Route("cart/{title}-{id}")]
    [HttpPost]
    public IActionResult Add(uint game_id)
    {
        if (ModelState.IsValid)
        {
            string uid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var a = new Cart()
            {
                Uid = uint.Parse(uid),
                GameId = game_id
            };
            _db.Carts.Add(a);
            _db.SaveChanges();
            return Ok("Success");
        }

        // return View();
        return RedirectToAction("index", "home");
    }
}