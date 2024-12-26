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
    /// Interaktionslogik für ManagerView.xaml
    /// </summary>
    public partial class ManagerView : Window
    {
        public ManagerView()
        {
            InitializeComponent();
            updateListView();
        }

        // show all Projects in List view
        private void updateListView()
        {
            listViewProject.ItemsSource = ProjectController.GetAllProjects();
        }

        // clear fields
        private void clear()
        {
            txtProjectId.Text = string.Empty;
            txtProjectName.Text = string.Empty;
            txtProjectDescription.Text = string.Empty;
            IsActive.IsChecked = false;
            IsDone.IsChecked = false;
        }

        private void cbProjectActive(object sender, RoutedEventArgs e)
        {

        }

        private void btnProject(object sender, RoutedEventArgs e)
        {

        }

        private void btnTask(object sender, RoutedEventArgs e)
        {

        }

        private void btnEmployee(object sender, RoutedEventArgs e)
        {

        }

        private void cbProjectDone(object sender, RoutedEventArgs e)
        {

        }

        private void cbProjectDelete(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddProject(object sender, RoutedEventArgs e)
        {
            if (txtProjectName.Text == string.Empty)
            {
                MessageBox.Show("Bitte geben Name des Projekts ein", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (IsActive.IsChecked == true && IsDone.IsChecked == true)
            {
                MessageBox.Show("Ein Projekt kann nicht gleichzeitig 'Active' und 'Done' sein.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Project project= new Project()
            {
                Name = txtProjectName.Text,
                Description = txtProjectDescription.Text,
                IsActive = IsActive.IsChecked,
                IsDone = IsDone.IsChecked,
            };

            bool state = ProjectController.AddProject(project);
            if (state)
            {
                MessageBox.Show("Project wurde hinzufügt", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                clear();
                updateListView();
            }
            else
            {
                MessageBox.Show("Project ist vorhanden", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void btnSearchProject(object sender, RoutedEventArgs e)
        {
            if(txtProjectId.Text == string.Empty && txtProjectName.Text == string.Empty)
            {
                MessageBox.Show("Bitte geben Sie entweder (ID) oder (Name) eines Projekt ein.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if(txtProjectId.Text != string.Empty)
            {
                Project? project = ProjectController.GetProject(int.Parse(txtProjectId.Text));
                if ( project != null)
                {
                    txtProjectName.Text = project.Name;
                    txtProjectDescription.Text = project.Description;
                    IsActive.IsChecked = project.IsActive;
                    IsDone.IsChecked = project.IsDone;
                }
                else
                {
                    MessageBox.Show($"Project mit der ID: {txtProjectId.Text} wurde nicht gefunden", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    clear();
                }
            }
            else if(txtProjectName.Text != string.Empty)
            {
                Project? project = ProjectController.GetProject(txtProjectName.Text);
                if (project != null)
                {
                    txtProjectId.Text = project.Id.ToString();
                    txtProjectDescription.Text = project.Description;
                    IsActive.IsChecked = project.IsActive;
                    IsDone.IsChecked = project.IsDone;
                }
                else
                {
                    MessageBox.Show($"Project mit der Name: {txtProjectName.Text} wurde nicht gefunden", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    clear();
                }
            }

        }

        private void btnUpdateProject(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeleteProject(object sender, RoutedEventArgs e)
        {

        }
    }
}
