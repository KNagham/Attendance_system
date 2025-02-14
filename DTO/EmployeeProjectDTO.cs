using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Attendance_system.Model;

namespace Attendance_system.DTO
{
    public class EmployeeProjectDTO
    {
        public int? Id { get; set; }
        public int? EmployeeId { get; set; }
        public string? Project { get; set; }
        public string? Task { get; set; }
        public double? WorkingTime { get; set; }
        public DateOnly? CreatedAt { get; set; }
        public DateOnly? UpdatedAt { get; set; }
        public string? Note {  get; set; }

        // formatierung for show
        public string WorkingTimeFormatted => WorkingTime.HasValue
                        ? $"{(int)WorkingTime.Value / 3600:00}:{(int)(WorkingTime.Value % 3600) / 60:00}:{(int)WorkingTime.Value % 60:00}"
                        : "";

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
