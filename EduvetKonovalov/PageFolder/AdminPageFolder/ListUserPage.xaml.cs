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
    /// Логика взаимодействия для ListUserPage.xaml
    /// </summary>
    public partial class ListUserPage : Page
    {
        public ListUserPage()
        {
            InitializeComponent();
            UserListB.ItemsSource = DBEntities.GetContext()
                .User.ToList().OrderBy(u => u.IdLogin);
            LoginListB.ItemsSource = DBEntities.GetContext()
                .Login.ToList().OrderBy(l => l.IdLogin);
            PasswordListB.ItemsSource = DBEntities.GetContext()
                .Password.ToList().OrderBy(p => p.IdPassword);
            /*string selected_CheckUser = (App.Current as App).CheckUser;
            string selected_ListBoxUserSearch =
                        (App.Current as App).ListBoxUserSearch;

            if (selected_CheckUser == "1" && selected_ListBoxUserSearch != null)
            {
                
                try
                {
                    UserListB.ItemsSource = DataFolder.DBEntities.GetContext().User.
                        Where(u => u.Login.LoginUser.StartsWith
                        (selected_ListBoxUserSearch) ||
                        u.Password.PasswordUser.StartsWith
                        (selected_ListBoxUserSearch) ||
                        u.Role.NameRole.StartsWith
                        (selected_ListBoxUserSearch)).ToList();
                    if (UserListB.Items.Count <= 0)
                        MBClass.ErrorMB("Error");
                    SearchTb.Focus();
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                }
            }

            if (selected_CheckUser == "1")
            {
                if (UserListB.SelectedItem == null)
                {
                    string selected_ListBoxUserIndex = 
                        (App.Current as App).ListBoxUserIndex;
                    int index = int.Parse(selected_ListBoxUserIndex);
                    UserListB.SelectedIndex = index;
                }
                try
                {
                    string selected_UserLogin = (App.Current as App).UserLogin;
                    UserListB.ItemsSource = DataFolder.DBEntities.GetContext().User.
                        Where(u => u.Login.LoginUser.StartsWith
                        (selected_UserLogin)).ToList();
                    if (UserListB.Items.Count <= 0)
                        MBClass.ErrorMB("Error");
                    SearchTb.Focus();
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                }
                //EditUser();
            }
            else
            {
                (App.Current as App).CheckUser = "0";
            }*/
        }

        private void AddUserBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddUserPage());
        }

        private void EditUserMi_Click(object sender, RoutedEventArgs e)
        {
            if (UserListB.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите строку для редактирование");
            }
            else
            {
                /*string selected_CheckUser = (App.Current as App).CheckUser;
                if (SearchTb.Text == "Поиск") { }
                else if(selected_CheckUser == "1")
                {

                }

                if (selected_CheckUser == "0")
                {
                    LoadingUser();
                }
                else if (selected_CheckUser == "1")
                {
                    string selected_ListBoxUserIndex =
                        (App.Current as App).ListBoxUserIndex;
                    int index = int.Parse(selected_ListBoxUserIndex);
                    if (index == UserListB.SelectedIndex
                        && SearchTb.Text == "Поиск")
                    {
                        try
                        {
                            string selected_UserLogin = (App.Current as App).UserLogin;

                            LoginListB.ItemsSource = DataFolder.DBEntities.GetContext().Login.
                             Where(l => l.LoginUser.StartsWith(selected_UserLogin)).ToList();
                            if (UserListB.Items.Count <= 0)
                                MBClass.ErrorMB("Error login");
                            LoginListB.SelectedIndex = 0;

                            PasswordListB.ItemsSource = DataFolder.DBEntities.GetContext().Password.
                           Where(l => l.Login.LoginUser.StartsWith(selected_UserLogin)).ToList();
                            if (UserListB.Items.Count <= 0)
                                MBClass.ErrorMB("Error password");
                            PasswordListB.SelectedIndex = 0;
                        }
                        catch (Exception ex)
                        {
                            MBClass.ErrorMB(ex);
                        }
                        User user = UserListB.SelectedItem as User;
                        Login login = LoginListB.SelectedItem as Login;
                        Password password = LoginListB.SelectedItem as Password;
                        (App.Current as App).CheckUser = "0";
                        NavigationService.Navigate
                            (new EditUserPage(UserListB.SelectedItem as User,
                            LoginListB.SelectedItem as Login,
                            PasswordListB.SelectedItem as Password));
                    }
                    else
                    {
                        LoadingUser();
                    }
                }*/
                User user = UserListB.SelectedItem as User;
                NavigationService.Navigate
                            (new EditUserPage(UserListB.SelectedItem as User));
            }

        }

        private void LoadingUser()
        {
            int h = UserListB.SelectedIndex;
            string g = h.ToString();
            (App.Current as App).ListBoxUserIndex = g;
            if (SearchTb.Text == "Поиск") { }
            else
            {
                string s = SearchTb.Text;
                (App.Current as App).ListBoxUserSearch = s;
            }


            User user = UserListB.SelectedItem as User;
            NavigationService.Navigate
                (new LoadingUserPage(UserListB.SelectedItem as User));
        }

        private void DeleteUserMi_Click(object sender, RoutedEventArgs e)
        {
            if (UserListB.SelectedItem == null)
            {
                MBClass.ErrorMB("Выберите строку для удаления");
            }
            else
            {
                bool ret = MBClass.QestionMB("Вы действительно хотите " +
                    "удалить данную строку?");
                if (ret == true)
                {
                    User user = UserListB.SelectedItem as User;
                    DBEntities.GetContext().User.Remove(user);
                    DBEntities.GetContext().SaveChanges();
                    MBClass.InfoMB("Данные успешно были удалены!");
                    NavigationService.Navigate(new ListUserPage());
                }
            }
        }

        private void UpdateUserMi_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ListUserPage());
        }

        private void ExportBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UserListB.ItemsSource = DataFolder.DBEntities.GetContext().User.
                    Where(u => u.Login.LoginUser.StartsWith(SearchTb.Text) ||
                    u.Password.PasswordUser.StartsWith(SearchTb.Text) ||
                    u.Role.NameRole.StartsWith(SearchTb.Text)).ToList();
                if (UserListB.Items.Count <= 0)
                    MBClass.ErrorMB("Данные отсутствуют");
                SearchTb.Focus();
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
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
    }
}
