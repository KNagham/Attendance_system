using System;
using System.Collections.Generic;

namespace Attendance_system.Model;

public partial class EmployeeProject
{
    public int Id { get; set; }

    public int? EmployeeId { get; set; }

    public int? ProjectId { get; set; }

    public int? TaskId { get; set; }

    public string? Note { get; set; }

    public double? WorkingTime { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual Project? Project { get; set; }

    public virtual Task? Task { get; set; }
}
