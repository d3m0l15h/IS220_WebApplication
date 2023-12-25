using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IS220_WebApplication.Models;

[Table("game")]
[Index("Developer", Name = "FK_Game_Developer")]
[Index("Publisher", Name = "FK_Game_Publisher")]
public partial class Game
{
    [Key]
    [Column("id", TypeName = "int(10) unsigned")]
    public uint Id { get; set; }

    [Column("title")]
    [StringLength(100)]
    public string Title { get; set; } = null!;

    [Column("price")]
    [Precision(10, 0)]
    public decimal Price { get; set; }

    [Column("releaseDate")]
    public DateOnly ReleaseDate { get; set; }

    [Column("description", TypeName = "text")]
    public string? Description { get; set; }

    [Column("publisher", TypeName = "int(10) unsigned")]
    public uint Publisher { get; set; }

    [Column("developer", TypeName = "int(10) unsigned")]
    public uint Developer { get; set; }

    [Column("imgPath", TypeName = "tinytext")]
    public string? ImgPath { get; set; }

    [Column("downloadLink", TypeName = "tinytext")]
    public string DownloadLink { get; set; } = null!;

    [Column("status")]
    [StringLength(10)]
    public string Status { get; set; } = null!;

    [Column("type", TypeName = "int(1) unsigned")]
    public uint Type { get; set; }

    [Column("stock", TypeName = "int(11)")]
    public int Stock { get; set; }

    [InverseProperty("Game")]
    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    [ForeignKey("Developer")]
    [InverseProperty("Games")]
    public virtual Developer DeveloperNavigation { get; set; } = null!;

    [ForeignKey("Publisher")]
    [InverseProperty("Games")]
    public virtual Publisher PublisherNavigation { get; set; } = null!;

    [ForeignKey("GameId")]
    [InverseProperty("Games")]
    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();

    [ForeignKey("GameId")]
    [InverseProperty("Games")]
    public virtual ICollection<Aspnetuser> Users { get; set; } = new List<Aspnetuser>();
}
