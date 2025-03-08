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
    /// <summary>
    /// Interaction logic for EmployeeAttendance.xaml
    /// </summary>
    public partial class EmployeeAttendance : Window
    {
        private Employee _currentEmployee = EmployeeService.GetCurrentEmployee();
        public EmployeeAttendance()
        {
            InitializeComponent();
            listViewWorkingHour.ItemsSource = AttendanceStatementController.GetAttendence(_currentEmployee.Id);
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
                    MessageBox.Show("Der Eintrag erfolgreich aktualisiert", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    listViewWorkingHour.ItemsSource = AttendanceStatementController.GetAttendence(_currentEmployee.Id);
                }
                else
                {
                    MessageBox.Show("Der Eintrag kann nicht aktualisiert werden", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim Aktualisieren der Arbeitszeit", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
