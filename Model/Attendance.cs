using System;
using System.Collections.Generic;

namespace Attendance_system.Model;

public partial class Attendance
{
    public int Id { get; set; }

    public int? EmployeeId { get; set; }

    public string? Note { get; set; }

    public DateTime? Start { get; set; }

    public DateTime? Ende { get; set; }

    public virtual Employee? Employee { get; set; }
}
