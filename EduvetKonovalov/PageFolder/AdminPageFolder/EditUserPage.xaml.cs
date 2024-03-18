using EduvetKonovalov.ClassFolder;
using EduvetKonovalov.DataFolder;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
    /// Логика взаимодействия для EditUserPage.xaml
    /// </summary>
    public partial class EditUserPage : Page
    {
        User user = new User();

        public EditUserPage(User user)
        {
            InitializeComponent();
            DataContext = user;
            this.user.IdUser = user.IdUser;
            //DataContext = login;
            /*this.login.IdLogin = login.IdLogin;
            this.password.IdPassword = password.IdPassword;*/

            RoleCb.ItemsSource = DBEntities.GetContext().Role.ToList();
            LoginCb.ItemsSource = DBEntities.GetContext().Login.ToList();
            PasswordCb.ItemsSource = DBEntities.GetContext().Password.ToList();
            
            /*if (LoginCb.SelectedIndex <= -1 || LoginCb.SelectedIndex <= -1)
            {
                MBClass.InfoMB("Нажмите пожалуйста на кнопку Fix");
            }
            else
            {
                LoginTb.Text = LoginCb.Text;

                string g = LoginCb.Text;
                (App.Current as App).EditLoginAdminOneName = g;

                string a = LoginCb.SelectedValue.ToString();
                (App.Current as App).EditLoginAdminName = a;

                PasswordTb.Text = PasswordCb.Text;

                string b = PasswordCb.SelectedValue.ToString();
                (App.Current as App).EditPasswordAdminName = b;
            }*/
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string selected_LoginOne = (App.Current as App).EditLoginAdminOneName;

                var userOne = DBEntities.GetContext()
                        .User
                        .FirstOrDefault(u => u.Login.LoginUser == LoginTb.Text);

                if (userOne == null || LoginTb.Text == selected_LoginOne)
                {
                    /*string selected_Login = (App.Current as App).EditLoginAdminName;
                    string selected_Password = (App.Current as App).EditPasswordAdminName;
                    string selected_PassportOne = (App.Current as App).EditPassportOneAdminName;

                    login = DBEntities.GetContext().Login
                        .FirstOrDefault(l => l.IdLogin == login.IdLogin);
                    login.LoginUser = LoginTb.Text;
                    DBEntities.GetContext().SaveChanges();

                    password = DBEntities.GetContext().Password
                        .FirstOrDefault(p => p.IdPassword == password.IdPassword);
                    password.PasswordUser = PasswordTb.Text;
                    DBEntities.GetContext().SaveChanges();*/

                    user = DBEntities.GetContext().User
                        .FirstOrDefault(u => u.IdUser == user.IdUser);
                    user.Login.LoginUser = LoginTb.Text;
                    user.Password.PasswordUser = PasswordTb.Text;
                    /*user.IdLogin = Int32.Parse(selected_Login);
                    user.IdPassword = Int32.Parse(selected_Password);*/
                    user.IdRole = Int32.Parse(RoleCb.SelectedValue.ToString());
                    DBEntities.GetContext().SaveChanges();
                    MBClass.InfoMB("Информация успешно отредактирована");
                    NavigationService.Navigate(new ListUserPage());
                }
                else
                {
                    MBClass.ErrorMB("Данный логин уже существует");
                }
            }
            catch (DbEntityValidationException ex)
            {
                MBClass.ErrorMB(ex);
            }
        }

        /*private void FixBtn_Click(object sender, RoutedEventArgs e)
        {
            if (LoginCb.SelectedIndex <= -1)
            {
                MBClass.ErrorMB("Произошла непредвиденая ошибка");
            }
            else
            {
                LoginTb.Text = LoginCb.Text;

                string g = LoginCb.Text;
                (App.Current as App).EditLoginAdminOneName = g;

                string a = LoginCb.SelectedValue.ToString();
                (App.Current as App).EditLoginAdminName = a;

                PasswordTb.Text = PasswordCb.Text;

                string b = PasswordCb.SelectedValue.ToString();
                (App.Current as App).EditPasswordAdminName = b;
            }
        }*/
    }
}
