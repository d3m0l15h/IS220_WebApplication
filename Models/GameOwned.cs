using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IS220_WebApplication.Models;

[Keyless]
[Table("game_owned")]
[Index("GameId", Name = "FK_GameOwner_Game")]
[Index("UserId", Name = "FK_GameOwner_User")]
public partial class GameOwned
{
    [Column("userID", TypeName = "int(10) unsigned")]
    public uint UserId { get; set; }

    [Column("gameID", TypeName = "int(10) unsigned")]
    public uint GameId { get; set; }

    [ForeignKey("GameId")]
    public virtual Game Game { get; set; } = null!;

    [ForeignKey("UserId")]
    public virtual Aspnetuser User { get; set; } = null!;
}
