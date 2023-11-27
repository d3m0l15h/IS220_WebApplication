using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IS220_WebApplication.Models;

[Table("aspnetroleclaims")]
[Index("RoleId", Name = "IX_AspNetRoleClaims_RoleId")]
public partial class Aspnetroleclaim
{
    [Key]
    [Column(TypeName = "int(11)")]
    public int Id { get; set; }

    [Column(TypeName = "int(10) unsigned")]
    public uint RoleId { get; set; }

    public string? ClaimType { get; set; }

    public string? ClaimValue { get; set; }

    [ForeignKey("RoleId")]
    [InverseProperty("Aspnetroleclaims")]
    public virtual Aspnetrole Role { get; set; } = null!;
}
