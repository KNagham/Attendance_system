using System;
using System.Collections.Generic;

namespace Attendance_system.Model;

public partial class EmployeeProjekt
{
    public int Id { get; set; }

    public int? EmployeeId { get; set; }

    public int? ProjektId { get; set; }

    public int? TaskId { get; set; }

    public string? Note { get; set; }

    public double? WorkingTime { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual Projekt? Projekt { get; set; }

    public virtual Task? Task { get; set; }
}
