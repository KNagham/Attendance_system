﻿#pragma checksum "..\..\..\..\View\ManagerTask.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0524DB96AE429CAEF73F77075DCC845A4F0881C0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Attendance_system.View;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Attendance_system.View {
    
    
    /// <summary>
    /// ManagerTask
    /// </summary>
    public partial class ManagerTask : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 55 "..\..\..\..\View\ManagerTask.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblGreeting;
        
        #line default
        #line hidden
        
        
        #line 108 "..\..\..\..\View\ManagerTask.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtTaskId;
        
        #line default
        #line hidden
        
        
        #line 117 "..\..\..\..\View\ManagerTask.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtTaskName;
        
        #line default
        #line hidden
        
        
        #line 125 "..\..\..\..\View\ManagerTask.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtTaskDescription;
        
        #line default
        #line hidden
        
        
        #line 133 "..\..\..\..\View\ManagerTask.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox IsActive;
        
        #line default
        #line hidden
        
        
        #line 140 "..\..\..\..\View\ManagerTask.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox IsDone;
        
        #line default
        #line hidden
        
        
        #line 163 "..\..\..\..\View\ManagerTask.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbPriority;
        
        #line default
        #line hidden
        
        
        #line 168 "..\..\..\..\View\ManagerTask.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbProject;
        
        #line default
        #line hidden
        
        
        #line 170 "..\..\..\..\View\ManagerTask.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listViewTask;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Attendance_system;component/view/managertask.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\ManagerTask.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.lblGreeting = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            
            #line 69 "..\..\..\..\View\ManagerTask.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnProject);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 78 "..\..\..\..\View\ManagerTask.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnTask);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 87 "..\..\..\..\View\ManagerTask.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnEmployee);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txtTaskId = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.txtTaskName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.txtTaskDescription = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.IsActive = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 9:
            this.IsDone = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 10:
            
            #line 143 "..\..\..\..\View\ManagerTask.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnAddTask);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 147 "..\..\..\..\View\ManagerTask.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnSearchTask);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 151 "..\..\..\..\View\ManagerTask.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnUpdateTask);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 155 "..\..\..\..\View\ManagerTask.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnDeleteTask);
            
            #line default
            #line hidden
            return;
            case 14:
            this.cbPriority = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 15:
            this.cbProject = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 16:
            this.listViewTask = ((System.Windows.Controls.ListView)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

