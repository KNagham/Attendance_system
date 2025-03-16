using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using Attendance_system.DTO;
using Attendance_system.Model;
using Microsoft.EntityFrameworkCore;

namespace Attendance_system.Controller
{
    class AttendanceController
    {
        public static Attendance CheckIn(int EmployeeId, string note)
        {
            AttendanceDbContext context = new AttendanceDbContext();
            Attendance? activeAttendance = context.Attendances
                    .Where(a => a.EmployeeId == EmployeeId && !a.Ende.HasValue)
                    .FirstOrDefault();
            if (activeAttendance != null)
            {
                return activeAttendance;
            }
            // else
            Attendance newAttendance = new Attendance
            {
                EmployeeId = EmployeeId,
                Note = note,
                Start = DateTime.Now,
            };
            context.Attendances.Add(newAttendance);
            context.SaveChanges();
            return newAttendance;
        }

        public static void CheckOut(int attendanceId, string note)
        {
            AttendanceDbContext context = new AttendanceDbContext();
            Attendance? activeAttendance = context.Attendances
                    .Where(a => a.Id == attendanceId && !a.Ende.HasValue)
                    .FirstOrDefault();
            if (activeAttendance == null)
            {
                throw new InvalidOperationException("Keine aktive Zeiterfassung gefunden");
            }
            // else
            activeAttendance.Ende = DateTime.Now;
            activeAttendance.Note = note;
            context.SaveChanges();
        }

        public static bool validInputs(DatePicker datePickerFrom, DatePicker datePickerTo)
        {
            if (!datePickerFrom.SelectedDate.HasValue)
            {
                MessageBox.Show("Bitte wählen Sie gültige Datumsbereich aus", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if(!datePickerTo.SelectedDate.HasValue)
            {
                datePickerTo.SelectedDate = DateTime.Now; 
            }
            if (datePickerFrom.SelectedDate.Value > datePickerTo.SelectedDate.Value)
            {
                MessageBox.Show("Das Startdatum kann nicht größer als das Enddatum sein", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
    }
}
