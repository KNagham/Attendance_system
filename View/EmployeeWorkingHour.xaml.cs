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
            if(!validInputs())
            {
                return;
            }
            int? projectId = cbProject.SelectedItem != null ? (int)cbProject.SelectedValue : (int?)null;
            int? taskId = cbTask.SelectedItem != null ? (int)cbTask.SelectedValue : (int?)null;
            listViewWorkingHour.ItemsSource = EmployeeProjectController.GetWorkingHoursbyDate(_currentEmployee.Id, datePickerFrom.SelectedDate.Value, 
                                                datePickerTo.SelectedDate.Value, projectId, taskId);
        }

        private bool validInputs()
        {
            if(!datePickerFrom.SelectedDate.HasValue || !datePickerTo.SelectedDate.HasValue)
            {
                MessageBox.Show("Bitte wählen Sie gültige Datumsbereich aus", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if(datePickerFrom.SelectedDate.Value > datePickerTo.SelectedDate.Value)
            {
                MessageBox.Show("Das Startdatum kann nicht größer als das Enddatum sein", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
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

    }
}
