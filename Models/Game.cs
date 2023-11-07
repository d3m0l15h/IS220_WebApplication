using System;
using System.Collections.Generic;

namespace IS220_WebApplication.Models;

public partial class Game
{
    public uint Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public DateTime ReleaseDate { get; set; }

    public string? ImgPath { get; set; }

    public uint PublisherId { get; set; }

    public uint DeveloperId { get; set; }

    public string DownloadLink { get; set; } = null!;

    public virtual Developer Developer { get; set; } = null!;

    public virtual Publisher Publisher { get; set; } = null!;
}
