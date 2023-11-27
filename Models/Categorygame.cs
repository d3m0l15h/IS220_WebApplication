using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IS220_WebApplication.Models;

[PrimaryKey("CategoryId", "GameId")]
[Table("categorygame")]
public partial class Categorygame
{
    [Key]
    [Column(TypeName = "int(10) unsigned")]
    public uint CategoryId { get; set; }

    [Key]
    [Column(TypeName = "int(10) unsigned")]
    public uint GameId { get; set; }
}
