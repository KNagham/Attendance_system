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
    /// Interaktionslogik für ManagerTask.xaml
    /// </summary>
    public partial class ManagerTask : Window
    {
        public ManagerTask()
        {
            InitializeComponent();
        }

        private void btnProject(object sender, RoutedEventArgs e)
        {
            ManagerView project = new ManagerView();
            project.Show();
            this.Close();
        }

        private void btnTask(object sender, RoutedEventArgs e)
        {
            

        }

        private void btnEmployee(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddTask(object sender, RoutedEventArgs e)
        {

        }

        private void btnSearchTask(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdateTask(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeleteTask(object sender, RoutedEventArgs e)
        {

        }
    }
}
