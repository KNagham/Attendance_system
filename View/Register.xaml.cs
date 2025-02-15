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
    /// Interaktionslogik für Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private void btnLogin(object sender, MouseButtonEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }
        
        private void btnRegister(object sender, RoutedEventArgs e)
        {
            
            if (txtFirstname.Text == string.Empty || txtLastname.Text == string.Empty || txtUsername.Text == string.Empty ||
                txtEmail.Text == string.Empty || txtPassword.Password == string.Empty)
            {
                MessageBox.Show("Bitte füllen Sie alle Felder aus ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!EmployeeController.EmailValidator(txtEmail.Text))
            {
                MessageBox.Show("Bitte geben Sie eine gültige E-Mail Adresse ein", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
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

            Employee employee = new Employee()
            {
                FirstName = txtFirstname.Text,
                LastName = txtLastname.Text,
                UserName = txtUsername.Text,
                Email = txtEmail.Text.ToLower(),
                ActivationCode = "",
                Confirmed = false
            };
            Password password = new Password() { PasswordKey = PasswordController.ComputeSHA256(txtPassword.Password) };

            bool state = EmployeeController.AddEmployee(employee, password);
            if (state)
            {
                MessageBox.Show("Benutzer wurde registiert\n Klicken Sie auf Activate und den Code eingeben", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                txtFirstname.Text = "";
                txtLastname.Text = "";
                txtUsername.Text = "";
                txtEmail.Text = "";
                txtPassword.Password = "";
                txtCPassword.Password = "";
            }
            else
            {
                MessageBox.Show("Email ist vorhanden", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnActivate(object sender, RoutedEventArgs e)
        {
            Activate activate = new Activate();
            activate.Show();
            this.Close();
        }
    }
}
