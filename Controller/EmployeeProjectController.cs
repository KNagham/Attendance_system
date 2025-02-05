using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Attendance_system.Model;

namespace Attendance_system.Controller
{
    public class EmployeeProjectController
    {
        public static async System.Threading.Tasks.Task SaveWorkingTime(EmployeeProject employeeProject)
        {
            AttendanceDbContext context = new AttendanceDbContext();
            //EmployeeProject? employeeProjectAlt = context.EmployeeProjects.Where(ep => ep.Id == employeeProject.Id && ep.EmployeeId == employeeProject.EmployeeId).FirstOrDefault();
            if(employeeProject.Id == 0)
            {
                await context.EmployeeProjects.AddAsync(employeeProject);
            }
            else
            {
                /*
                employeeProjectAlt.EmployeeId = employeeProject.EmployeeId;
                employeeProjectAlt.ProjectId = employeeProject.ProjectId;
                employeeProjectAlt.Note = employeeProject.Note;
                employeeProjectAlt.TaskId = employeeProject.TaskId;
                employeeProjectAlt.WorkingTime += employeeProject.WorkingTime;
                */
                context.EmployeeProjects.Update(employeeProject);
            }
            await context.SaveChangesAsync();

        }

    }
}
