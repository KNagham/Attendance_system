using System;
using System.Collections.Generic;

namespace Attendance_system.Model;

public partial class Projekt
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDeleted { get; set; }

    public int? TaskId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public bool? IsDone { get; set; }

    public virtual ICollection<EmployeeProjekt> EmployeeProjekts { get; set; } = new List<EmployeeProjekt>();

    public virtual Task? Task { get; set; }
}
