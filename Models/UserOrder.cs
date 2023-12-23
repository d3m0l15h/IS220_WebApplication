using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IS220_WebApplication.Models;

[Table("user_order")]
[Index("AddressId", Name = "FK_ADDRESS_ORD")]
[Index("Userid", Name = "FK_USER_TRANS")]
public partial class UserOrder
{
    [Key]
    [Column("ID", TypeName = "int(10) unsigned")]
    public uint Id { get; set; }

    [Column("USERID", TypeName = "int(10) unsigned")]
    public uint Userid { get; set; }

    [Column("addressID", TypeName = "int(10) unsigned")]
    public uint AddressId { get; set; }

    [Column("paymentMethod")]
    [StringLength(50)]
    public string PaymentMethod { get; set; } = null!;

    [Column("STATUS")]
    [StringLength(15)]
    public string Status { get; set; } = null!;

    [Column("created_at", TypeName = "timestamp")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at", TypeName = "timestamp")]
    public DateTime? UpdatedAt { get; set; }

    [Column("total", TypeName = "double(10,2) unsigned")]
    public double Total { get; set; }

    [ForeignKey("AddressId")]
    [InverseProperty("UserOrders")]
    public virtual Address Address { get; set; } = null!;

    [InverseProperty("Order")]
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    [ForeignKey("Userid")]
    [InverseProperty("UserOrders")]
    public virtual Aspnetuser User { get; set; } = null!;
}
