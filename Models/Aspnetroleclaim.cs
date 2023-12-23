using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IS220_WebApplication.Models;

[Table("aspnetroleclaims")]
[Index("Roleid", Name = "IX_ASPNETROLECLAIMS_ROLEID")]
public partial class Aspnetroleclaim
{
    [Key]
    [Column("ID", TypeName = "int(11)")]
    public int Id { get; set; }

    [Column("ROLEID", TypeName = "int(10) unsigned")]
    public uint Roleid { get; set; }

    [Column("CLAIMTYPE")]
    public string? Claimtype { get; set; }

    [Column("CLAIMVALUE")]
    public string? Claimvalue { get; set; }

    [ForeignKey("Roleid")]
    [InverseProperty("Aspnetroleclaims")]
    public virtual Aspnetrole Role { get; set; } = null!;
}
