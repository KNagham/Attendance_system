﻿#pragma checksum "..\..\..\..\View\EmployeeWorkingHour.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "DE74AD9C31F6E75999FC1DF24DB7B2AAABD44323"
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
    /// EmployeeWorkingHour
    /// </summary>
    public partial class EmployeeWorkingHour : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 105 "..\..\..\..\View\EmployeeWorkingHour.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbTask;
        
        #line default
        #line hidden
        
        
        #line 110 "..\..\..\..\View\EmployeeWorkingHour.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbProject;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\..\..\View\EmployeeWorkingHour.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker datePickerFrom;
        
        #line default
        #line hidden
        
        
        #line 128 "..\..\..\..\View\EmployeeWorkingHour.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker datePickerTo;
        
        #line default
        #line hidden
        
        
        #line 146 "..\..\..\..\View\EmployeeWorkingHour.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listViewWorkingHour;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.2.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Attendance_system;V1.0.0.0;component/view/employeeworkinghour.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\EmployeeWorkingHour.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.2.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 66 "..\..\..\..\View\EmployeeWorkingHour.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnDashboard);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 75 "..\..\..\..\View\EmployeeWorkingHour.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnWorkingHour);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 84 "..\..\..\..\View\EmployeeWorkingHour.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnAttendenceStatement);
            
            #line default
            #line hidden
            return;
            case 4:
            this.cbTask = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.cbProject = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.datePickerFrom = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 7:
            this.datePickerTo = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 8:
            
            #line 137 "..\..\..\..\View\EmployeeWorkingHour.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnClear);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 141 "..\..\..\..\View\EmployeeWorkingHour.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnOk);
            
            #line default
            #line hidden
            return;
            case 10:
            this.listViewWorkingHour = ((System.Windows.Controls.ListView)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.2.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 11:
            
            #line 237 "..\..\..\..\View\EmployeeWorkingHour.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnUpdate);
            
            #line default
            #line hidden
            break;
            case 12:
            
            #line 241 "..\..\..\..\View\EmployeeWorkingHour.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnDelete);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

