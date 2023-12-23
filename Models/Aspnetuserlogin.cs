using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IS220_WebApplication.Models;

[PrimaryKey("Loginprovider", "Providerkey")]
[Table("aspnetuserlogins")]
[Index("Userid", Name = "IX_ASPNETUSERLOGINS_USERID")]
public partial class Aspnetuserlogin
{
    [Key]
    [Column("LOGINPROVIDER")]
    [StringLength(128)]
    public string Loginprovider { get; set; } = null!;

    [Key]
    [Column("PROVIDERKEY")]
    [StringLength(128)]
    public string Providerkey { get; set; } = null!;

    [Column("PROVIDERDISPLAYNAME")]
    public string? Providerdisplayname { get; set; }

    [Column("USERID", TypeName = "int(10) unsigned")]
    public uint Userid { get; set; }

    [ForeignKey("Userid")]
    [InverseProperty("Aspnetuserlogins")]
    public virtual Aspnetuser User { get; set; } = null!;
}
