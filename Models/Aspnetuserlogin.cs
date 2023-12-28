using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IS220_WebApplication.Models;

[PrimaryKey("LoginProvider", "ProviderKey")]
[Table("aspnetuserlogins")]
[Index("UserId", Name = "IX_AspNetUserLogins_UserId")]
public partial class Aspnetuserlogin
{
    [Key]
    [StringLength(128)]
    public string LoginProvider { get; set; } = null!;

    [Key]
    [StringLength(128)]
    public string ProviderKey { get; set; } = null!;

    public string? ProviderDisplayName { get; set; }

    [Column(TypeName = "int(10) unsigned")]
    public uint UserId { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Aspnetuserlogins")]
    public virtual Aspnetuser User { get; set; } = null!;
}
