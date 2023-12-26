using System.ComponentModel.DataAnnotations;
using IS220_WebApplication.Models;
using IS220_WebApplication.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IS220_WebApplication.Models.ViewModel;

public class OrderDetailViewModel
{
    public Order Order { get; set; } = null!;
    public IEnumerable<OrderDetail> OrderDetails { get; set; } = null!;


}