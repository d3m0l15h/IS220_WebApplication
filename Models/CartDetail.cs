using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IS220_WebApplication.Models;


public class CartDetail
{
    public uint GameId { get; set; }
    public string GameTitle { get; set; } = null!;
    public string? GameImg { get; set; }
    public decimal GamePrice { get; set; }
    public uint? GameType { get; set; }
    public string? GameTypeStr { get; set; }
    public uint? Quantity { get; set; }
    public DateTime UpdatedAt { get; set; }
}