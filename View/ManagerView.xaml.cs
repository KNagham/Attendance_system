using Attendance_system.Controller;
using Attendance_system.Model;
using Attendance_system.Service;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
    public partial class ManagerView : Window
    {
        private Employee _currentEmployee = EmployeeService.GetCurrentEmployee();
        public ManagerView(Employee employee)
        {
            this._currentEmployee = employee;
            InitializeComponent();
            setCurrentDate();
            setGreeting();
            updateListView();
        }

        // show all Projects in List view
        private void updateListView()
        {
            listViewProject.ItemsSource = ProjectController.GetAllProjects();
        }

        private void setCurrentDate()
        {
            lblCurrentDate.Content = DateTime.Now.ToString("dddd, dd. MMMM yyyy");
        }
        private void setGreeting()
        {
            lblGreeting.Content = $"Hello {_currentEmployee.FirstName} {_currentEmployee.LastName}";
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

        private void btnWelcome(object sender, RoutedEventArgs e)
        {
            Welcome welcome = new Welcome(_currentEmployee);
            welcome.Show();
            this.Close();
        }

        private void btnProject(object sender, RoutedEventArgs e)
        {
            return;
        }

        private void btnTask(object sender, RoutedEventArgs e)
        {
            ManagerTask task = new ManagerTask();
            task.Show();
            this.Close();

        }

        private void btnEmployee(object sender, RoutedEventArgs e)
        {
            ManagerEmployee managerEmployee = new ManagerEmployee();
            managerEmployee.Show();
            this.Close();
        }

        
        private void btnAddProject(object sender, RoutedEventArgs e)
        {
        
            if (txtProjectName.Text == string.Empty)
            {
                MessageBox.Show("Please enter name of the project", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (IsActive.IsChecked == true && IsDone.IsChecked == true)
            {
                MessageBox.Show("A project can not be ‘Active’ and ‘Done’ at the same time.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
                MessageBox.Show("The project has been successfully added", "Success" ,MessageBoxButton.OK, MessageBoxImage.Information);
                clear();
                updateListView();
            }
            else
            {
                MessageBox.Show("Project exists", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void btnSearchProject(object sender, RoutedEventArgs e)
        {
        
            if(txtProjectId.Text == string.Empty && txtProjectName.Text == string.Empty)
            {
                MessageBox.Show("Please enter either (ID) or (name) of a project", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
                    MessageBox.Show($"Project with the ID: {txtProjectId.Text} was not found", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
                    MessageBox.Show($"Project with the name: {txtProjectName.Text} was not found", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    clear();
                }
            }

        }

        private void btnUpdateProject(object sender, RoutedEventArgs e)
        {
        
            if(txtProjectName.Text == string.Empty)
            {
                MessageBox.Show("Name of a project must not be empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Project project = new Project()
            {
                Id = int.Parse(txtProjectId.Text),
                Name = txtProjectName.Text,
                Description = txtProjectDescription.Text,
                IsActive = IsActive.IsChecked,
                IsDone = IsDone.IsChecked
            };
            
            bool result = ProjectController.UpdateProject(project);
            if (result)
            {
                MessageBox.Show($"The project {txtProjectName.Text} has been successfully updated", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                clear();
                updateListView();
                return;
            }
            else
            {
                MessageBox.Show("The project cannot currently be changed", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                clear();
                return;
            }

        }

        private void btnDeleteProject(object sender, RoutedEventArgs e)
        {
            if (txtProjectId.Text == string.Empty && txtProjectName.Text == string.Empty)
            {
                MessageBox.Show("Please enter either (ID) or (name) of a project", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MessageBoxResult result = MessageBox.Show( "Do you really want to Delete this element ?", "Delete", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.OK)
            {
                Project project = new Project()
                {
                    Id = int.Parse(txtProjectId.Text),
                    Name = txtProjectName.Text,
                    Description = txtProjectDescription.Text,
                    IsActive = IsActive.IsChecked,
                    IsDone = IsDone.IsChecked
                };
                bool state = ProjectController.DeleteProject(project);
                if (state)
                {
                    MessageBox.Show($"The project {txtProjectName.Text} has been removed", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    clear();
                    updateListView();
                    return;
                }
                else
                {
                    MessageBox.Show("The project cannot currently be removed", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    clear();
                    return;
                }
            }
        }
    }
}
