using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Attendance_system.DTO;
using Attendance_system.Model;
using Microsoft.EntityFrameworkCore;

namespace Attendance_system.Controller
{
    class AttendanceStatementController
    {
        // get Attendence an employee
        public static List<AttendanceDTO> GetAttendence(int employeeId)
        {
            AttendanceDbContext context = new AttendanceDbContext();
            return context.Attendances
                .Where(ep  => ep.EmployeeId == employeeId)
                .Select(ep => new AttendanceDTO
                {
                    Id = ep.Id,
                    EmployeeId = ep.EmployeeId,
                    Employee = ep.Employee.FirstName + " " + ep.Employee.LastName,
                    Start = ep.Start,
                    Ende = ep.Ende,
                    Note = ep.Note,
                }).ToList();
        }

        // Attendence update
        public static bool UpdateAttendence(AttendanceDTO attendanceDTO)
        {
            AttendanceDbContext context = new AttendanceDbContext();
            Attendance? attendance = context.Attendances.Where(p => p.Id == attendanceDTO.Id).FirstOrDefault();
            if (attendance != null)
            {
                attendance.Note = attendanceDTO.Note;
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public static List<AttendanceDTO> GetWorkingHoursbyDate(int employeeId, DateTime fromDate, DateTime toDate)
        {
            AttendanceDbContext context = new AttendanceDbContext();
            var query = context.Attendances
                    .Where(ep => ep.EmployeeId == employeeId &&
                          (ep.Start >= fromDate &&
                           ep.Ende <= toDate.AddSeconds(86399))
                    );
            return query.Select(ep => new AttendanceDTO
            {
                Id = ep.Id,
                EmployeeId = ep.EmployeeId,
                Employee = ep.Employee.FirstName + " " + ep.Employee.LastName,
                Start = ep.Start,
                Ende = ep.Ende,
                Note = ep.Note,
            }).ToList();
        }
    }
}
