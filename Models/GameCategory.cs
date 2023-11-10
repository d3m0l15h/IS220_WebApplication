﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IS220_WebApplication.Models;

[Keyless]
[Table("game_category")]
[Index("Category", Name = "FK_GC_Category")]
[Index("Game", Name = "FK_GC_Game")]
public sealed partial class GameCategory
{
    [Column("game", TypeName = "int(10) unsigned")]
    public uint Game { get; set; }

    [Column("category", TypeName = "int(10) unsigned")]
    public uint Category { get; set; }

    [ForeignKey("Category")]
    public Category CategoryNavigation { get; set; } = null!;

    [ForeignKey("Game")]
    public Game GameNavigation { get; set; } = null!;
}
