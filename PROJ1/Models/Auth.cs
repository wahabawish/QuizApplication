using System;
using System.Collections.Generic;

namespace PROJ1.Models;

public partial class Auth
{
    public int Id { get; set; }

    public string? Usernameis { get; set; }

    public string? Passwordis { get; set; }

    public string? Emailis { get; set; }
}
