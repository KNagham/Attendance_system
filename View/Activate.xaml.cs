using Attendance_system.Controller;
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
    /// Interaktionslogik für Activate.xaml
    /// </summary>
    public partial class Activate : Window
    {
        public Activate()
        {
            InitializeComponent();
        }

        private void btnLogin(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private async void btnSendCode(object sender, RoutedEventArgs e)
        {
            if (!EmployeeController.EmailValidator(txtEmail.Text) || txtEmail.Text == string.Empty)
            {
                MessageBox.Show("Bitte geben Sie eine gültige E-Mail Adresse ein", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            EmployeeController employeeController = new EmployeeController();
            bool state = await employeeController.sendActivationCode(txtEmail.Text.ToLower());
            if (state)
            {
                txtEmail.IsEnabled = false;
                MessageBox.Show("Der Aktivierungscode wurde erfolgreich gesendet.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Eine Fehler ist aufgetreten\n versuchen Sie später.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void btnActivate(object sender, RoutedEventArgs e)
        {
            bool state = EmployeeController.ActivateEmployee(txtActivationCode.Text);
            if (state)
            {
                MessageBox.Show("Ihr Koto wurde aktiviert", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                txtActivationCode.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Bitte kontrollieren Sie den angegebenen Code", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
