﻿#pragma checksum "..\..\..\..\View\ManagerView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "C75E10473DB17225DEAC063208997C6398F929D9"
//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
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
    /// ManagerView
    /// </summary>
    public partial class ManagerView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 55 "..\..\..\..\View\ManagerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblGreeting;
        
        #line default
        #line hidden
        
        
        #line 108 "..\..\..\..\View\ManagerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtProjectId;
        
        #line default
        #line hidden
        
        
        #line 117 "..\..\..\..\View\ManagerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtProjectName;
        
        #line default
        #line hidden
        
        
        #line 125 "..\..\..\..\View\ManagerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtProjectDescription;
        
        #line default
        #line hidden
        
        
        #line 133 "..\..\..\..\View\ManagerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox IsActive;
        
        #line default
        #line hidden
        
        
        #line 140 "..\..\..\..\View\ManagerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox IsDone;
        
        #line default
        #line hidden
        
        
        #line 160 "..\..\..\..\View\ManagerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listViewProject;
        
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
            System.Uri resourceLocater = new System.Uri("/Attendance_system;component/view/managerview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\ManagerView.xaml"
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
            
            #line 69 "..\..\..\..\View\ManagerView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnProject);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 78 "..\..\..\..\View\ManagerView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnTask);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 87 "..\..\..\..\View\ManagerView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnEmployee);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txtProjectId = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.txtProjectName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.txtProjectDescription = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.IsActive = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 9:
            this.IsDone = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 10:
            
            #line 143 "..\..\..\..\View\ManagerView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnAddProject);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 147 "..\..\..\..\View\ManagerView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnSearchProject);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 151 "..\..\..\..\View\ManagerView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnUpdateProject);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 155 "..\..\..\..\View\ManagerView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnDeleteProject);
            
            #line default
            #line hidden
            return;
            case 14:
            this.listViewProject = ((System.Windows.Controls.ListView)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

