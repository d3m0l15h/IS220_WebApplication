using AspNetCoreHero.ToastNotification.Abstractions;
using IS220_WebApplication.Areas.Admin.Models;
using IS220_WebApplication.Areas.Admin.Models.Authentication;
using IS220_WebApplication.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IS220_WebApplication.Areas.Admin.Controllers;

[Area("Admin")]
[Authentication]
public class OrderController : Controller
{
    private readonly MyDbContext _db;

    private readonly INotyfService _notyf;

    // GET
    public OrderController(MyDbContext db, INotyfService notyf)
    {
        _db = db;
        _notyf = notyf;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var model = new OrderViewModel()
        {
            AllOrders = _db.Orders
                .Include(u => u.UidNavigation)
                .Include(order => order.OrderDetails)
                .OrderByDescending(order => order.Date)
                .ToList(),
            PendingOrders = _db.Orders
                .Include(u => u.UidNavigation)
                .Include(order => order.OrderDetails)
                .Where(order => order.Status == 1)
                .OrderByDescending(order => order.Date)
                .ToList(),
            ConfirmedOrders = _db.Orders
                .Include(u => u.UidNavigation)
                .Include(order => order.OrderDetails)
                .Where(order => order.Status == 2)
                .OrderByDescending(order => order.Date)
                .ToList(),
            CompletedOrders = _db.Orders
                .Include(u => u.UidNavigation)
                .Include(order => order.OrderDetails)
                .Where(order => order.Status == 3)
                .OrderByDescending(order => order.Date)
                .ToList(),
            CancelledOrders = _db.Orders
                .Include(u => u.UidNavigation)
                .Include(order => order.OrderDetails)
                .Where(order => order.Status == 4)
                .OrderByDescending(order => order.Date)
                .ToList()
        };
        return View(model);
    }

    [Route("Admin/Order/UpdateStatus/{orderId:int}/{status:int}")]
    public IActionResult UpdateStatus(int orderId, int status)
    {
        var order = _db.Orders.Find((uint)orderId);
        if (order == null)
        {
            _notyf.Error("Order not found!");
            return RedirectToAction("Index");
        }

        order.Status = (uint)status;
        _db.Orders.Update(order);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
}