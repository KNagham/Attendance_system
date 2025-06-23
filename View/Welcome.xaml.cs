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
using Attendance_system.Model;
using Attendance_system.Service;

namespace Attendance_system.View
{
    /// <summary>
    /// Interaction logic for Welcome.xaml
    /// </summary>
    public partial class Welcome : Window
    {
        private Employee _currentEmployee = EmployeeService.GetCurrentEmployee();
        public Welcome(Employee employee)
        {
            this._currentEmployee = employee;
            InitializeComponent();
        }

        private void btnManager(object sender, RoutedEventArgs e)
        {
            if(_currentEmployee.IsManager == true)
            {
                ManagerView managerView = new ManagerView(_currentEmployee);
                managerView.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("You are not authorized to access this page", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnEmployee(object sender, RoutedEventArgs e)
        {
            EmployeeView employeeView = new EmployeeView(_currentEmployee);
            employeeView.Show();
            this.Close();
        }
    }
}
