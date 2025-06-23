using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Attendance_system.Model;

namespace Attendance_system.DTO
{
    class AttendanceDTO
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }

        private string? _note;
        public string? Employee { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? Ende { get; set; }
        public string? Hour => Ende.HasValue && Start.HasValue
            ? $"{Math.Floor((Ende.Value - Start.Value).TotalHours)}h {(int)((Ende.Value - Start.Value).TotalHours * 60) % 60}min"
            : null;

        public string? Note
        {
            get => _note;
            set
            {
                _note = value;
                OnPropertyChanged(nameof(Note));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
