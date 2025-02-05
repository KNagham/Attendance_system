using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Attendance_system.Model;

namespace Attendance_system.DTO
{
    public class EmployeeProjectDTO
    {
        public int? Id { get; set; }
        public int? EmployeeId { get; set; }
        public int? ProjectId { get; set; }
        public int? TaskId { get; set; }
        public double? WorkingTime { get; set; }
        public string CreatedDateOnly { get; set; }
        public string UpdatedDateOnly { get; set; }
        public string? Note {  get; set; }
    }
}
