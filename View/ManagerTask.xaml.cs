using Attendance_system.Controller;
using Attendance_system.Model;
using Attendance_system.Service;
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
    public partial class ManagerTask : Window
    {
        private Employee _currentEmployee = EmployeeService.GetCurrentEmployee();
        public ManagerTask()
        {
            InitializeComponent();
            setGreeting();
            updateListView();
            cbProject.ItemsSource = TaskController.GetAllProjects();
            loadPriority();
        }

        private void setGreeting()
        {
            lblGreeting.Content = $"Hello {_currentEmployee.FirstName} {_currentEmployee.LastName}";
        }

        // priority load
        private void loadPriority()
        {
            List<string> priorities = new List<string> { "Priority 1", "Priority 2", "Priority 3" };
            cbPriority.ItemsSource = priorities;
        }

        // show all Tasks in List view
        private void updateListView()
        {
            listViewTask.ItemsSource = TaskController.GetAllTasks();
        }

        // clear fields
        private void clear()
        {
            txtTaskId.Text = string.Empty;
            txtTaskName.Text = string.Empty;
            txtTaskDescription.Text = string.Empty;
            IsActive.IsChecked = false;
            IsDone.IsChecked = false;
            cbProject.SelectedIndex = -1;
            cbPriority.SelectedIndex = -1;
        }

        private void btnWelcome(object sender, RoutedEventArgs e)
        {
            Welcome welcome = new Welcome(_currentEmployee);
            welcome.Show();
            this.Close();
        }
        private void btnProject(object sender, RoutedEventArgs e)
        {
            ManagerView project = new ManagerView(_currentEmployee);
            project.Show();
            this.Close();
        }

        private void btnTask(object sender, RoutedEventArgs e)
        {
            return;
        }

        private void btnEmployee(object sender, RoutedEventArgs e)
        {
            ManagerEmployee managerEmployee = new ManagerEmployee();
            managerEmployee.Show();
            this.Close();
        }

        private void btnAddTask(object sender, RoutedEventArgs e)
        {
            if (txtTaskName.Text == string.Empty)
            {
                MessageBox.Show("Please enter name of the task", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (IsActive.IsChecked == true && IsDone.IsChecked == true)
            {
                MessageBox.Show("A task cannot be ‘Active’ and ‘Done’ at the same time.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Model.Task task = new Model.Task()
            {
                Name = txtTaskName.Text,
                Description = txtTaskDescription.Text,
                IsActive = IsActive.IsChecked,
                IsDone = IsDone.IsChecked,
                ProjectId = (int)cbProject.SelectedValue,
                Priority = cbPriority.SelectedItem.ToString(),
            };
            if(task != null)
            {
                TaskController.AddTask(task);
                MessageBox.Show("The task has been successfully added", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                clear();
                updateListView();
                return;
            }
            else
            {
                MessageBox.Show("The task cannot currently be added", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void btnSearchTask(object sender, RoutedEventArgs e)
        {
            if (txtTaskId.Text == string.Empty && txtTaskName.Text == string.Empty)
            {
                MessageBox.Show("Please enter either (ID) or (name) of a task.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (txtTaskId.Text != string.Empty)
            {
                Model.Task? task = TaskController.GetTask(int.Parse(txtTaskId.Text));
                if (task != null)
                {
                    txtTaskName.Text = task.Name;
                    txtTaskDescription.Text = task.Description;
                    IsActive.IsChecked = task.IsActive;
                    IsDone.IsChecked = task.IsDone;
                    cbPriority.SelectedItem = task.Priority;
                    cbProject.SelectedValue = task.ProjectId;
                    return;
                }
                else
                {
                    MessageBox.Show($"Task with ID: {txtTaskId.Text} was not found", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    clear();
                    return;
                }
            }
            else if (txtTaskName.Text != string.Empty)
            {
                Model.Task? task= TaskController.GetTask(txtTaskName.Text);
                if (task!= null)
                {
                    txtTaskId.Text = task.Id.ToString();
                    txtTaskDescription.Text = task.Description;
                    IsActive.IsChecked = task.IsActive;
                    IsDone.IsChecked = task.IsDone;
                    cbPriority.SelectedItem = task.Priority;
                    cbProject.SelectedValue = task.ProjectId;
                    return;
                }
                else
                {
                    MessageBox.Show($"Task with the name: {txtTaskName.Text} was not found", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    clear();
                    return;
                }
            }
        }
        private void btnUpdateTask(object sender, RoutedEventArgs e)
        {
            if (txtTaskName.Text == string.Empty)
            {
                MessageBox.Show("The name of a task must not be empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Model.Task task = new Model.Task()
            {
                Id = int.Parse(txtTaskId.Text),
                Name = txtTaskName.Text,
                Description = txtTaskDescription.Text,
                IsActive = IsActive.IsChecked,
                IsDone = IsDone.IsChecked,
                Priority = (string)cbPriority.SelectedItem,
                ProjectId = (int)cbProject.SelectedValue
                
            };

            bool result = TaskController.UpdateTask(task);
            if (result)
            {
                MessageBox.Show($"The task {txtTaskName.Text} has been successfully updated", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                clear();
                updateListView();
                return;
            }
            else
            {
                MessageBox.Show("The task cannot currently be changed", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                clear();
                return;
            }

        }

        private void btnDeleteTask(object sender, RoutedEventArgs e)
        {
            if (txtTaskId.Text == string.Empty && txtTaskName.Text == string.Empty)
            {
                MessageBox.Show("Please enter either (ID) or (name) of a task.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MessageBoxResult result = MessageBox.Show("Do you really want to Delete this element ?", "Delete", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.OK)
            {
                Model.Task task = new Model.Task()
                {
                    Id = int.Parse(txtTaskId.Text),
                    Name = txtTaskName.Text,
                    Description = txtTaskDescription.Text,
                    IsActive = IsActive.IsChecked,
                    IsDone = IsDone.IsChecked,
                    Priority = (string)cbPriority.SelectedItem,
                    ProjectId = (int)cbProject.SelectedValue
                };
                bool state = TaskController.DeleteTask(task);
                if (state)
                {
                    MessageBox.Show($"The task {txtTaskName.Text} has been removed", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    clear();
                    updateListView();
                    return;
                }
                else
                {
                    MessageBox.Show($"The task can not currently be removed", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    clear();
                    return;
                }
            }

        }
    }
}
