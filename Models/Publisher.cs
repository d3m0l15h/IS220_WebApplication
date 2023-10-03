using System;
using System.Collections.Generic;

namespace IS220_WebApplication.Models;

public partial class Publisher
{
    public uint Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Game> Games { get; set; } = new List<Game>();
}
