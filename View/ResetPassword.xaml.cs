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
    /// <summary>
    /// Interaktionslogik für ResetPassword.xaml
    /// </summary>
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
                MessageBox.Show("Bitte geben Sie eine gültige E-Mail Adresse ein", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            PasswordController passwordController= new PasswordController();
            bool state = await passwordController.sendResetCode(txtEmail.Text.ToLower());
            if (state)
            {
                txtEmail.IsEnabled = false;
                MessageBox.Show("Der Bestätigungscode wurde erfolgreich gesendet.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                txtResetCode.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("Eine Fehler ist aufgetreten\n versuchen Sie später.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnConfirm(object sender, RoutedEventArgs e)
        {
            if (txtResetCode.Text != string.Empty)
            {
                bool state = PasswordController.ConfirmedResetPassword(txtResetCode.Text);
                if (state)
                {
                    MessageBox.Show("Ihr Koto wurde bestätigt", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    txtResetCode.Text = string.Empty;
                    txtPassword.IsEnabled = true;
                    txtCPassword.IsEnabled = true;
                    txtResetCode.IsEnabled = false;

                }
                else
                {
                    MessageBox.Show("Bitte kontrollieren Sie den angegebenen Code", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Bitte geben Sie das Code ein !", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            } 
        }

        private void btnResetPassword(object sender, RoutedEventArgs e)
        {
            if (txtPassword.Password.Count() < 8 || txtCPassword.Password.Count() < 8)
            {
                MessageBox.Show("Ihr Password ist schwach, es muss mind.8 Stelle sein ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (txtPassword.Password != txtCPassword.Password)
            {
                MessageBox.Show("Bitte kontrollieren Sie das Password in den Beiden Felders", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            bool state = PasswordController.UpdatePassword(txtEmail.Text, txtPassword.Password);
            if (state)
            {
                MessageBox.Show("Ihr Password wurde wurde geändert\nSie können sich wieder im System anmelden", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                //txtEmail.Text = "";
                txtPassword.Password = "";
                txtCPassword.Password = "";
            }
            else
            {
                MessageBox.Show("Ein Fehler ist aufgetreten!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
