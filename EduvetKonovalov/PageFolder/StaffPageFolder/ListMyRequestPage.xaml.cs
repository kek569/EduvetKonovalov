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
    /// Логика взаимодействия для ListMyRequestPage.xaml
    /// </summary>
    public partial class ListMyRequestPage : Page
    {
        public ListMyRequestPage()
        {
            InitializeComponent();
            string selected_dept = (App.Current as App).DeptName;

            VeterinaryEquipmentListB.ItemsSource = DBEntities.GetContext()
                .RequestVeterinaryEquipment.ToList().OrderBy(v => v.IdRequestVeterinaryEquipment);

            ListVeterinaryEquipmentDg.ItemsSource = DBEntities.GetContext()
                .RequestVeterinaryEquipment.ToList().OrderBy(v => v.IdRequestVeterinaryEquipment);

            try
            {
                VeterinaryEquipmentListB.ItemsSource = DataFolder.DBEntities.GetContext().
                    RequestVeterinaryEquipment.Where
                    (v => v.Staff.User.LoginUser.StartsWith(selected_dept)).ToList();
                if (VeterinaryEquipmentListB.Items.Count <= 0)
                    MBClass.ErrorMB("У вас нет запросов");

                ListVeterinaryEquipmentDg.ItemsSource = DataFolder.DBEntities.GetContext().
                    RequestVeterinaryEquipment.Where
                    (v => v.Staff.User.LoginUser.StartsWith(selected_dept)).ToList();
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
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

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddVeterinaryEquipmentPage());
        }

        private void DeleteVeterinaryEquipmentfMi_Click(object sender, RoutedEventArgs e)
        {
            if (VeterinaryEquipmentListB.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите строку для удаления");
            }
            else
            {
                bool ret = MBClass.QestionMB("Вы действительно хотите " +
                    "удалить данную строку?");
                if (ret == true)
                {
                    VeterinaryEquipment veterinaryEquipment =
                        VeterinaryEquipmentListB.SelectedItem as
                        VeterinaryEquipment;
                    DBEntities.GetContext().VeterinaryEquipment.
                        Remove(veterinaryEquipment);
                    DBEntities.GetContext().SaveChanges();
                    MBClass.InfoMB("Данные успешно были удалены!");
                    NavigationService.Navigate(new ListVeterinaryEquipmentPage());
                }
            }
        }

        private void EditVeterinaryEquipmentfMi_Click(object sender, RoutedEventArgs e)
        {
            if (VeterinaryEquipmentListB.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите строку для редактирование");
            }
            else
            {
                VeterinaryEquipment veterinaryEquipment = VeterinaryEquipmentListB.
                    SelectedItem as VeterinaryEquipment;
                NavigationService.Navigate
                    (new EditVeterinaryEquipmentPage(VeterinaryEquipmentListB.
                    SelectedItem as RequestVeterinaryEquipment));
            }
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

        private void EditeMyRequestMi_Click(object sender, RoutedEventArgs e)
        {
            if (VeterinaryEquipmentListB.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите строку для редактирование");
            }
            else
            {
                RequestVeterinaryEquipment requestVeterinaryEquipment = VeterinaryEquipmentListB.
                    SelectedItem as RequestVeterinaryEquipment;
                NavigationService.Navigate
                    (new EditVeterinaryEquipmentPage(VeterinaryEquipmentListB.
                    SelectedItem as RequestVeterinaryEquipment));
            }
        }

        private void DeleteMyRequestMi_Click(object sender, RoutedEventArgs e)
        {
            if (VeterinaryEquipmentListB.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите строку для удаления");
            }
            else
            {
                bool ret = MBClass.QestionMB("Вы действительно хотите " +
                    "удалить данную строку?");
                if (ret == true)
                {
                    RequestVeterinaryEquipment requestVeterinaryEquipment =
                        VeterinaryEquipmentListB.SelectedItem as
                        RequestVeterinaryEquipment;
                    DBEntities.GetContext().RequestVeterinaryEquipment.
                        Remove(requestVeterinaryEquipment);
                    DBEntities.GetContext().SaveChanges();
                    MBClass.InfoMB("Данные успешно были удалены!");
                    NavigationService.Navigate(new ListMyRequestPage());
                }
            }
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            string selected_dept = (App.Current as App).DeptName;
            try
            {
                VeterinaryEquipmentListB.ItemsSource = DataFolder.DBEntities.GetContext().
                    RequestVeterinaryEquipment.Where
                    (v => (v.NameVeterinaryEquipment.StartsWith(SearchTb.Text) ||
                    v.TypeVeterinaryEquipment.NameTypeVeterinaryEquipment.
                    StartsWith(SearchTb.Text) ||
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
