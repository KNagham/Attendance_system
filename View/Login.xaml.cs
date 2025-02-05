using Attendance_system.Controller;
using Attendance_system.Model;
using Microsoft.Win32;
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

namespace Attendance_system.View
{
    /// <summary>
    /// Interaktionslogik für Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnSignUp(object sender, MouseButtonEventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Close();
        }

        private void btnBack(object sender, RoutedEventArgs e)
        {

        }
        
        private void btnLogin(object sender, RoutedEventArgs e)
        {
            string reason = "";

            string password = PasswordController.ComputeSHA256(txtPassword.Password);
            bool state = EmployeeController.CheckLogin(txtUsername.Text, password, ref reason, out Employee currentEmployee);

            if (state)
            {
                MessageBox.Show(" Anmeldung ist erfolgreich.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                EmployeeView employeeView = new EmployeeView(currentEmployee);
                //EmployeeView employeeView = new EmployeeView();
                employeeView.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show(reason, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void btnForgotPassword(object sender, MouseButtonEventArgs e)
        {
            ResetPassword resetPassword= new ResetPassword();
            resetPassword.Show();
            this.Close();
        }
    }
}
