using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IS220_WebApplication.Models;

[Table("order")]
[Index("DetailId", Name = "FK_Info_Trans")]
[Index("UserId", Name = "FK_User_Trans")]
public partial class Order
{
    [Key]
    [Column("id", TypeName = "int(10) unsigned")]
    public uint Id { get; set; }

    [Column("detailID", TypeName = "int(11) unsigned")]
    public uint DetailId { get; set; }

    [Column("date", TypeName = "timestamp")]
    public DateTime Date { get; set; }

    [Column("userID", TypeName = "int(10) unsigned")]
    public uint UserId { get; set; }

    [Column("status")]
    [StringLength(15)]
    public string Status { get; set; } = null!;

    [ForeignKey("DetailId")]
    [InverseProperty("Orders")]
    public virtual OrderDetail Detail { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("Orders")]
    public virtual Aspnetuser User { get; set; } = null!;
}
