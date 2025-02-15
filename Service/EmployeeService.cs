using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Attendance_system.Model;

namespace Attendance_system.Service
{
    public static class EmployeeService
    {
        private static Employee _currentEmployee;
        public static Employee GetCurrentEmployee()
        {
            return _currentEmployee;
        }

        public static void setCurrentEmployee(Employee employee)
        {
            _currentEmployee = employee;
        }

        public static bool isLoggedIn => _currentEmployee != null;
    }
}
