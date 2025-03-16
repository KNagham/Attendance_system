using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance_system.DTO
{
    class EmployeeMonthlyHoursDTO
    {
        public int? EmployeeId { get; set; }
        public string? Employee { get; set; }
        public string? WorkingDate { get; set; }
        public string? Hour { get; set; }
    }
}
