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

        /* delete 
        public static async System.Threading.Tasks.Task DeleteWorkingTime(EmployeeProject employeeProject)
        {
            AttendanceDbContext context = new AttendanceDbContext();
            context.EmployeeProjects.Remove(employeeProject);
            await context.SaveChangesAsync();
        }
        */
        public static List<EmployeeProjectDTO> GetWorkingHoursbyDate(int employeeId, DateTime fromDate, DateTime toDate, int? projectId = null, int? taskId = null)
        {
            AttendanceDbContext context = new AttendanceDbContext();
            /*List<EmployeeProjectDTO> result = context.EmployeeProjects.Select(ep => new EmployeeProjectDTO
            {
                EmployeeId = ep.EmployeeId,
                Project = ep.Project.Name,
                Task = ep.Task.Name,
                WorkingTime = ep.WorkingTime,
                Note = ep.Note,
                UpdatedAt = DateOnly.FromDateTime(ep.UpdatedAt) // Convert DateTime to DateOnly
            }).Where(ep => ep.EmployeeId == employeeId && (ep.UpdatedAt >= DateOnly.FromDateTime(fromDate) && ep.UpdatedAt <= DateOnly.FromDateTime(toDate))).ToList();
            if (projectId.HasValue)
            {
                result = result.Where(ep => ep.Project == context.Projects.FirstOrDefault(p => p.Id == projectId).Name).ToList();
            }
            if (taskId != null)
            {
                result = result.Where(ep => ep.Task == context.Tasks.FirstOrDefault(t => t.Id == taskId).Name).ToList();
            }*/
            Debug.WriteLine($"Suche nach Einträgen für Mitarbeiter {employeeId}");
            Debug.WriteLine($"Zeitraum: {fromDate} bis {toDate}");
            Debug.WriteLine($"ProjectId: {projectId?.ToString() ?? "null"}");
            Debug.WriteLine($"TaskId: {taskId?.ToString() ?? "null"}");
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
            var result = query.Select(ep => new EmployeeProjectDTO
            {
                EmployeeId = ep.EmployeeId,
                Project = ep.Project.Name,
                Task = ep.Task.Name,
                WorkingTime = ep.WorkingTime,
                Note = ep.Note,
                UpdatedAt = DateOnly.FromDateTime(ep.UpdatedAt) 
            }).ToList();
            Debug.WriteLine($"Gefundene Einträge: {result.Count}");
            return result;
        }

        // get all WorkingHour 
        public static List<EmployeeProjectDTO> GetWorkingHours(int employeeId)
        {
            AttendanceDbContext context = new AttendanceDbContext();
            return context.EmployeeProjects.Select(ep => new EmployeeProjectDTO
            {
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
    }
}
