using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IS220_WebApplication.Models;

[Table("order_detail")]
[Index("GameId", Name = "FK_ord_det_Game")]
[Index("OrderId", Name = "FK_ord_det_Order")]
public partial class OrderDetail
{
    [Key]
    [Column("id", TypeName = "int(10) unsigned")]
    public uint Id { get; set; }

    [Column("orderID", TypeName = "int(10) unsigned")]
    public uint OrderId { get; set; }

    [Column("gameID", TypeName = "int(10) unsigned")]
    public uint GameId { get; set; }

    [Column("quantity", TypeName = "int(10) unsigned")]
    public uint? Quantity { get; set; }

    [Column("type")]
    [StringLength(50)]
    public string Type { get; set; } = null!;

    [Column("created", TypeName = "int(11)")]
    public int Created { get; set; }

    [Column("modified", TypeName = "timestamp")]
    public DateTime? Modified { get; set; }

    [ForeignKey("GameId")]
    [InverseProperty("OrderDetails")]
    public virtual Game Game { get; set; } = null!;

    [ForeignKey("OrderId")]
    [InverseProperty("OrderDetails")]
    public virtual UserOrder Order { get; set; } = null!;
}
