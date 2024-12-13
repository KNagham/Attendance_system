using Attendance_system.Model;
using Attendance_system.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Attendance_system.Controller
{
    public class PasswordController
    {
        private readonly EmailService _emailService;

        public PasswordController()
        {
            _emailService = App._emailService ?? throw new InvalidOperationException("EmailService is not initialized.");
        }

        public static string ComputeSHA256(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                List<byte> bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password)).ToList();

                StringBuilder sb = new StringBuilder();
                bytes.ForEach(x => sb.Append(x.ToString("x2")));
                return sb.ToString();
            }
        }

        // send Activation code
        public async Task<bool> sendResetCode(string email)
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

                string ResetCode = EmployeeController.GenerateCode();
                bool state = await _emailService.SendActivationCodeAsync(email, ResetCode);
                if (!state)
                {
                    return false;
                }
                Password? password = context.Passwords.Where(x => x.Id == employee.Id).FirstOrDefault();
                password.ResetCode= ResetCode;
                context.Passwords.Update(password);
                context.SaveChanges();
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }

        // confirmed reset password
        public static bool ConfirmedResetPassword(string resetCode)
        {
            AttendanceDbContext context = new AttendanceDbContext();
            Password? password= context.Passwords.Where(x => x.ResetCode == resetCode).FirstOrDefault();
            if (password == null)
            {
                return false;
            }
            context.Passwords.Update(password);
            context.SaveChanges();
            return true;
        }

        //  reset password
        public static bool UpdatePassword(string email, string newPassword)
        {
            AttendanceDbContext context = new AttendanceDbContext();
            Employee? employee = context.Employees.Where(x =>x.Email == email).FirstOrDefault();
            if (employee == null)
            {
                return false;
            }
            Password? password = context.Passwords.Where(x => x.Id == employee.Id).FirstOrDefault();
            if (password == null)
            {
                return false;
            }

            password.PasswordKey = ComputeSHA256(newPassword);
            password.ResetCode = string.Empty;
            context.Passwords.Update(password);
            context.SaveChanges();
            return true;
        }
    }
}
