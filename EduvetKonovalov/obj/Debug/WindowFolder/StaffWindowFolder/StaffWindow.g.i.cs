﻿#pragma checksum "..\..\..\..\WindowFolder\StaffWindowFolder\StaffWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "50AB2FF3BECE602BB3133E2D7566FB0DE4D36951A1FA4BF5E440413F3BD8402B"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using EduvetKonovalov.WindowFolder.StaffWindowFolder;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace EduvetKonovalov.WindowFolder.StaffWindowFolder {
    
    
    /// <summary>
    /// StaffWindow
    /// </summary>
    public partial class StaffWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 37 "..\..\..\..\WindowFolder\StaffWindowFolder\StaffWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image CloseIm;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\WindowFolder\StaffWindowFolder\StaffWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image LogoIm;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\..\WindowFolder\StaffWindowFolder\StaffWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ListVeterinaryEquipmentBtn;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\..\WindowFolder\StaffWindowFolder\StaffWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ListProfileBtn;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\..\WindowFolder\StaffWindowFolder\StaffWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ListMyRequestBtn;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\..\..\WindowFolder\StaffWindowFolder\StaffWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BackBtn;
        
        #line default
        #line hidden
        
        
        #line 113 "..\..\..\..\WindowFolder\StaffWindowFolder\StaffWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame MainFrame;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/EduvetKonovalov;component/windowfolder/staffwindowfolder/staffwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\WindowFolder\StaffWindowFolder\StaffWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 19 "..\..\..\..\WindowFolder\StaffWindowFolder\StaffWindow.xaml"
            ((System.Windows.Controls.Border)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Border_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.CloseIm = ((System.Windows.Controls.Image)(target));
            
            #line 40 "..\..\..\..\WindowFolder\StaffWindowFolder\StaffWindow.xaml"
            this.CloseIm.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.CloseIm_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.LogoIm = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            this.ListVeterinaryEquipmentBtn = ((System.Windows.Controls.Button)(target));
            
            #line 68 "..\..\..\..\WindowFolder\StaffWindowFolder\StaffWindow.xaml"
            this.ListVeterinaryEquipmentBtn.Click += new System.Windows.RoutedEventHandler(this.ListVeterinaryEquipmentBtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ListProfileBtn = ((System.Windows.Controls.Button)(target));
            
            #line 74 "..\..\..\..\WindowFolder\StaffWindowFolder\StaffWindow.xaml"
            this.ListProfileBtn.Click += new System.Windows.RoutedEventHandler(this.ListProfileBtn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ListMyRequestBtn = ((System.Windows.Controls.Button)(target));
            
            #line 80 "..\..\..\..\WindowFolder\StaffWindowFolder\StaffWindow.xaml"
            this.ListMyRequestBtn.Click += new System.Windows.RoutedEventHandler(this.ListMyRequestBtn_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.BackBtn = ((System.Windows.Controls.Button)(target));
            
            #line 98 "..\..\..\..\WindowFolder\StaffWindowFolder\StaffWindow.xaml"
            this.BackBtn.Click += new System.Windows.RoutedEventHandler(this.BackBtn_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.MainFrame = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

