using System;
using System.Collections.Generic;

namespace IS220_WebApplication.Models;

public partial class GameOwned
{
    public string UserEmail { get; set; } = null!;

    public uint GameId { get; set; }

    public virtual Game Game { get; set; } = null!;

    public virtual User UserEmailNavigation { get; set; } = null!;
}
