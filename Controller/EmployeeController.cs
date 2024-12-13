using Attendance_system.Model;
using Attendance_system.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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

            // check, ob iput ist e-mail
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

        // check, ob ein E-Mail vorhanden ist
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

        // Konto Aktivierung
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
    }
}
