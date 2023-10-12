using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IS220_WebApplication.Models;

[Table("user")]
[Index("Username", Name = "username", IsUnique = true)]
public partial class User
{
    [Column("username")]
    [StringLength(50)]
    public string Username { get; set; } = null!;

    [Column("password", TypeName = "text")]
    public string Password { get; set; } = null!;

    [Key]
    [Column("email")]
    [StringLength(100)]
    public string Email { get; set; } = null!;

    [Column("firstName")]
    [StringLength(50)]
    public string? FirstName { get; set; }

    [Column("lastName")]
    [StringLength(50)]
    public string? LastName { get; set; }

    [Column("phone")]
    [StringLength(20)]
    public string? Phone { get; set; }

    [Column("birth", TypeName = "date")]
    public DateTime? Birth { get; set; }

    [Column("role", TypeName = "tinyint(4)")]
    public sbyte Role { get; set; }

    [Column("created", TypeName = "datetime")]
    public DateTime Created { get; set; }

    [Column("modified", TypeName = "datetime")]
    public DateTime? Modified { get; set; }

    [Column("cash", TypeName = "int(11)")]
    public int Cash { get; set; }

    [InverseProperty("EmailNavigation")]
    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
