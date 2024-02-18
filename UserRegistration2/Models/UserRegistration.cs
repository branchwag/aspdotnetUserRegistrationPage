using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UserRegistration2.Models;

public partial class UserRegistration
{
    public int UserId { get; set; }

    [Required]
    public string? FullName { get; set; }

    [Required]
    public string? EmailAddress { get; set; }

    [Required]
    public string? Password { get; set; }

    [Required]
    public string? RepeatedPassword { get; set; }
}
