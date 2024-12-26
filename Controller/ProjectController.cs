using Attendance_system.DTO;
using Attendance_system.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance_system.Controller
{
    public class ProjectController
    {

        // check, ob ein Project vorhanden ist
        private static bool CheckProjectExist(string projectName)
        {
            AttendanceDbContext context = new AttendanceDbContext();
            return context.Projects.Any(x => x.Name == projectName);
        }
        // Add new project
        public static bool AddProject(Project project)
        {
            bool result = false;
            AttendanceDbContext context = new AttendanceDbContext();

            // project ist vorhanden
            if (CheckProjectExist(project.Name))
            {
                return false;
            }
            else
            {
                context.Projects.Add(project);
                context.SaveChanges();
                result = true;
            }
            return result;
        }
        // get all ProjectDTO to data show 
        public static List<ProjectDTO> GetAllProjects()
        {
            AttendanceDbContext context = new AttendanceDbContext();
            return context.Projects.Select(p => new ProjectDTO
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                CreatedDateOnly = p.CreatedAt.ToString("dd-MM-yyyy"),
                UpdatedDateOnly = p.UpdatedAt.ToString("dd-MM-yyyy"),
                Status = p.IsDone == true ? "Done" : (p.IsActive == true ? "Active" : "Inactive"),
                CountOfTasks = p.Task != null ? 1 : 0,
            }).ToList();
        }

        // search per ID or name
        public static Project? GetProject<T>(T item)
        {
            AttendanceDbContext context = new AttendanceDbContext();
            if (item is int id)
            {
                return context.Projects.Where(p => p.Id == id).FirstOrDefault();
            }
            else if (item is string name)
            { 
                return context.Projects.Where(p => p.Name == name).FirstOrDefault();
            }
            else
            {
                return null;
            }
        }
    }
}
