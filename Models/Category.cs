using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IS220_WebApplication.Models;

[Table("category")]
public partial class Category
{
    [Key]
    [Column("id")]
    public uint Id { get; set; }

    [Column("name")]
    [StringLength(30)]
    public string Name { get; set; } = null!;
}
