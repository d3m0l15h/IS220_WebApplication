using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IS220_WebApplication.Models;

[Table("publisher")]
public partial class Publisher
{
    [Key]
    [Column("ID", TypeName = "int(10) unsigned")]
    public uint Id { get; set; }

    [Column("NAME")]
    [StringLength(50)]
    public string Name { get; set; } = null!;

    [InverseProperty("PublisherNavigation")]
    public virtual ICollection<Game> Games { get; set; } = new List<Game>();
}
