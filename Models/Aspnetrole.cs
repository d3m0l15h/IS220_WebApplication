using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IS220_WebApplication.Models;

[Table("aspnetroles")]
[Index("NormalizedName", Name = "RoleNameIndex", IsUnique = true)]
public partial class Aspnetrole
{
    [Key]
    [Column(TypeName = "int(10) unsigned")]
    public uint Id { get; set; }

    [StringLength(256)]
    public string? Name { get; set; }

    [StringLength(256)]
    public string? NormalizedName { get; set; }

    public string? ConcurrencyStamp { get; set; }

    [InverseProperty("Role")]
    public virtual ICollection<Aspnetroleclaim> Aspnetroleclaims { get; set; } = new List<Aspnetroleclaim>();

    [ForeignKey("RoleId")]
    [InverseProperty("Roles")]
    public virtual ICollection<Aspnetuser> Users { get; set; } = new List<Aspnetuser>();
}
