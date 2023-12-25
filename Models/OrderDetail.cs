using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IS220_WebApplication.Models;

[Table("order_detail")]
[Index("GameId", Name = "FK_Game_Trans")]
[Index("OrderId", Name = "FK_OrderId_Order")]
public partial class OrderDetail
{
    [Key]
    [Column("id", TypeName = "int(11) unsigned")]
    public uint Id { get; set; }

    [Column("price", TypeName = "int(11)")]
    public int Price { get; set; }

    [Column("gameId", TypeName = "int(11) unsigned")]
    public uint? GameId { get; set; }

    [Column("gameType", TypeName = "int(10) unsigned")]
    public uint? GameType { get; set; }

    [Column("quantity", TypeName = "int(10) unsigned")]
    public uint? Quantity { get; set; }

    [Column("orderId", TypeName = "int(10) unsigned")]
    public uint OrderId { get; set; }

    [ForeignKey("OrderId")]
    [InverseProperty("OrderDetails")]
    public virtual Order Order { get; set; } = null!;
    public Game Game { get; set; } = null!;
}
