using EduvetKonovalov.ClassFolder;
using EduvetKonovalov.DataFolder;
using EduvetKonovalov.PageFolder.AdminPageFolder;
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
    /// Логика взаимодействия для ListProfilePage.xaml
    /// </summary>
    public partial class ListProfilePage : Page
    {
        public ListProfilePage()
        {
            InitializeComponent();
            string selected_dept = (App.Current as App).DeptName;
            /*string n = " ";
            TextBox textBox = null;
            LoginClass.LoginIn(n, textBox);*/
            ProfileListB.ItemsSource = DBEntities.GetContext()
                .Staff.ToList().OrderBy(s => s.LastNameStaff);

            ListStaffDg.ItemsSource = DBEntities.GetContext()
                .Staff.ToList().OrderBy(s => s.LastNameStaff);
            try
            {
                ProfileListB.ItemsSource = DataFolder.DBEntities.GetContext().Staff.
                    Where(s => s.Login.LoginUser.StartsWith(selected_dept)).ToList();
                if (ProfileListB.Items.Count <= 0)
                    MBClass.ErrorMB("Error");

                ListStaffDg.ItemsSource = DataFolder.DBEntities.GetContext().Staff.
                    Where(s => s.Login.LoginUser.StartsWith(selected_dept)).ToList();
                if (ListStaffDg.Items.Count <= 0)
                    MBClass.ErrorMB("Error");
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }

        private void EditProfilefMi_Click(object sender, RoutedEventArgs e)
        {
            if (ProfileListB.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите строку для редактирование");
            }
            else
            {
                Staff staff = ProfileListB.SelectedItem as Staff;
                NavigationService.Navigate
                    (new EditProfilePage(ProfileListB.SelectedItem as Staff));
            }
        }

        private void UpdateProfileMi_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ListProfilePage());
        }

        private void EditProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            ProfileListB.SelectedIndex = 0;
            if (ProfileListB.SelectedItem == null)
            {
                MBClass.ErrorMB("Error");
            }
            else
            {
                Staff staff = ProfileListB.SelectedItem as Staff;
                NavigationService.Navigate
                    (new EditProfilePage(ProfileListB.SelectedItem as Staff));
            }
        }

        private void ExportBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ListStaffDg.SelectAllCells();
                int colCount = ListStaffDg.SelectedCells.Count;
                ListStaffDg.SelectedIndex = ListStaffDg.Items.Count - 1;
                int a = colCount / (ListStaffDg.SelectedIndex + 1);
                string selectedFileName = "Excel";
                ExportClass.ToExcelFile(ListStaffDg, selectedFileName, a);
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }
    }
}
