using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance_system.DTO
{
    public class EmployeeDTO
    {
        public int? EmployeeId { get; set; }
        public string? Employee { get; set; }

        private bool? _confirmed;
        public string? WorkingDate { get; set; }

        public string? Hour { get; set; }
        
        public string? Note { get; set; }
        public bool? Confirmed
        {
            get => _confirmed;
            set
            {
                _confirmed = value;
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
