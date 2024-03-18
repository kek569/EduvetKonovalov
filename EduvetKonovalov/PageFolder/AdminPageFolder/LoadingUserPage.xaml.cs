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
    /// Логика взаимодействия для LoadingUserPage.xaml
    /// </summary>
    public partial class LoadingUserPage : Page
    {
        User user = new User();

        public LoadingUserPage(User user)
        {
            InitializeComponent();
            DataContext = user;
            this.user.IdUser = user.IdUser;

            LoginCb.ItemsSource = DBEntities.GetContext().Login.ToList();
            if (LoginCb.SelectedIndex <= -1)
            {
                MBClass.InfoMB("Нажмите пожалуйста на кнопку продолжить");
            }
            else
            {
                string a = LoginCb.Text;
                (App.Current as App).UserLogin = a;

                (App.Current as App).CheckUser = "1";
                MBClass.InfoMB("Нажмите пожалуйста на редактировать заново");
                NavigationService.Navigate(new ListUserPage());
            }
        }

        private void ContinueBtn_Click(object sender, RoutedEventArgs e)
        {
            if (LoginCb.SelectedIndex <= -1)
            {
                MBClass.ErrorMB("Произошла непредвиденая ошибка");
            }
            else
            {
                string a = LoginCb.Text;
                (App.Current as App).UserLogin = a;

                (App.Current as App).CheckUser = "1";
                MBClass.InfoMB("Нажмите пожалуйста на редактировать заново");
                NavigationService.Navigate(new ListUserPage());
            }
        }
    }
}
