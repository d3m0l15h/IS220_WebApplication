using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IS220_WebApplication.Models;

[Table("aspnetuserclaims")]
[Index("Userid", Name = "IX_ASPNETUSERCLAIMS_USERID")]
public partial class Aspnetuserclaim
{
    [Key]
    [Column("ID", TypeName = "int(11)")]
    public int Id { get; set; }

    [Column("USERID", TypeName = "int(10) unsigned")]
    public uint Userid { get; set; }

    [Column("CLAIMTYPE")]
    public string? Claimtype { get; set; }

    [Column("CLAIMVALUE")]
    public string? Claimvalue { get; set; }

    [ForeignKey("Userid")]
    [InverseProperty("Aspnetuserclaims")]
    public virtual Aspnetuser User { get; set; } = null!;
}
