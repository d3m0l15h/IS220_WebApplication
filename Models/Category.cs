using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IS220_WebApplication.Models;

[Table("category")]
[Index("Name", Name = "NAME", IsUnique = true)]
public partial class Category
{
    [Key]
    [Column("ID", TypeName = "int(10) unsigned")]
    public uint Id { get; set; }

    [Column("NAME")]
    [StringLength(30)]
    public string Name { get; set; } = null!;

    [ForeignKey("CategoryId")]
    [InverseProperty("Categories")]
    public virtual ICollection<Game> Games { get; set; } = new List<Game>();
}
