using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IS220_WebApplication.Models;

[PrimaryKey("Id", "Uid", "GameId")]
[Table("carts")]
[Index("GameId", Name = "FK_GAME-ID")]
[Index("Uid", Name = "FK_aspnetusers-UID")]
public partial class Cart
{
    [Key]
    [Column("id", TypeName = "int(11)")]
    public int Id { get; set; }

    [Key]
    [Column("uid", TypeName = "int(10) unsigned")]
    public uint Uid { get; set; }

    [Key]
    [Column("game_id", TypeName = "int(10) unsigned")]
    public uint GameId { get; set; }

    [Column("quantity", TypeName = "int(10) unsigned")]
    public uint? Quantity { get; set; }

    [Column("created_at", TypeName = "timestamp")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at", TypeName = "timestamp")]
    public DateTime UpdatedAt { get; set; }

    [ForeignKey("GameId")]
    [InverseProperty("Carts")]
    public virtual Game Game { get; set; } = null!;

    [ForeignKey("Uid")]
    [InverseProperty("Carts")]
    public virtual Aspnetuser UidNavigation { get; set; } = null!;
}
