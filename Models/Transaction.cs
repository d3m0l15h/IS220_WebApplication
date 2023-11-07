using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IS220_WebApplication.Models;

[Table("transaction")]
[Index("Email", Name = "FK_TRANSACTION_USER")]
public partial class Transaction
{
    [Key]
    [Column("id", TypeName = "int(10) unsigned")]
    public uint Id { get; set; }

    [Column("email")]
    [StringLength(100)]
    public string Email { get; set; } = null!;

    [Column("type", TypeName = "int(2)")]
    public int Type { get; set; }

    [Column("amount", TypeName = "int(10)")]
    public int Amount { get; set; }

    [Column("date", TypeName = "timestamp")]
    public DateTime Date { get; set; }

    [ForeignKey("Email")]
    [InverseProperty("Transactions")]
    public virtual User EmailNavigation { get; set; } = null!;
}
