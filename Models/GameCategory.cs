using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IS220_WebApplication.Models;

[Keyless]
[Table("game_category")]
[Index("CategoryId", Name = "FK_GameCategory_Category")]
[Index("GameId", Name = "FK_GameCategory_Game")]
public partial class GameCategory
{
    [Column("categoryID", TypeName = "int(10) unsigned")]
    public uint CategoryId { get; set; }

    [Column("gameID", TypeName = "int(10) unsigned")]
    public uint GameId { get; set; }

    [ForeignKey("CategoryId")]
    public virtual Category Category { get; set; } = null!;

    [ForeignKey("GameId")]
    public virtual Game Game { get; set; } = null!;
}
