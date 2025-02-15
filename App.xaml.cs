using Attendance_system.DTO;
using Attendance_system.Service;
using Attendance_system.View;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Windows;

namespace Attendance_system
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static EmailService _emailService { get; private set; }
        private void App_Start(object sender, StartupEventArgs e)
        {
            try
            {
                // Konfiguration von json lesen und an EmailService weitergeben
                IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

                // Einstellungen aus appsettings.json in das Modell laden
                EmailSendSetting? emailSetting = config.GetSection("AccountSetting")
                    .Get<EmailSendSetting>();

                // EmailService mit geladenen Einstellungen initialisieren
                _emailService = new EmailService(emailSetting);
                // Dash start
                Login login = new Login();
                login.Show();
                /*EmployeeView employeeView = new EmployeeView();
                employeeView.Show();*/
                /*ManagerView managerView= new ManagerView();
                managerView.Show();*/
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler: {ex.Message}");
            }
        }
    }

}
