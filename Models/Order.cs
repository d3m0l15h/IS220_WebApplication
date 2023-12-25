using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IS220_WebApplication.Models;

[Table("order")]
[Index("Address", Name = "FK_Address_Address")]
[Index("PaymentMethod", Name = "FK_PaymentMethod_PaymentMethod")]
[Index("Status", Name = "FK_Status_OrderStatus")]
[Index("Uid", Name = "FK_User_Trans")]
public partial class Order
{
    [Key]
    [Column("id", TypeName = "int(10) unsigned")]
    public uint Id { get; set; }

    [Column("date", TypeName = "timestamp")]
    public DateTime Date { get; set; }

    [Column("uid", TypeName = "int(10) unsigned")]
    public uint Uid { get; set; }

    [Column("status", TypeName = "int(10) unsigned")]
    public uint Status { get; set; }

    [Column("paymentMethod", TypeName = "int(10) unsigned")]
    public uint PaymentMethod { get; set; }

    [Column("address", TypeName = "int(10) unsigned")]
    public uint Address { get; set; }

    [ForeignKey("Address")]
    [InverseProperty("Orders")]
    public virtual Address AddressNavigation { get; set; } = null!;

    [InverseProperty("Order")]
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    [ForeignKey("PaymentMethod")]
    [InverseProperty("Orders")]
    public virtual Paymentmethod PaymentMethodNavigation { get; set; } = null!;

    [ForeignKey("Status")]
    [InverseProperty("Orders")]
    public virtual OrderStatus StatusNavigation { get; set; } = null!;

    [ForeignKey("Uid")]
    [InverseProperty("Orders")]
    public virtual Aspnetuser UidNavigation { get; set; } = null!;


}
