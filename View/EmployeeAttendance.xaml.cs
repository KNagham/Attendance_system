using System;
using System.Collections.Generic;
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
    public partial class EmployeeAttendance : Window
    {
        private Employee _currentEmployee = EmployeeService.GetCurrentEmployee();
        public EmployeeAttendance()
        {
            InitializeComponent();
            setGreeting();
            listViewWorkingHour.ItemsSource = AttendanceStatementController.GetAttendence(_currentEmployee.Id);
        }

        private void setGreeting()
        {
            lblGreeting.Content = $"Hello {_currentEmployee.FirstName} {_currentEmployee.LastName}";
        }
        private void btnWelcome(object sender, RoutedEventArgs e)
        {
            Welcome welcome = new Welcome(_currentEmployee);
            welcome.Show();
            this.Close();
        }
        private void btnDashboard(object sender, RoutedEventArgs e)
        {
            EmployeeView employeeView = new EmployeeView(_currentEmployee);
            employeeView.Show();
            this.Close();
        }

        private void btnWorkingHour(object sender, RoutedEventArgs e)
        {
            EmployeeWorkingHour employeeWorkingHour = new EmployeeWorkingHour();
            employeeWorkingHour.Show();
            this.Close();
        }

        private void btnAttendenceStatement(object sender, RoutedEventArgs e)
        {
            return;
        }

        private void btnUpdate(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var employeeAttendence= button?.DataContext as AttendanceDTO;
            if (employeeAttendence == null)
            {
                return;
            }
            try
            {

                employeeAttendence.Note = employeeAttendence.Note;
                bool state = AttendanceStatementController.UpdateAttendence(employeeAttendence);
                if (state)
                {
                    MessageBox.Show("The entry has been successfully updated", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    listViewWorkingHour.ItemsSource = AttendanceStatementController.GetAttendence(_currentEmployee.Id);
                }
                else
                {
                    MessageBox.Show("The entry can not be updated", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error when updating working time", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void btnOk(object sender, RoutedEventArgs e)
        {
            if (!AttendanceController.validInputs(datePickerFrom, datePickerTo))
            {
                return;
            }
            listViewWorkingHour.ItemsSource = AttendanceStatementController.GetWorkingHoursbyDate(_currentEmployee.Id, datePickerFrom.SelectedDate.Value,
                                                datePickerTo.SelectedDate.Value);
        }

        private void btnClear(object sender, RoutedEventArgs e)
        {
            datePickerFrom.SelectedDate = null;
            datePickerTo.SelectedDate = null;
            listViewWorkingHour.ItemsSource = AttendanceStatementController.GetAttendence(_currentEmployee.Id);

        }

        
    }
}
