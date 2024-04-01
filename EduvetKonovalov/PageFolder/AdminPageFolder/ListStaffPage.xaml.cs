using EduvetKonovalov.ClassFolder;
using EduvetKonovalov.DataFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
    /// Логика взаимодействия для ListStaffPage.xaml
    /// </summary>
    public partial class ListStaffPage : Page
    {
        public ListStaffPage()
        {
            InitializeComponent();
            StaffListB.ItemsSource = DBEntities.GetContext()
                .Staff.ToList().OrderBy(s => s.LastNameStaff);

            ListStaffDg.ItemsSource = DBEntities.GetContext()
                .Staff.ToList().OrderBy(s => s.LastNameStaff);

            UserListB.ItemsSource = DBEntities.GetContext()
                .User.ToList().OrderBy(u => u.IdLogin);
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
        Staff staff = new Staff();
        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StaffListB.ItemsSource = DataFolder.DBEntities.GetContext().Staff.
                    Where(s => s.LastNameStaff.StartsWith(SearchTb.Text) ||
                    s.FirstNameStaff.StartsWith(SearchTb.Text) ||
                    s.MiddleNameStaff.StartsWith(SearchTb.Text) ||
                    s.NumberPhoneStaff.StartsWith(SearchTb.Text) ||
                    s.Gender.GenderStaff.StartsWith(SearchTb.Text)).ToList();
                if (StaffListB.Items.Count <= 0)
                    MBClass.ErrorMB("Данные отсутствуют");
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddStaffPage());
        }

        private void EditStaffMi_Click(object sender, RoutedEventArgs e)
        {
            if (StaffListB.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите строку для редактирование");
            }
            else
            {

                Staff staff = StaffListB.SelectedItem as Staff;
                NavigationService.Navigate
                    (new EditStaffPage(StaffListB.SelectedItem as Staff));
            }
        }

        private void DeleteStafffMi_Click(object sender, RoutedEventArgs e)
        {
            if (StaffListB.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите строку для удаления");
            }
            else
            {
                bool ret = MBClass.QestionMB("Вы действительно хотите " +
                    "удалить данную строку?");
                if (ret == true)
                {
                    Staff staff = StaffListB.SelectedItem as Staff;
                    User user = UserListB.SelectedItem as User;

                    staff = DBEntities.GetContext().Staff
                                .FirstOrDefault(s => s.IdStaff == staff.IdStaff);
                    staff.Login.LoginUser = "1";
                    staff.Password.PasswordUser = "1";

                    user = DBEntities.GetContext().User
                                .FirstOrDefault(u => u.Login.LoginUser == staff.Login.LoginUser);

                    DBEntities.GetContext().Staff.Remove(staff);
                    DBEntities.GetContext().User.Remove(user);
                    DBEntities.GetContext().SaveChanges();
                    MBClass.InfoMB("Данные успешно были удалены!");
                    NavigationService.Navigate(new ListStaffPage());
                }
            }
        }

        private void UpdateStaffMi_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ListStaffPage());
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
