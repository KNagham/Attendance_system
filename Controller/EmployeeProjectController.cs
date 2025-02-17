using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Attendance_system.DTO;
using Attendance_system.Model;
using Microsoft.EntityFrameworkCore;

namespace Attendance_system.Controller
{
    public class EmployeeProjectController
    {
        public static async System.Threading.Tasks.Task SaveWorkingTime(EmployeeProject employeeProject)
        {
            AttendanceDbContext context = new AttendanceDbContext();
            if(employeeProject.Id == 0)
            {
                await context.EmployeeProjects.AddAsync(employeeProject);
            }
            else
            {
                context.EmployeeProjects.Update(employeeProject);
            }
            await context.SaveChangesAsync();
        }

        public static List<EmployeeProjectDTO> GetWorkingHoursbyDate(int employeeId, DateTime fromDate, DateTime toDate, int? projectId = null, int? taskId = null)
        {
            AttendanceDbContext context = new AttendanceDbContext();
            var query = context.EmployeeProjects
                    .Include(ep => ep.Project)
                    .Include(ep => ep.Task)
                    .Where(ep => ep.EmployeeId == employeeId && 
                          (ep.UpdatedAt >= fromDate && 
                           ep.UpdatedAt <= toDate.AddSeconds(86399))
                    );
            if (projectId.HasValue)
            {
                query = query.Where(ep => ep.ProjectId == projectId);
            }
            if (taskId.HasValue)
            {
                query = query.Where(ep => ep.TaskId == taskId);
            }
            return query.Select(ep => new EmployeeProjectDTO
            {
                Id = ep.Id,
                EmployeeId = ep.EmployeeId,
                Project = ep.Project.Name,
                Task = ep.Task.Name,
                WorkingTime = ep.WorkingTime,
                Note = ep.Note,
                UpdatedAt = DateOnly.FromDateTime(ep.UpdatedAt) 
            }).ToList();
        }

        // get all WorkingHour 
        public static List<EmployeeProjectDTO> GetWorkingHours(int employeeId)
        {
            AttendanceDbContext context = new AttendanceDbContext();
            return context.EmployeeProjects.Select(ep => new EmployeeProjectDTO
            {
                Id = ep.Id,
                EmployeeId = ep.EmployeeId ,
                Project = ep.Project.Name,
                Task = ep.Task.Name,
                WorkingTime = ep.WorkingTime,
                Note = ep.Note,
            }).Where(ep => ep.EmployeeId == employeeId).ToList();
        }

        public static int GetProjectId(string projectname)
        {
            AttendanceDbContext context = new AttendanceDbContext();
            Project project = context.Projects.FirstOrDefault(p => p.Name == projectname);
            return project.Id;
        }

        public static int GetTaskId(string taskname)
        {
            AttendanceDbContext context = new AttendanceDbContext();
            Model.Task task = context.Tasks.FirstOrDefault(t => t.Name == taskname);
            return task.Id;
        }

        // get all project an Employee
        public static List<ProjectDTO> GetAllProjectsbyEmployee(int employeeId)
        {
            AttendanceDbContext context = new AttendanceDbContext();
            return context.EmployeeProjects
                    .Include(ep => ep.Project)
                    .Where(ep => ep.EmployeeId == employeeId)
                    .GroupBy(ep => ep.Project.Name)
                    .Select(ep => new ProjectDTO
                    {
                        Id = ep.First().ProjectId,
                        Name = ep.Key,
                    }).ToList();
        }


        // get all Tasks an Employee
        public static List<TaskDTO> GetAllTaskssbyEmployee(int employeeId)
        {
            AttendanceDbContext context = new AttendanceDbContext();
            return context.EmployeeProjects
                    .Include(ep => ep.Task)
                    .Where(ep => ep.EmployeeId == employeeId)
                    .GroupBy(ep => ep.Task.Name)
                    .Select(ep => new TaskDTO 
                    {
                        Id = ep.First().TaskId,
                        Name = ep.Key,
                    }).ToList();
        }

        // working hours update
        public static bool UpdateWorkingHour(EmployeeProjectDTO employeeProjectDTO)
        {
            AttendanceDbContext context = new AttendanceDbContext();
            EmployeeProject? projectAlt = context.EmployeeProjects.Where(p => p.Id == employeeProjectDTO.Id).FirstOrDefault();
            if (projectAlt != null)
            {
                projectAlt.WorkingTime = employeeProjectDTO.WorkingTime;
                projectAlt.Note = employeeProjectDTO.Note;
                context.SaveChanges();
                return true;
            }
            return false;
        }

        // delete Employeeproject
        public static bool DeleteEmployeeProject(EmployeeProjectDTO employeeProjectDTO)
        {
            AttendanceDbContext context = new AttendanceDbContext();
            EmployeeProject? employeeProject = context.EmployeeProjects.Where(p => p.Id == employeeProjectDTO.Id).FirstOrDefault();
            if (employeeProject != null)
            {
                context.EmployeeProjects.Remove(employeeProject);
                context.SaveChanges();
                return true;
            }
            return false;
        }
        
    }
}
