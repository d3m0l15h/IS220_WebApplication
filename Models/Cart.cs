using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IS220_WebApplication.Models;

[PrimaryKey("Id", "Uid", "GameId")]
[Table("carts")]
[Index("Uid", Name = "FK_ASPNETUSERS-UID")]
[Index("GameId", Name = "FK_GAME-ID")]
public partial class Cart
{
    [Key]
    [Column("ID", TypeName = "int(11)")]
    public int Id { get; set; }

    [Key]
    [Column("UID", TypeName = "int(10) unsigned")]
    public uint Uid { get; set; }

    [Key]
    [Column("GAME_ID", TypeName = "int(10) unsigned")]
    public uint GameId { get; set; }

    [Column("QUANTITY", TypeName = "int(10) unsigned")]
    public uint? Quantity { get; set; }

    [Column("TYPE", TypeName = "int(10) unsigned")]
    public uint Type { get; set; }

    [Column("CREATED", TypeName = "timestamp")]
    public DateTime Created { get; set; }

    [Column("MODIFIED", TypeName = "timestamp")]
    public DateTime Modified { get; set; }

    [ForeignKey("GameId")]
    [InverseProperty("Carts")]
    public virtual Game Game { get; set; } = null!;

    [ForeignKey("Uid")]
    [InverseProperty("Carts")]
    public virtual Aspnetuser UidNavigation { get; set; } = null!;
}
