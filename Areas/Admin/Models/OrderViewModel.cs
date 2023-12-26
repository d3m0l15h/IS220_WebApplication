using IS220_WebApplication.Database;
using Order = IS220_WebApplication.Models.Order;

namespace IS220_WebApplication.Areas.Admin.Models;

public class OrderViewModel
{
    public IEnumerable<Order>? AllOrders { get; set; }
    public IEnumerable<Order>? PendingOrders { get; set; }
    public IEnumerable<Order>? ConfirmedOrders { get; set; }
    public IEnumerable<Order>? CompletedOrders { get; set; }
    public IEnumerable<Order>? CancelledOrders { get; set; }
}