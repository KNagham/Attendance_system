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
        private double? _workingTime;
        private string? _note;
        public int? Id { get; set; }
        public int? EmployeeId { get; set; }
        public string? Project { get; set; }
        public string? Task { get; set; }
        public double? WorkingTime
        {
            get => _workingTime;
            set
            {
                _workingTime = value;
                OnPropertyChanged(nameof(WorkingTime));
                OnPropertyChanged(nameof(WorkingTimeFormatted));
            }
        }
        public DateOnly? CreatedAt { get; set; }
        public DateOnly? UpdatedAt { get; set; }
        public string? Note 
        {  
            get => _note;
            set
            {
                _note = value;
                OnPropertyChanged(nameof(Note));
            }
        }

        // formatierung for show
        public string WorkingTimeFormatted
        {
            get => WorkingTime.HasValue
                ? $"{(int)WorkingTime.Value / 3600:00}:{(int)(WorkingTime.Value % 3600) / 60:00}:{(int)WorkingTime.Value % 60:00}"
                : "";
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    WorkingTime = null;
                    return;
                }

                var timeParts = value.Split(':');
                if (timeParts.Length != 3)
                {
                    throw new ArgumentException("Ungültiges Zeitformat. Bitte verwenden Sie HH:MM:SS");
                }

                int hours = int.Parse(timeParts[0]);
                int minutes = int.Parse(timeParts[1]);
                int seconds = int.Parse(timeParts[2]);

                WorkingTime = hours * 3600 + minutes * 60 + seconds;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
