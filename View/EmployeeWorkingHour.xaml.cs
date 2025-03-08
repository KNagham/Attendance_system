using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Attendance_system.Controller;
using Attendance_system.DTO;
using Attendance_system.Model;
using Attendance_system.Service;

namespace Attendance_system.View
{
    public partial class EmployeeWorkingHour : Window
    {
        private Employee _currentEmployee;
        public EmployeeWorkingHour()
        {
            _currentEmployee = EmployeeService.GetCurrentEmployee();
            InitializeComponent();
            cbProject.ItemsSource = EmployeeProjectController.GetAllProjectsbyEmployee(_currentEmployee.Id);
            cbTask.ItemsSource = EmployeeProjectController.GetAllTaskssbyEmployee(_currentEmployee.Id);
            listViewWorkingHour.ItemsSource = EmployeeProjectController.GetWorkingHours(_currentEmployee.Id);
        }

        private void btnDashboard(object sender, RoutedEventArgs e)
        {
            EmployeeView employeeview = new EmployeeView(_currentEmployee);
            employeeview.Show();
            this.Close();
        }
        private void btnAttendenceStatement(object sender, RoutedEventArgs e)
        {
            EmployeeAttendance employeeAttendance = new EmployeeAttendance();
            employeeAttendance.Show();
            this.Close();
        }
        private void btnWorkingHour(object sender, RoutedEventArgs e)
        {
            return;
        }

        private void btnClear(object sender, RoutedEventArgs e)
        {
            clear(true);
        }

        private void btnOk(object sender, RoutedEventArgs e)
        {
            if(!AttendanceController.validInputs(datePickerFrom, datePickerTo))
            {
                return;
            }
            int? projectId = cbProject.SelectedItem != null ? (int)cbProject.SelectedValue : (int?)null;
            int? taskId = cbTask.SelectedItem != null ? (int)cbTask.SelectedValue : (int?)null;
            listViewWorkingHour.ItemsSource = EmployeeProjectController.GetWorkingHoursbyDate(_currentEmployee.Id, datePickerFrom.SelectedDate.Value, 
                                                datePickerTo.SelectedDate.Value, projectId, taskId);
        }

        private void clear(bool listClear = false)
        {
            cbProject.SelectedIndex = -1;
            cbTask.SelectedIndex = -1;
            datePickerFrom.SelectedDate = null;
            datePickerTo.SelectedDate = null;
            if (listClear)
            {
                listViewWorkingHour.ItemsSource = EmployeeProjectController.GetWorkingHours(_currentEmployee.Id);
            }
        }

        private void btnUpdate(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var employeeProject = button?.DataContext as EmployeeProjectDTO;
            if (employeeProject == null)
            {
                return;
            }
            try
            {
                // input validate
                if(!double.TryParse(employeeProject.WorkingTimeFormatted.Replace(":", ""), out double totalSeconds))
                {
                    MessageBox.Show("Bitte geben Sie eine gültige Zeit im Format HH:MM:SS ein.",  "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                // time convert
                string[] timeParts = employeeProject.WorkingTimeFormatted.Split(':');
                if (timeParts.Length != 3)
                {
                    MessageBox.Show("Bitte geben Sie eine gültige Zeit im Format HH:MM:SS ein.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                int hour = int.Parse(timeParts[0]);
                int minute = int.Parse(timeParts[1]);
                int second = int.Parse(timeParts[2]);
                employeeProject.WorkingTime = hour * 3600 + minute * 60 + second;
                employeeProject.Note = employeeProject.Note;
                bool state = EmployeeProjectController.UpdateWorkingHour(employeeProject);
                if(state)
                {
                    MessageBox.Show("Die Arbeitszeit erfolgreich aktualisiert", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    listViewWorkingHour.ItemsSource = EmployeeProjectController.GetWorkingHours(_currentEmployee.Id);
                }
                else
                {
                    MessageBox.Show("Die Arbeitszeit kann nicht aktualisiert werden", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Fehler beim Aktualisieren der Arbeitszeit", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void btnDelete(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var employeeProject = button?.DataContext as EmployeeProjectDTO;
            if (employeeProject == null)
            {
                return;
            }
            if (MessageBox.Show("Möchten Sie wirklich löschen?", "Warnung", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                bool state = EmployeeProjectController.DeleteEmployeeProject(employeeProject);
                if(state)
                {
                    MessageBox.Show("Die Arbeitszeit erfolgreich gelöscht", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    listViewWorkingHour.ItemsSource = EmployeeProjectController.GetWorkingHours(_currentEmployee.Id);
                }
                else
                {
                    MessageBox.Show("Die Arbeitszeit kann nicht gelöscht werden", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
