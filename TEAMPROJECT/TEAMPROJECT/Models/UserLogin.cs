using System;
using System.Collections.Generic;

namespace TEAMPROJECT.Models;

public partial class UserLogin
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string? Password { get; set; }
}
