using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IS220_WebApplication.Models;

[PrimaryKey("Userid", "Loginprovider", "Name")]
[Table("aspnetusertokens")]
public partial class Aspnetusertoken
{
    [Key]
    [Column("USERID", TypeName = "int(10) unsigned")]
    public uint Userid { get; set; }

    [Key]
    [Column("LOGINPROVIDER")]
    [StringLength(128)]
    public string Loginprovider { get; set; } = null!;

    [Key]
    [Column("NAME")]
    [StringLength(128)]
    public string Name { get; set; } = null!;

    [Column("VALUE")]
    public string? Value { get; set; }

    [ForeignKey("Userid")]
    [InverseProperty("Aspnetusertokens")]
    public virtual Aspnetuser User { get; set; } = null!;
}
