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
    /// Interaktionslogik für ManagerTask.xaml
    /// </summary>
    public partial class ManagerTask : Window
    {
        public ManagerTask()
        {
            InitializeComponent();
            updateListView();
            cbProject.ItemsSource = TaskController.GetAllProjects();
            loadPriority();
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
            EmployeeView employeeView = new EmployeeView();
            employeeView.Show();
            this.Close();
        }

        private void btnAddTask(object sender, RoutedEventArgs e)
        {
            if (txtTaskName.Text == string.Empty)
            {
                MessageBox.Show("Bitte geben Name des Task ein", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (IsActive.IsChecked == true && IsDone.IsChecked == true)
            {
                MessageBox.Show("Ein Task kann nicht gleichzeitig 'Active' und 'Done' sein.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
                MessageBox.Show("Das Task wurde hinzufügt", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                clear();
                updateListView();
                return;
            }
            else
            {
                MessageBox.Show("Das Task kann aktuell nicht hinzufügt werden !", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void btnSearchTask(object sender, RoutedEventArgs e)
        {
            if (txtTaskId.Text == string.Empty && txtTaskName.Text == string.Empty)
            {
                MessageBox.Show("Bitte geben Sie entweder (ID) oder (Name) eines Task ein.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
                    MessageBox.Show($"Task mit der ID: {txtTaskId.Text} wurde nicht gefunden", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
                    MessageBox.Show($"Task mit der Name: {txtTaskName.Text} wurde nicht gefunden", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    clear();
                    return;
                }
            }
        }
        private void btnUpdateTask(object sender, RoutedEventArgs e)
        {
            if (txtTaskName.Text == string.Empty)
            {
                MessageBox.Show("Name eines Task darf nicht leer sein.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
                MessageBox.Show($"Das Task {txtTaskName.Text} wurde erfolgreich aktualisiert", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                clear();
                updateListView();
                return;
            }
            else
            {
                MessageBox.Show($"Das Task kann aktuell nicht geändert werden", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                clear();
                return;
            }

        }

        private void btnDeleteTask(object sender, RoutedEventArgs e)
        {
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
                    MessageBox.Show($"Das Task {txtTaskName.Text} wurde entfernt", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    clear();
                    updateListView();
                    return;
                }
                else
                {
                    MessageBox.Show($"Das Task kann aktuell nicht entfernt werden", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    clear();
                    return;
                }
            }

        }
    }
}
