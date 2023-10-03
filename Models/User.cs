using System;
using System.Collections.Generic;

namespace IS220_WebApplication.Models;

public partial class User
{
    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Phone { get; set; }

    public DateTime? Birth { get; set; }

    public sbyte Role { get; set; }

    public DateTime Created { get; set; }

    public DateTime? Modified { get; set; }
}
