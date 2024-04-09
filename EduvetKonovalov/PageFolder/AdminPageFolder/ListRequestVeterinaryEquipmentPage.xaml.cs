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

namespace EduvetKonovalov.PageFolder.AdminPageFolder
{
    /// <summary>
    /// Логика взаимодействия для ListRequestVeterinaryEquipmentPage.xaml
    /// </summary>
    public partial class ListRequestVeterinaryEquipmentPage : Page
    {
        public ListRequestVeterinaryEquipmentPage()
        {
            InitializeComponent();
            VeterinaryEquipmentListB.ItemsSource = DBEntities.GetContext()
                .RequestVeterinaryEquipment.ToList().OrderBy(v => v.IdRequestVeterinaryEquipment);

            ListVeterinaryEquipmentDg.ItemsSource = DBEntities.GetContext()
                .RequestVeterinaryEquipment.ToList().OrderBy(v => v.IdRequestVeterinaryEquipment);
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
                    RequestVeterinaryEquipment veterinaryEquipment =
                        VeterinaryEquipmentListB.SelectedItem as
                        RequestVeterinaryEquipment;
                    DBEntities.GetContext().RequestVeterinaryEquipment.
                        Remove(veterinaryEquipment);
                    DBEntities.GetContext().SaveChanges();
                    MBClass.InfoMB("Данные успешно были удалены!");
                    NavigationService.Navigate(new ListRequestVeterinaryEquipmentPage());
                }
            }
        }

        private void UpdateVeterinaryEquipmentMi_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ListRequestVeterinaryEquipmentPage());
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

        private void AddVeterinaryEquipmentMi_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddRequestVeterinaryEquipmentPage(VeterinaryEquipmentListB.
                    SelectedItem as RequestVeterinaryEquipment));
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
                    v.Staff.FullName.StartsWith(SearchTb.Text))).ToList();
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }
    }
}
