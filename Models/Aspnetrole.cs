using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IS220_WebApplication.Models;

[Table("aspnetroles")]
[Index("Normalizedname", Name = "ROLENAMEINDEX", IsUnique = true)]
public partial class Aspnetrole
{
    [Key]
    [Column("ID", TypeName = "int(10) unsigned")]
    public uint Id { get; set; }

    [Column("NAME")]
    [StringLength(256)]
    public string? Name { get; set; }

    [Column("NORMALIZEDNAME")]
    [StringLength(256)]
    public string? Normalizedname { get; set; }

    [Column("CONCURRENCYSTAMP")]
    public string? Concurrencystamp { get; set; }

    [InverseProperty("Role")]
    public virtual ICollection<Aspnetroleclaim> Aspnetroleclaims { get; set; } = new List<Aspnetroleclaim>();

    [ForeignKey("Roleid")]
    [InverseProperty("Roles")]
    public virtual ICollection<Aspnetuser> Users { get; set; } = new List<Aspnetuser>();
}
