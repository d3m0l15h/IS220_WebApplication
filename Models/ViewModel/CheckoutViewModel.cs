using System.ComponentModel.DataAnnotations;
using IS220_WebApplication.Models;
using IS220_WebApplication.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IS220_WebApplication.Models.ViewModel;
public class CheckoutItems
{
    public uint GameId { get; set; }
    public int CartId { get; set; }
    public string Title { get; set; }
    public uint? Quantity { get; set; }
    public decimal Price { get; set; }
    public uint? Type { get; set; }
    public string Image { get; set; }
}
public class CheckoutViewModel
{
    public List<CheckoutItems> CheckoutItems { get; set; }
    public int TotalCount { get; set; }
    public Address SelectedAddress { get; set; }

    public string? PaymentMethod { get; set; }
}