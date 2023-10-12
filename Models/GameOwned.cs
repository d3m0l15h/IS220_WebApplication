using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IS220_WebApplication.Models;

[Keyless]
[Table("game_owned")]
[Index("GameId", Name = "FK_GameOwner_Game")]
[Index("UserEmail", Name = "FK_GameOwner_User")]
public partial class GameOwned
{
    [Column("userEmail")]
    [StringLength(100)]
    public string UserEmail { get; set; } = null!;

    [Column("gameID", TypeName = "int(10) unsigned")]
    public uint GameId { get; set; }

    [ForeignKey("GameId")]
    public virtual Game Game { get; set; } = null!;

    [ForeignKey("UserEmail")]
    public virtual User UserEmailNavigation { get; set; } = null!;
}
