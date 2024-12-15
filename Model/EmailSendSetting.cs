using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance_system.Model
{
    public class EmailSendSetting
    {
        public string smtpServer { get; set; }
        public int port { get; set; }
        public string secureSocketOptions { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}