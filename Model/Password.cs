using System;
using System.Collections.Generic;

namespace Attendance_system.Model;

public partial class Password
{
    public int Id { get; set; }

    public string? PasswordKey { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? ResetCode { get; set; }

    public virtual Employee IdNavigation { get; set; } = null!;
}
