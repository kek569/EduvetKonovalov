// Updated by XamlIntelliSenseFileGenerator 05.04.2024 10:56:11
#pragma checksum "..\..\..\..\PageFolder\AdminPageFolder\ListVeterinaryEquipmentPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "DA9A0404EEBE7D30E16AF9194FB7EF1B6D1DEB7247186174A764EB5C3948D7DC"
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


namespace EduvetKonovalov.PageFolder.AdminPageFolder
{


    /// <summary>
    /// ListVeterinaryEquipmentPage
    /// </summary>
    public partial class ListVeterinaryEquipmentPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector
    {


#line 28 "..\..\..\..\PageFolder\AdminPageFolder\ListVeterinaryEquipmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchTb;

#line default
#line hidden


#line 34 "..\..\..\..\PageFolder\AdminPageFolder\ListVeterinaryEquipmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SearchBtn;

#line default
#line hidden


#line 38 "..\..\..\..\PageFolder\AdminPageFolder\ListVeterinaryEquipmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ExportBtn;

#line default
#line hidden


#line 43 "..\..\..\..\PageFolder\AdminPageFolder\ListVeterinaryEquipmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddBtn;

#line default
#line hidden


#line 48 "..\..\..\..\PageFolder\AdminPageFolder\ListVeterinaryEquipmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid ListVeterinaryEquipmentDg;

#line default
#line hidden


#line 89 "..\..\..\..\PageFolder\AdminPageFolder\ListVeterinaryEquipmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox VeterinaryEquipmentListB;

#line default
#line hidden


#line 100 "..\..\..\..\PageFolder\AdminPageFolder\ListVeterinaryEquipmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem EditVeterinaryEquipmentfMi;

#line default
#line hidden


#line 103 "..\..\..\..\PageFolder\AdminPageFolder\ListVeterinaryEquipmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem DeleteVeterinaryEquipmentfMi;

#line default
#line hidden


#line 106 "..\..\..\..\PageFolder\AdminPageFolder\ListVeterinaryEquipmentPage.xaml"
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
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/EduvetKonovalov;component/pagefolder/adminpagefolder/listveterinaryequipmentpage" +
                    ".xaml", System.UriKind.Relative);

#line 1 "..\..\..\..\PageFolder\AdminPageFolder\ListVeterinaryEquipmentPage.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.SearchTb = ((System.Windows.Controls.TextBox)(target));

#line 31 "..\..\..\..\PageFolder\AdminPageFolder\ListVeterinaryEquipmentPage.xaml"
                    this.SearchTb.AddHandler(System.Windows.Input.Keyboard.KeyDownEvent, new System.Windows.Input.KeyEventHandler(this.SearchTb_KeyDown));

#line default
#line hidden

#line 32 "..\..\..\..\PageFolder\AdminPageFolder\ListVeterinaryEquipmentPage.xaml"
                    this.SearchTb.AddHandler(System.Windows.Input.Keyboard.KeyUpEvent, new System.Windows.Input.KeyEventHandler(this.SearchTb_KeyUp));

#line default
#line hidden
                    return;
                case 2:
                    this.SearchBtn = ((System.Windows.Controls.Button)(target));

#line 37 "..\..\..\..\PageFolder\AdminPageFolder\ListVeterinaryEquipmentPage.xaml"
                    this.SearchBtn.Click += new System.Windows.RoutedEventHandler(this.SearchBtn_Click);

#line default
#line hidden
                    return;
                case 3:
                    this.ExportBtn = ((System.Windows.Controls.Button)(target));

#line 41 "..\..\..\..\PageFolder\AdminPageFolder\ListVeterinaryEquipmentPage.xaml"
                    this.ExportBtn.Click += new System.Windows.RoutedEventHandler(this.ExportBtn_Click);

#line default
#line hidden
                    return;
                case 4:
                    this.AddBtn = ((System.Windows.Controls.Button)(target));

#line 46 "..\..\..\..\PageFolder\AdminPageFolder\ListVeterinaryEquipmentPage.xaml"
                    this.AddBtn.Click += new System.Windows.RoutedEventHandler(this.AddBtn_Click);

#line default
#line hidden
                    return;
                case 5:
                    this.ListVeterinaryEquipmentDg = ((System.Windows.Controls.DataGrid)(target));
                    return;
                case 6:
                    this.VeterinaryEquipmentListB = ((System.Windows.Controls.ListBox)(target));
                    return;
                case 7:
                    this.EditVeterinaryEquipmentfMi = ((System.Windows.Controls.MenuItem)(target));

#line 101 "..\..\..\..\PageFolder\AdminPageFolder\ListVeterinaryEquipmentPage.xaml"
                    this.EditVeterinaryEquipmentfMi.Click += new System.Windows.RoutedEventHandler(this.EditVeterinaryEquipmentfMi_Click);

#line default
#line hidden
                    return;
                case 8:
                    this.DeleteVeterinaryEquipmentfMi = ((System.Windows.Controls.MenuItem)(target));

#line 104 "..\..\..\..\PageFolder\AdminPageFolder\ListVeterinaryEquipmentPage.xaml"
                    this.DeleteVeterinaryEquipmentfMi.Click += new System.Windows.RoutedEventHandler(this.DeleteVeterinaryEquipmentfMi_Click);

#line default
#line hidden
                    return;
                case 9:
                    this.UpdateVeterinaryEquipmentMi = ((System.Windows.Controls.MenuItem)(target));

#line 107 "..\..\..\..\PageFolder\AdminPageFolder\ListVeterinaryEquipmentPage.xaml"
                    this.UpdateVeterinaryEquipmentMi.Click += new System.Windows.RoutedEventHandler(this.UpdateVeterinaryEquipmentMi_Click);

#line default
#line hidden
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Controls.MenuItem ViewProviderMi;
    }
}

