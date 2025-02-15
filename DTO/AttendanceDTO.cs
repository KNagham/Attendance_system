using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Attendance_system.Model;

namespace Attendance_system.DTO
{
    class AttendanceDTO
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public string? Note { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? Ende { get; set; }
        public TimeSpan? TotalTime => Ende.HasValue && Start.HasValue ? Ende.Value - Start.Value : null;
        public bool isActive => Start.HasValue && !Ende.HasValue;
        public virtual Employee? Employee { get; set; }
    }
}
