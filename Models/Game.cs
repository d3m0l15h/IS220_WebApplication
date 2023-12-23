using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IS220_WebApplication.Models;

[Table("game")]
[Index("Developer", Name = "FK_GAME_DEVELOPER")]
[Index("Publisher", Name = "FK_GAME_PUBLISHER")]
public partial class Game
{
    [Key]
    [Column("ID", TypeName = "int(10) unsigned")]
    public uint Id { get; set; }

    [Column("TITLE")]
    [StringLength(100)]
    public string Title { get; set; } = null!;

    [Column("PRICE", TypeName = "double(10,2) unsigned")]
    public decimal Price { get; set; }

    [Column("RELEASEDATE")]
    public DateOnly Releasedate { get; set; }

    [Column("DESCRIPTION", TypeName = "text")]
    public string? Description { get; set; }

    [Column("PUBLISHER", TypeName = "int(10) unsigned")]
    public uint Publisher { get; set; }

    [Column("DEVELOPER", TypeName = "int(10) unsigned")]
    public uint Developer { get; set; }

    [Column("IMGPATH", TypeName = "tinytext")]
    public string? Imgpath { get; set; }

    [Column("DOWNLOADLINK", TypeName = "tinytext")]
    public string Downloadlink { get; set; } = null!;

    [Column("STATUS")]
    [StringLength(10)]
    public string Status { get; set; } = null!;

    [Column("TYPE", TypeName = "int(1) unsigned")]
    public uint Type { get; set; }

    [Column("STOCK", TypeName = "int(11)")]
    public int Stock { get; set; }

    [InverseProperty("Game")]
    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    [ForeignKey("Developer")]
    [InverseProperty("Games")]
    public virtual Developer DeveloperNavigation { get; set; } = null!;

    [InverseProperty("Game")]
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    [ForeignKey("Publisher")]
    [InverseProperty("Games")]
    public virtual Publisher PublisherNavigation { get; set; } = null!;

    [ForeignKey("GameId")]
    [InverseProperty("Games")]
    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();

    [ForeignKey("Gameid")]
    [InverseProperty("Games")]
    public virtual ICollection<Aspnetuser> Users { get; set; } = new List<Aspnetuser>();
}
