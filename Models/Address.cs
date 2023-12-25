using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IS220_WebApplication.Models;

[Table("address")]
[Index("UserId", Name = "FK_Add_User")]
public partial class Address
{
    [Key]
    [Column("id", TypeName = "int(10) unsigned")]
    public uint Id { get; set; }

    [Column("userID", TypeName = "int(10) unsigned")]
    public uint UserId { get; set; }

    [Column("street")]
    [StringLength(255)]
    public string Street { get; set; } = null!;

    [Column("ward")]
    [StringLength(255)]
    public string Ward { get; set; } = null!;

    [Column("city")]
    [StringLength(255)]
    public string City { get; set; } = null!;

    [Column("state")]
    [StringLength(255)]
    public string State { get; set; } = null!;

    [Column("isDefault")]
    public bool IsDefault { get; set; }

    [Column("phone")]
    [StringLength(255)]
    public string Phone { get; set; } = null!;

    [Column("receiver")]
    [StringLength(255)]
    public string Receiver { get; set; } = null!;

    [Column("created_at", TypeName = "timestamp")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at", TypeName = "timestamp")]
    public DateTime? UpdatedAt { get; set; }

    [InverseProperty("AddressNavigation")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    [ForeignKey("UserId")]
    [InverseProperty("Addresses")]
    public virtual Aspnetuser User { get; set; } = null!;
}
