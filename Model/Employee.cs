using System;
using System.Collections.Generic;

namespace Attendance_system.Model;

public partial class Employee
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? UserName { get; set; }

    public string? Email { get; set; }

    public bool? Confirmed { get; set; }

    public string? ActivationCode { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Password? Password { get; set; }
}
