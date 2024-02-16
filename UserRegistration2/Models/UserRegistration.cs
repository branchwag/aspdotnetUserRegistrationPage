using System;
using System.Collections.Generic;

namespace UserRegistration2.Models;

public partial class UserRegistration
{
    public int UserId { get; set; }

    public string? FullName { get; set; }

    public string? EmailAddress { get; set; }

    public string? Password { get; set; }

    public string? RepeatedPassword { get; set; }
}
