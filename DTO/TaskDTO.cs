using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance_system.DTO
{
    public class TaskDTO
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string CreatedDateOnly { get; set; }
        public string UpdatedDateOnly { get; set; }
        public string Status { get; set; }
        public string? Priority { get; set; }
        public string? Project { get; set; }
    }
}
