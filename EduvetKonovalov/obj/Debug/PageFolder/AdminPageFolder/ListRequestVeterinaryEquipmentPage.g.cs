﻿#pragma checksum "..\..\..\..\PageFolder\AdminPageFolder\ListRequestVeterinaryEquipmentPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "270102A44162DDF6893977A63D7B8078305020989DD24546655E5051C1BF305A"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using EduvetKonovalov.PageFolder.AdminPageFolder;
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


namespace EduvetKonovalov.PageFolder.AdminPageFolder {
    
    
    /// <summary>
    /// ListRequestVeterinaryEquipmentPage
    /// </summary>
    public partial class ListRequestVeterinaryEquipmentPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\..\..\PageFolder\AdminPageFolder\ListRequestVeterinaryEquipmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchTb;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\PageFolder\AdminPageFolder\ListRequestVeterinaryEquipmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ExportBtn;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\PageFolder\AdminPageFolder\ListRequestVeterinaryEquipmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid ListVeterinaryEquipmentDg;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\..\PageFolder\AdminPageFolder\ListRequestVeterinaryEquipmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox VeterinaryEquipmentListB;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\..\PageFolder\AdminPageFolder\ListRequestVeterinaryEquipmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem AddVeterinaryEquipmentMi;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\..\PageFolder\AdminPageFolder\ListRequestVeterinaryEquipmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem DeleteVeterinaryEquipmentfMi;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\..\PageFolder\AdminPageFolder\ListRequestVeterinaryEquipmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem UpdateVeterinaryEquipmentMi;
        
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
            System.Uri resourceLocater = new System.Uri("/EduvetKonovalov;component/pagefolder/adminpagefolder/listrequestveterinaryequipm" +
                    "entpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\PageFolder\AdminPageFolder\ListRequestVeterinaryEquipmentPage.xaml"
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
            this.SearchTb = ((System.Windows.Controls.TextBox)(target));
            
            #line 30 "..\..\..\..\PageFolder\AdminPageFolder\ListRequestVeterinaryEquipmentPage.xaml"
            this.SearchTb.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.SearchTb_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ExportBtn = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\..\..\PageFolder\AdminPageFolder\ListRequestVeterinaryEquipmentPage.xaml"
            this.ExportBtn.Click += new System.Windows.RoutedEventHandler(this.ExportBtn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ListVeterinaryEquipmentDg = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 4:
            this.VeterinaryEquipmentListB = ((System.Windows.Controls.ListBox)(target));
            return;
            case 5:
            this.AddVeterinaryEquipmentMi = ((System.Windows.Controls.MenuItem)(target));
            
            #line 75 "..\..\..\..\PageFolder\AdminPageFolder\ListRequestVeterinaryEquipmentPage.xaml"
            this.AddVeterinaryEquipmentMi.Click += new System.Windows.RoutedEventHandler(this.AddVeterinaryEquipmentMi_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.DeleteVeterinaryEquipmentfMi = ((System.Windows.Controls.MenuItem)(target));
            
            #line 78 "..\..\..\..\PageFolder\AdminPageFolder\ListRequestVeterinaryEquipmentPage.xaml"
            this.DeleteVeterinaryEquipmentfMi.Click += new System.Windows.RoutedEventHandler(this.DeleteVeterinaryEquipmentfMi_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.UpdateVeterinaryEquipmentMi = ((System.Windows.Controls.MenuItem)(target));
            
            #line 81 "..\..\..\..\PageFolder\AdminPageFolder\ListRequestVeterinaryEquipmentPage.xaml"
            this.UpdateVeterinaryEquipmentMi.Click += new System.Windows.RoutedEventHandler(this.UpdateVeterinaryEquipmentMi_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
