using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IS220_WebApplication.Models;

[Table("developer")]
public partial class Developer
{
    [Key]
    [Column("id")]
    public uint Id { get; set; }

    [Column("name")]
    [StringLength(50)]
    public string Name { get; set; } = null!;

    [InverseProperty("DeveloperNavigation")]
    public virtual ICollection<Game> Games { get; set; } = new List<Game>();
}
