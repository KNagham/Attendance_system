using Attendance_system.Controller;
using Attendance_system.Model;
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
    public partial class ResetPassword : Window
    {
        public ResetPassword()
        {
            InitializeComponent();
            txtResetCode.IsEnabled = false;
            txtCPassword.IsEnabled = false;
            txtPassword.IsEnabled = false;
        }
        
        private async void btnSendCode(object sender, RoutedEventArgs e)
        {
            if (!EmployeeController.EmailValidator(txtEmail.Text) || txtEmail.Text == string.Empty)
            {
                MessageBox.Show("Please enter a valid email address", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            PasswordController passwordController= new PasswordController();
            bool state = await passwordController.sendResetCode(txtEmail.Text.ToLower());
            if (state)
            {
                txtEmail.IsEnabled = false;
                MessageBox.Show("The activation code has been sent successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                txtResetCode.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("An error while sending\nPlease try later", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnConfirm(object sender, RoutedEventArgs e)
        {
            if (txtResetCode.Text != string.Empty)
            {
                bool state = PasswordController.ConfirmedResetPassword(txtResetCode.Text);
                if (state)
                {
                    MessageBox.Show("Your account has been confirmed", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    txtResetCode.Text = string.Empty;
                    txtPassword.IsEnabled = true;
                    txtCPassword.IsEnabled = true;
                    txtResetCode.IsEnabled = false;

                }
                else
                {
                    MessageBox.Show("Please check the given code", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter the code", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            } 
        }

        private void btnResetPassword(object sender, RoutedEventArgs e)
        {
            if (txtPassword.Password.Count() < 8 || txtCPassword.Password.Count() < 8)
            {
                MessageBox.Show("Your password is short, it must be at least 8 digits long", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (txtPassword.Password != txtCPassword.Password)
            {
                MessageBox.Show("Please check the password in both fields", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            bool state = PasswordController.UpdatePassword(txtEmail.Text, txtPassword.Password);
            if (state)
            {
                MessageBox.Show("Your password has been changed\nYou can log in to the system again", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                //txtEmail.Text = "";
                txtPassword.Password = "";
                txtCPassword.Password = "";
            }
            else
            {
                MessageBox.Show("Error when updating the password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            } 

        }
       
        private void btnBack(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }
    }
}
