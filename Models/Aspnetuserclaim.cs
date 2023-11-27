using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IS220_WebApplication.Models;

[Table("aspnetuserclaims")]
[Index("UserId", Name = "IX_AspNetUserClaims_UserId")]
public partial class Aspnetuserclaim
{
    [Key]
    [Column(TypeName = "int(11)")]
    public int Id { get; set; }

    [Column(TypeName = "int(10) unsigned")]
    public uint UserId { get; set; }

    public string? ClaimType { get; set; }

    public string? ClaimValue { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Aspnetuserclaims")]
    public virtual Aspnetuser User { get; set; } = null!;
}
