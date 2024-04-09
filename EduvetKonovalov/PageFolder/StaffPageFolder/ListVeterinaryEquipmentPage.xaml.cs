using EduvetKonovalov.ClassFolder;
using EduvetKonovalov.DataFolder;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EduvetKonovalov.PageFolder.StaffPageFolder
{
    /// <summary>
    /// Логика взаимодействия для ListVeterinaryEquipmentPage.xaml
    /// </summary>
    public partial class ListVeterinaryEquipmentPage : Page
    {
        public ListVeterinaryEquipmentPage()
        {
            InitializeComponent();
            string selected_dept = (App.Current as App).DeptName;

            VeterinaryEquipmentListB.ItemsSource = DBEntities.GetContext()
                .VeterinaryEquipment.ToList().OrderBy(v => v.NameVeterinaryEquipment);

            ListVeterinaryEquipmentDg.ItemsSource = DBEntities.GetContext()
                .VeterinaryEquipment.ToList().OrderBy(v => v.NameVeterinaryEquipment);

            try
            {
                VeterinaryEquipmentListB.ItemsSource = DataFolder.DBEntities.GetContext().
                    VeterinaryEquipment.Where
                    (v => v.Staff.User.LoginUser.StartsWith(selected_dept)).ToList();
                if (VeterinaryEquipmentListB.Items.Count <= 0)
                    MBClass.ErrorMB("У вас отсуствует оборудование!");

                ListVeterinaryEquipmentDg.ItemsSource = DataFolder.DBEntities.GetContext().
                    VeterinaryEquipment.Where
                    (v => v.Staff.User.LoginUser.StartsWith(selected_dept)).ToList();
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddVeterinaryEquipmentPage());
        }


        private void UpdateVeterinaryEquipmentMi_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ListVeterinaryEquipmentPage());
        }

        private void ExportBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ListVeterinaryEquipmentDg.SelectAllCells();
                int colCount = ListVeterinaryEquipmentDg.SelectedCells.Count;
                ListVeterinaryEquipmentDg.SelectedIndex = ListVeterinaryEquipmentDg.Items.Count - 1;
                int a = colCount / (ListVeterinaryEquipmentDg.SelectedIndex + 1);
                string selectedFileName = "Excel";
                ExportClass.ToExcelFile(ListVeterinaryEquipmentDg, selectedFileName, a);
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            string selected_dept = (App.Current as App).DeptName;
            try
            {
                VeterinaryEquipmentListB.ItemsSource = DataFolder.DBEntities.GetContext().
                    VeterinaryEquipment.Where
                    (v => (v.NameVeterinaryEquipment.StartsWith(SearchTb.Text) ||
                    v.TypeVeterinaryEquipment.NameTypeVeterinaryEquipment.
                    StartsWith(SearchTb.Text) ||
                    v.WhereDidItComeFrom.StartsWith(SearchTb.Text) ||
                    v.Staff.FullName.StartsWith(SearchTb.Text)) &&
                    v.Staff.User.LoginUser.StartsWith(selected_dept)).ToList();
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }
    }
}
