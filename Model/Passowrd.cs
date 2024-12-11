using System;
using System.Collections.Generic;

namespace Attendance_system.Model;

public partial class Passowrd
{
    public int Id { get; set; }

    public string? PasswordKey { get; set; }

    public virtual Employee IdNavigation { get; set; } = null!;
}
