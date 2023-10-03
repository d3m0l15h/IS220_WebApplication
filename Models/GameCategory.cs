using System;
using System.Collections.Generic;

namespace IS220_WebApplication.Models;

public partial class GameCategory
{
    public uint CategoryId { get; set; }

    public uint GameId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual Game Game { get; set; } = null!;
}
