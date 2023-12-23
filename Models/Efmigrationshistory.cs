using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IS220_WebApplication.Models;

[Table("__efmigrationshistory")]
public partial class Efmigrationshistory
{
    [Key]
    [Column("MIGRATIONID")]
    [StringLength(150)]
    public string Migrationid { get; set; } = null!;

    [Column("PRODUCTVERSION")]
    [StringLength(32)]
    public string Productversion { get; set; } = null!;
}
