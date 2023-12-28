using IS220_WebApplication.Models;

namespace IS220_WebApplication.Areas.Admin.Models;

public class DashboardViewModel
{
    public IEnumerable<Aspnetuser> User;
    public IEnumerable<Game> Game;
    public IEnumerable<Order> Order;
    
}