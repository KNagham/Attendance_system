using System;
using System.Collections.Generic;

namespace Attendance_system.Model;

public partial class Task
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public bool? IsDone { get; set; }

    public bool? IsActive { get; set; }

    public string? Name { get; set; }

    public string? Priority { get; set; }

    public virtual ICollection<EmployeeProject> EmployeeProjects { get; set; } = new List<EmployeeProject>();

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
