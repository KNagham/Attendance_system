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
    }
}
