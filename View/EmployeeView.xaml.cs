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
    /// Interaktionslogik für EmployeeView.xaml
    /// </summary>
    public partial class EmployeeView : Window
    {
        private Employee _currentEmployee;

        /*public EmployeeView(Employee employee)
        {
            this._currentEmployee = employee;
            InitializeComponent();

            setGreeting();

        }*/
        // muss deleted
        public EmployeeView()
        {
            InitializeComponent();
            setCurrentDate();
            disabled(true);


        }

        private void setCurrentDate()
        {
            lblCurrentDate.Content = DateTime.Now.ToString("dddd, dd. MMMM yyyy");
        }

        private void setGreeting()
        {
            lblGreeting.Content = $"Hello {_currentEmployee.FirstName} {_currentEmployee.LastName}";
        }

        private void btnDashboard(object sender, RoutedEventArgs e)
        {

        }

        private void btnWorkingHour(object sender, RoutedEventArgs e)
        {

        }

        private void btnAttendenceStatement(object sender, RoutedEventArgs e)
        {

        }

        private void btnCheckIn(object sender, RoutedEventArgs e)
        {
            disabled(false);

        }

        private void btnCheckOut(object sender, RoutedEventArgs e)
        {
            disabled(true);

        }

        private void btnStartClick(object sender, RoutedEventArgs e)
        {

        }

        private void btnPauseClick(object sender, RoutedEventArgs e)
        {

        }

        private void btnResumeClick(object sender, RoutedEventArgs e)
        {

        }

        private void btnStopClick(object sender, RoutedEventArgs e)
        {

        }
        private void disabled(bool state)
        {
            if (state)
            {
                cbProject.IsEnabled = false;
                cbTask.IsEnabled = false;
                btnStart.IsEnabled = false;
                btnStop.IsEnabled = false;
                btnResume.IsEnabled = false;
                btnPause.IsEnabled = false;
                txtEmployeeTaskNote.IsEnabled = false;
            }
            else
            {
                cbProject.IsEnabled = true;
                cbTask.IsEnabled = true;
                btnStart.IsEnabled = true;
                btnStop.IsEnabled = true;
                btnResume.IsEnabled = true;
                btnPause.IsEnabled = true;
                txtEmployeeTaskNote.IsEnabled = true;
            }
        }

    }
}
