﻿using Attendance_system.Controller;
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
using System.Windows.Threading;

namespace Attendance_system.View
{
    /// <summary>
    /// Interaktionslogik für EmployeeView.xaml
    /// </summary>
    public partial class EmployeeView : Window
    {
        private DispatcherTimer _timer;
        private TimeSpan _elapsedTime;
        private TimeSpan _pausedTime;
        private bool _isRunning;
        private bool _inBreak;
        private Employee _currentEmployee;
        private EmployeeProject _currentEmployeeProject;

        public EmployeeView(Employee employee)
        {
            this._currentEmployee = employee;
            InitializeComponent();
            setGreeting();
            setCurrentDate();
            disabled(true);
            InitializeTimer();

        }
        // muss deleted
       /*
        public EmployeeView()
        {
            InitializeComponent();
            setCurrentDate();
            disabled(true);
            InitializeTimer();

        }*/

        private void InitializeTimer()
        {
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += Timer_Tick;
            lblTimer.Content = "00:00:00";
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            _elapsedTime = _elapsedTime.Add(TimeSpan.FromSeconds(1));
            lblTimer.Content = _elapsedTime.ToString(@"hh\:mm\:ss");
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

        private void btnCheckInClick(object sender, RoutedEventArgs e)
        {
            disabled(false);
            btnStop.IsEnabled = false;
            btnResume.IsEnabled = false;
            btnPause.IsEnabled = false;
            cbProject.ItemsSource = TaskController.GetAllProjects();
            cbTask.ItemsSource = TaskController.GetAllTasks();

        }

        private void btnCheckOutClick(object sender, RoutedEventArgs e)
        {
            disabled(true);

        }

        private void btnStartClick(object sender, RoutedEventArgs e)
        {
            if(cbProject.SelectedIndex == -1 || cbTask.SelectedIndex == -1)
            {
                MessageBox.Show("Bitte wählen Sie Projekt und Task zuerst aus!!", "Warnung", MessageBoxButton.OK, MessageBoxImage.Hand);
                return;
            }
            if(!_isRunning)
            {
                _isRunning = true;
                _timer.Start();
                btnStart.IsEnabled = false;
                btnCheckOut.IsEnabled = false;
                btnStop.IsEnabled = true;
                btnResume.IsEnabled = false;
                btnPause.IsEnabled = true;
                cbProject.IsEnabled = false;
                cbTask.IsEnabled = false;
            }
        }
        private void btnStopClick(object sender, RoutedEventArgs e)
        {
            if(!_isRunning || !_inBreak)
            {
                _isRunning = false;
                _timer.Stop();
                saveWorkingTime();
                disabled(true);
            }
            _inBreak = true;
            btnStop.IsEnabled = false;
            btnCheckOut.IsEnabled = true;
            lblTimer.Content = "00:00:00";
            _elapsedTime = TimeSpan.Zero;
            _pausedTime = TimeSpan.Zero;
            cbProject.IsEnabled = true;
            cbTask.IsEnabled = true;
        }

        private async void saveWorkingTime()
        {
            try
            {
                if(_currentEmployeeProject == null)
                {
                    _currentEmployeeProject = new EmployeeProject
                    {
                        EmployeeId = _currentEmployee.Id,
                        ProjectId = (int)cbProject.SelectedValue,
                        TaskId = (int)cbTask.SelectedValue,
                        WorkingTime =Math.Round(_inBreak ? _pausedTime.TotalMinutes : _elapsedTime.TotalMinutes,2),
                        Note = txtEmployeeTaskNote.Text,
                    };
                }
                else
                {
                    if(!_inBreak)
                    {
                        _currentEmployeeProject.WorkingTime += Math.Round(_elapsedTime .TotalMinutes, 2);
                    }
                    _currentEmployeeProject.Note = txtEmployeeTaskNote.Text;
                }
                await EmployeeProjectController.SaveWorkingTime(_currentEmployeeProject);
                MessageBox.Show("Arbeitszeit wurde gespeichert.\nSchönen Tag", "Erfolg", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Speichern!!", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void savePausedTime()
        {
            try
            {
                if(_currentEmployeeProject == null)
                {
                    _currentEmployeeProject = new EmployeeProject
                    {
                        EmployeeId = _currentEmployee.Id,
                        ProjectId = (int)cbProject.SelectedValue,
                        TaskId = (int)cbTask.SelectedValue,
                        WorkingTime = _pausedTime.TotalMinutes,
                        Note = txtEmployeeTaskNote.Text,
                    };
                }
                else
                {
                    _currentEmployeeProject.WorkingTime = Math.Round(_pausedTime.TotalMinutes, 2);
                    _currentEmployeeProject.Note = txtEmployeeTaskNote.Text;
                }
                await EmployeeProjectController.SaveWorkingTime(_currentEmployeeProject);
                MessageBox.Show("Arbeitszeit wurde zwischen gespeichert\nMahlzeit.", "Informationen", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim zwischenspeichern!!", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void btnPauseClick(object sender, RoutedEventArgs e)
        {
            if(_isRunning)
            {
                _isRunning = false;
                _timer.Stop();
                _pausedTime = _elapsedTime;
                _inBreak = true;
                savePausedTime();
                btnPause.IsEnabled = false;
                btnResume.IsEnabled = true;
                btnStop.IsEnabled = true;
                btnStart.IsEnabled = false;
                cbProject.IsEnabled = false;
                cbTask.IsEnabled = false;
            }
        }

        private void btnResumeClick(object sender, RoutedEventArgs e)
        {
            if(!_isRunning)
            {
                _isRunning = true;
                _timer.Start();   
                _inBreak= false;
                btnResume.IsEnabled = false;
                btnStop.IsEnabled = true;
                btnStart.IsEnabled = false;
                btnPause.IsEnabled = true;
                cbProject.IsEnabled = false;
                cbTask.IsEnabled = false;
            }
        }

       
        private void disabled(bool state)
        {
            if (state)
            {
                cbProject.SelectedIndex = -1;
                cbTask.SelectedIndex = -1;
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
