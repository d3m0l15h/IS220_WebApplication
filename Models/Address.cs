using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IS220_WebApplication.Models;

[Table("address")]
[Index("Userid", Name = "FK_ADD_USER")]
public partial class Address
{
    [Key]
    [Column("ID", TypeName = "int(10) unsigned")]
    public uint Id { get; set; }

    [Column("USERID", TypeName = "int(10) unsigned")]
    public uint Userid { get; set; }

    [Column("STREET")]
    [StringLength(255)]
    public string Street { get; set; } = null!;

    [Column("WARD")]
    [StringLength(255)]
    public string Ward { get; set; } = null!;

    [Column("CITY")]
    [StringLength(255)]
    public string City { get; set; } = null!;

    [Column("STATE")]
    [StringLength(255)]
    public string State { get; set; } = null!;

    [Column("ISDEFAULT")]
    public bool Isdefault { get; set; }

    [Column("PHONE")]
    [StringLength(255)]
    public string Phone { get; set; } = null!;

    [Column("RECEIVER")]
    [StringLength(255)]
    public string Receiver { get; set; } = null!;

    [Column("CREATED_AT", TypeName = "timestamp")]
    public DateTime CreatedAt { get; set; }

    [Column("UPDATED_AT", TypeName = "timestamp")]
    public DateTime? UpdatedAt { get; set; }

    [ForeignKey("Userid")]
    [InverseProperty("Addresses")]
    public virtual Aspnetuser User { get; set; } = null!;

    [InverseProperty("Address")]
    public virtual ICollection<UserOrder> UserOrders { get; set; } = new List<UserOrder>();
}
