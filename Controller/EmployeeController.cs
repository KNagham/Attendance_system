using Attendance_system.DTO;
using Attendance_system.Model;
using Attendance_system.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace Attendance_system.Controller
{
    public class EmployeeController
    {
        private readonly EmailService _emailService;

        public EmployeeController()
        {
            _emailService = App._emailService ?? throw new InvalidOperationException("EmailService is not initialized.");
        }
        // email-validating
        public static bool EmailValidator(string email)
        {
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(email);
        }

        // Generate Random Activation code
        public static string GenerateCode()
        {
            Random random = new Random();
            string activationCode = string.Empty;
            for (int i = 0; i < 8; i++)
            {
                activationCode += (char)random.Next(48, 58);
            }
            return activationCode;
        }

        // check Login
        public static bool CheckLogin(string loginInput, string password, ref string reason, out Employee currentEmployee)
        {
            AttendanceDbContext context = new AttendanceDbContext();
            Employee? employee = null;

            // check if loginInput is email or username
            if (EmailValidator(loginInput))
            {
                employee = context.Employees.Where(x => x.Email == loginInput).FirstOrDefault();
            }
            else
            {
                employee = context.Employees.Where(x => x.UserName == loginInput).FirstOrDefault();
            }

            currentEmployee = employee;
            if (employee == null)
            {
                reason = "Ihr Konto ist nicht vorhanden";
                return false;
            }
            // Check, if E-mail is confirmed
            if (employee.Confirmed == false)
            {
                reason = "Bitte aktivieren Sie Ihr Konto zuerst.";
                return false;
            }
            Password? employeePassword = context.Passwords.Where(x => x.Id == employee.Id).FirstOrDefault();
            if (employeePassword == null || employeePassword.PasswordKey != password)
            {
                reason = "Password ist falsch";
                return false;
            }
            return true;
        }

        // check if email is exist
        private static bool CheckEmailExist(string email)
        {
            AttendanceDbContext context = new AttendanceDbContext();
            return context.Employees.Any(x => x.Email == email);
        }

        // Add new employee
        public static bool AddEmployee(Employee employee, Password password)
        {
            bool result = false;
            AttendanceDbContext context = new AttendanceDbContext();

            // email ist vorhanden
            if (CheckEmailExist(employee.Email))
            {
                return false;
            }
            else
            {
                context.Employees.Add(employee);
                context.SaveChanges();

                password.Id = employee.Id;
                context.Passwords.Add(password);
                context.SaveChanges();
                result = true;
            }
            return result;
        }

        // send Activation code
        public async Task<bool> sendActivationCode(string email)
        {
            bool result = false;
            try
            {
                AttendanceDbContext context = new AttendanceDbContext();
                Employee? employee = context.Employees.Where(x => x.Email == email).FirstOrDefault();
                if (employee == null)
                {
                    return false;
                }

                string activationCode = GenerateCode();
                bool state = await _emailService.SendActivationCodeAsync(email, activationCode);
                if (!state)
                {
                    return false;
                }
                employee.ActivationCode = activationCode;
                context.Employees.Update(employee);
                context.SaveChanges();
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }

        // Account activation
        public static bool ActivateEmployee(string activationCode)
        {
            AttendanceDbContext context = new AttendanceDbContext();
            Employee? employee = context.Employees.Where(x => x.ActivationCode == activationCode).FirstOrDefault();
            if (employee == null)
            {
                return false;
            }

            employee.Confirmed = true;
            employee.ActivationCode = "";

            context.Employees.Update(employee);
            context.SaveChanges();
            return true;
        }

        // get all active employee
        public static List<EmployeeDTO> GetAllEmployees()
        {
            AttendanceDbContext context = new AttendanceDbContext();
            return context.Employees.Where(p => p.Confirmed == true).Select(p => new EmployeeDTO 
            { 
                EmployeeId = p.Id, 
                Employee = p.FirstName + " "  + p.LastName,
            }).ToList();
        }

        // format working hour
        private static string FormatWorkingHours(List<Attendance> attendances)
        {
            TimeSpan totalDuration = TimeSpan.Zero;

            foreach (Attendance attendance in attendances)
            {
                if (attendance.Start.HasValue && attendance.Ende.HasValue)
                {
                    totalDuration += attendance.Ende.Value - attendance.Start.Value;
                }
            }

            return $"{totalDuration.Hours:D2}h {totalDuration.Minutes:D2}min";
        }

        /*public static List<EmployeeDTO> GetAllWorkingHours()
        {
            AttendanceDbContext context = new AttendanceDbContext();

            return context.Employees
                .Include(e => e.Attendances)
                .AsNoTracking()
                .ToList()
                .Select(ep => new EmployeeDTO
                {
                    EmployeeId = ep.Id,
                    Employee = $"{ep.FirstName} {ep.LastName}",
                    Confirmed = ep.Confirmed,

                    // Explizite Konvertierung von DateTime zu DateOnly
                    WorkingDate = ep.Attendances.Any() ? DateOnly.FromDateTime(
                        ep.Attendances.Max(a => a.Start.Value)).ToString("MMMM-yyyy", CultureInfo.InvariantCulture) : null,

                    Note = ep.Attendances.Any() ? ep.Attendances.LastOrDefault()?.Note : null,
                    Hour = ep.Attendances.Any() ? FormatWorkingHours(ep.Attendances.ToList()) : null,
                })
                .ToList();
        }*/

        public static List<EmployeeDTO> GetAllWorkingHours()
        {
            AttendanceDbContext context = new AttendanceDbContext();

            return context.Employees
                .Include(e => e.Attendances)
                .AsNoTracking()
                .ToList()
                .SelectMany(employee =>
                {
                    // Gruppiere vorhandene Arbeitszeiten nach Monat
                    var groupedAttendances = employee.Attendances
                        .Where(a => a.Start.HasValue && a.Ende.HasValue)
                        .GroupBy(a => DateOnly.FromDateTime(a.Start.Value))
                        .Select(group => new EmployeeDTO
                        {
                            EmployeeId = employee.Id,
                            Employee = $"{employee.FirstName} {employee.LastName}",
                            Confirmed = employee.Confirmed,
                            WorkingDate = group.Key.ToString("MMMM-yyyy", CultureInfo.InvariantCulture),
                            Note = group.LastOrDefault()?.Note,
                            Hour = FormatWorkingHours(group.ToList())
                        });

                        // Wenn der Mitarbeiter keine Arbeitszeiten hat, füge einen leeren Eintrag hinzu
                        if (!groupedAttendances.Any())
                        {
                            return new[] { new EmployeeDTO
                            {
                                EmployeeId = employee.Id,
                                Employee = $"{employee.FirstName} {employee.LastName}",
                                Confirmed = employee.Confirmed,
                                WorkingDate = null,
                                Note = null,
                                Hour = null
                            }};
                        }

                    return groupedAttendances;
                })
                .OrderBy(dto => dto.WorkingDate)
                .ToList();
        }

        public static List<EmployeeDTO> GetWorkingHoursbyEmployee(int employeeId, DateTime? fromDate = null, DateTime? toDate = null)
        {
            AttendanceDbContext context = new AttendanceDbContext();
            return context.Employees
                .Include(e => e.Attendances)
                .AsNoTracking()
                .Where(e => e.Id == employeeId)
                .ToList()
                .SelectMany(employee =>
                {
                    // Filter by date range
                    var filterAttendances = employee.Attendances
                        .Where(a => a.Start.HasValue && a.Ende.HasValue)
                        .Where(a => !fromDate.HasValue || a.Start.Value.Date >= fromDate)
                        .Where(a => !toDate.HasValue || a.Ende.Value.Date <= toDate)
                        .GroupBy(a => DateOnly.FromDateTime(a.Start.Value))
                        .Select(group => new EmployeeDTO
                        {
                            EmployeeId = employee.Id,
                            Employee = $"{employee.FirstName} {employee.LastName}",
                            Confirmed = employee.Confirmed,
                            WorkingDate = group.Key.ToString("dd-MM-yyyy"),
                            Note = group.LastOrDefault()?.Note,
                            Hour = FormatWorkingHours(group.ToList())
                        });

                    // Wenn der Mitarbeiter keine Arbeitszeiten hat, füge einen leeren Eintrag hinzu
                    if (!filterAttendances.Any())
                    {
                        return new[] { new EmployeeDTO
                            {
                                EmployeeId = employee.Id,
                                Employee = $"{employee.FirstName} {employee.LastName}",
                                Confirmed = employee.Confirmed,
                                WorkingDate = null,
                                Note = null,
                                Hour = null
                            }};
                    }

                    return filterAttendances;
                })
                .OrderBy(dto => dto.WorkingDate)
                .ToList();
        }
        // Disable employees
        public static bool DisabledEmployees(List<EmployeeDTO> employeeDTO)
        {
            using (var context = new AttendanceDbContext())
            {
                foreach (var employee in employeeDTO)
                {
                    var employeeEntity = context.Employees
                        .FirstOrDefault(e => e.Id == employee.EmployeeId);

                    if (employeeEntity != null)
                    {
                        // Nur die Confirmed-Eigenschaft aktualisieren
                        employeeEntity.Confirmed = employee.Confirmed;
                    }
                }

                return context.SaveChanges() > 0;
            }
        }

        public static bool validInputs(DatePicker datePickerFrom, DatePicker datePickerTo)
        {
            if (!datePickerFrom.SelectedDate.HasValue && !datePickerTo.SelectedDate.HasValue)
            {
                return true;
            }
            if (datePickerFrom.SelectedDate.HasValue && datePickerTo.SelectedDate.HasValue)
            {
                if (datePickerFrom.SelectedDate.Value > datePickerTo.SelectedDate.Value)
                {
                    MessageBox.Show("Das Startdatum kann nicht größer als das Enddatum sein", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            
            return true;
        }
    }
}
