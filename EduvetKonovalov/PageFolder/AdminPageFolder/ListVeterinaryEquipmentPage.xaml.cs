using EduvetKonovalov.ClassFolder;
using EduvetKonovalov.DataFolder;
using EduvetKonovalov.PageFolder.StaffPageFolder;
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
    /// Логика взаимодействия для ListVeterinaryEquipmentPage.xaml
    /// </summary>
    public partial class ListVeterinaryEquipmentPage : Page
    {
        public ListVeterinaryEquipmentPage()
        {
            InitializeComponent();
            VeterinaryEquipmentListB.ItemsSource = DBEntities.GetContext()
                .VeterinaryEquipment.ToList().OrderBy(v => v.NameVeterinaryEquipment);

            ListVeterinaryEquipmentDg.ItemsSource = DBEntities.GetContext()
                .VeterinaryEquipment.ToList().OrderBy(v => v.NameVeterinaryEquipment);
        }

        private void SearchTb_KeyDown(object sender, KeyEventArgs e)
        {
            if (SearchTb.Text == "Поиск")
            {
                SearchTb.Text = "";
            }
        }

        private void SearchTb_KeyUp(object sender, KeyEventArgs e)
        {
            if (SearchTb.Text == "")
            {
                SearchTb.Text = "Поиск";
            }
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                VeterinaryEquipmentListB.ItemsSource = DataFolder.DBEntities.GetContext().
                    VeterinaryEquipment.Where
                    (v => v.NameVeterinaryEquipment.StartsWith(SearchTb.Text) ||
                    v.TypeVeterinaryEquipment.NameTypeVeterinaryEquipment.
                    StartsWith(SearchTb.Text) ||
                    v.WhereDidItComeFrom.StartsWith(SearchTb.Text) ||
                    v.Staff.FullName.StartsWith(SearchTb.Text)).ToList();
                if (VeterinaryEquipmentListB.Items.Count <= 0)
                    MBClass.ErrorMB("Данные отсутствуют");
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
                    SelectedItem as VeterinaryEquipment));
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
    }
}
