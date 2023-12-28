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
        var uid = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (uid == null)
        {
            return Unauthorized();
        }
        var userId = uint.Parse(uid);
        var defaultAddress = _db.Addresses
            .FirstOrDefault(a => a.UserId == userId && a.IsDefault == true);

        if (defaultAddress == null)
        {
            return NotFound();
        }
        return Ok(defaultAddress);
    }

    [Route("update-address")]
    [HttpPost]
    public IActionResult UpdateAddress(uint id, [FromBody] AddressUpdateModel model)
    {
        string uid = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (uid == null)
        {
            return Unauthorized();
        }
        uint userId = uint.Parse(uid);
        var address = _db.Addresses
            .Where(a => a.Id == model.Id)
            .FirstOrDefault();
        if (address == null)
        {
            return NotFound();
        }
        if (address.UserId != userId)
        {
            return Unauthorized();
        }
        address.Receiver = model.Receiver;
        address.Phone = model.Phone;
        address.Street = model.Street;
        address.Ward = model.Ward;
        address.City = model.City;
        address.State = model.State;
        _db.Entry(address).State = EntityState.Modified;
        _db.SaveChanges();
        return Ok(address);
    }
}