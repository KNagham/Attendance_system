using Attendance_system.DTO;
using Attendance_system.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance_system.Controller
{
    public class TaskController
    {
        // get all ProjectDTO to data show 
        public static List<TaskDTO> GetAllTasks()
        {
            AttendanceDbContext context = new AttendanceDbContext();
            return context.Tasks.Select(t => new TaskDTO
            {
                Id = t.Id,
                Name = t.Name,
                Description = t.Description,
                CreatedDateOnly = t.CreatedAt.ToString("dd-MM-yyyy"),
                UpdatedDateOnly = t.UpdatedAt.ToString("dd-MM-yyyy"),
                Status = t.IsDone == true ? "Done" : (t.IsActive == true ? "Active" : "Inactive"),
                Priority = t.Priority != null ? t.Priority : "",
                Project = t.Project != null ? t.Project.Name : "",
            }).ToList();
        }

        // get all active project
        public static List<ProjectDTO> GetAllProjects()
        {
            AttendanceDbContext context = new AttendanceDbContext();
            return  context.Projects.Where(p => p.IsActive == true).Select(p => new ProjectDTO { Id = p.Id, Name = p.Name}).ToList();
        }

        // Add new task
        public static void AddTask(Model.Task task)
        {
            AttendanceDbContext context = new AttendanceDbContext();
            context.Tasks.Add(task);
            context.SaveChanges();
        }

        // search per ID or name
        public static Model.Task? GetTask<T>(T item)
        {
            AttendanceDbContext context = new AttendanceDbContext();
            if (item is int id)
            {
                return context.Tasks.Where(t => t.Id == id).FirstOrDefault();
            }
            else if (item is string name)
            {
                return context.Tasks.Where(t => t.Name == name).FirstOrDefault();
            }
            else
            {
                return null;
            }
        }

        // update task
        public static bool UpdateTask(Model.Task task)
        {
            AttendanceDbContext context = new AttendanceDbContext();
            Model.Task? taskAlt = context.Tasks.Where(t => t.Id == task.Id).FirstOrDefault();
            if (taskAlt != null)
            {
                taskAlt.Name = task.Name;
                taskAlt.Description = task.Description;
                taskAlt.IsActive = task.IsActive;
                taskAlt.IsDone = task.IsDone;
                taskAlt.Priority = task.Priority;
                taskAlt.ProjectId = task.ProjectId;
                context.SaveChanges();
                return true;
            }
            return false;
        }

        // delete task
        public static bool DeleteTask(Model.Task task)
        {
            AttendanceDbContext context = new AttendanceDbContext();
            if (task != null)
            {
                context.Tasks.Remove(task);
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
