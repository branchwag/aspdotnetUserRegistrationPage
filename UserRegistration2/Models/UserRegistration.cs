using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UserRegistration2.Models;

public partial class UserRegistration
{
    public int UserId { get; set; }

    [Required]
    [DisplayName("name")]
    public string? FullName { get; set; }

    [Required]
    [DisplayName("email address")]
    public string? EmailAddress { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [DisplayName("password")]
    public string? Password { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [DisplayName("repeated password")]
    public string? RepeatedPassword { get; set; }
}
