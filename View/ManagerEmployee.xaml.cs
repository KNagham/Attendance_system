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
    public partial class ManagerEmployee : Window
    {
        private Employee _currentEmployee = EmployeeService.GetCurrentEmployee();
        public ManagerEmployee()
        {
            InitializeComponent();
            cbEmployee.ItemsSource = EmployeeController.GetAllEmployees();
            listViewWorkingHour.ItemsSource = EmployeeController.GetAllWorkingHours();
        }

        private void btnWelcome(object sender, RoutedEventArgs e)
        {
            Welcome welcome = new Welcome(_currentEmployee);
            welcome.Show();
            this.Close();
        }
        private void btnProject(object sender, RoutedEventArgs e)
        {
            ManagerView project = new ManagerView(_currentEmployee);
            project.Show();
            this.Close();
        }

        private void btnTask(object sender, RoutedEventArgs e)
        {
            ManagerTask task = new ManagerTask();
            task.Show();
            this.Close();
        }

        private void btnEmployee(object sender, RoutedEventArgs e)
        {
            return;
        }

        private void btnClear(object sender, RoutedEventArgs e)
        {
            cbEmployee.SelectedIndex = -1;
            datePickerFrom.SelectedDate = null;
            datePickerTo.SelectedDate = null;
            listViewWorkingHour.ItemsSource = EmployeeController.GetAllWorkingHours();
        }

        private void btnOk(object sender, RoutedEventArgs e)
        {
            if (!EmployeeController.validInputs(datePickerFrom, datePickerTo))
            {
                return;
            }
            int employeeId = (int)cbEmployee.SelectedValue;
            DateTime? from = datePickerFrom.SelectedDate;
            DateTime? to = datePickerTo.SelectedDate;
            listViewWorkingHour.ItemsSource = EmployeeController.GetWorkingHoursbyEmployee(employeeId, from ?? DateTime.MinValue.Date,
                                                to ?? DateTime.MaxValue.Date);
        }

        private void btnUpdate(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            EmployeeDTO? employee = button?.DataContext as EmployeeDTO;
            if (employee == null)
            {
                return;
            }
            try
            {
                List<EmployeeDTO> allEntries = EmployeeController.GetAllWorkingHours();
                List<EmployeeDTO> employeeEntries = allEntries.Where(x => x.EmployeeId == employee.EmployeeId).ToList();
                foreach (EmployeeDTO entry in employeeEntries)
                {
                    entry.Confirmed = employee.Confirmed;
                }
                bool state = EmployeeController.DisabledEmployees(employeeEntries);
                if (state)
                {
                    MessageBox.Show("Employee account successfully processed", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    listViewWorkingHour.ItemsSource = EmployeeController.GetAllWorkingHours();
                }
                else
                {
                    MessageBox.Show("The employee's account can not be updated", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error when updating the employee account", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
