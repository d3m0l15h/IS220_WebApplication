using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IS220_WebApplication.Models;

[Table("order_detail")]
[Index("GameId", Name = "FK_Game_Trans")]
[Index("TypeId", Name = "Fk_Type_Trans")]
public partial class OrderDetail
{
    [Key]
    [Column("id", TypeName = "int(11) unsigned")]
    public uint Id { get; set; }

    [Column("typeID", TypeName = "int(11) unsigned")]
    public uint TypeId { get; set; }

    [Column("amount", TypeName = "int(11)")]
    public int Amount { get; set; }

    [Column("gameID", TypeName = "int(11) unsigned")]
    public uint? GameId { get; set; }

    [ForeignKey("GameId")]
    [InverseProperty("OrderDetails")]
    public virtual Game? Game { get; set; }

    [InverseProperty("Detail")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    [ForeignKey("TypeId")]
    [InverseProperty("OrderDetails")]
    public virtual OrderType Type { get; set; } = null!;
}
