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
    /// Логика взаимодействия для AddUserPage.xaml
    /// </summary>
    public partial class AddUserPage : Page
    {
        public AddUserPage()
        {
            InitializeComponent();
            RoleCb.ItemsSource = DBEntities.GetContext().Role.ToList();
            LoginCb.ItemsSource = DBEntities.GetContext().Login.ToList();
            PasswordCb.ItemsSource = DBEntities.GetContext().Password.ToList();
        }

        private void AddUserBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var userOne = DBEntities.GetContext()
                        .User
                        .FirstOrDefault(u => u.Login.LoginUser == LoginTb.Text);

                if (userOne == null)
                {
                    if (string.IsNullOrWhiteSpace(LoginTb.Text))
                    {
                        MBClass.ErrorMB("Введите логин");
                        LoginTb.Focus();
                    }
                    else if (string.IsNullOrWhiteSpace(PasswordTb.Text))
                    {
                        MBClass.ErrorMB("Введите пароль");
                        LoginTb.Focus();
                    }
                    else if (RoleCb.SelectedIndex <= -1)
                    {
                        MBClass.ErrorMB("Введите роль");
                        RoleCb.Focus();
                    }
                    else
                    {
                        Int32 a = Int32.Parse(RoleCb.SelectedValue.ToString());
                        if (a == 2)
                        {
                            bool ret = MBClass.QestionMB("Вы действительно хотите " +
                                "добавить сотрудника с пустым личным кабинетом?\n " +
                                "Потом нельзя будет ему добавить личный кабинет.");
                            if (ret == true)
                            {
                                Login();
                                Password();
                                string selected_Login = (App.Current as App).AddLoginName;
                                string selected_Password = (App.Current as App).AddPasswordName;
                                var loginAdd = new Login()
                                {
                                    LoginUser = LoginTb.Text
                                };
                                DBEntities.GetContext().Login.Add(loginAdd);
                                DBEntities.GetContext().SaveChanges();

                                var passwordAdd = new Password()
                                {
                                    PasswordUser = PasswordTb.Text
                                };
                                DBEntities.GetContext().Password.Add(passwordAdd);
                                DBEntities.GetContext().SaveChanges();

                                var userAdd = new User()
                                {
                                    IdLogin = Int32.Parse(selected_Login),
                                    IdPassword = Int32.Parse(selected_Password),
                                    IdRole = Int32.Parse(RoleCb.SelectedValue.ToString())
                                };
                                DBEntities.GetContext().User.Add(userAdd);
                                DBEntities.GetContext().SaveChanges();

                                MBClass.InfoMB("Данные о пользователе успешно добавлены");
                                NavigationService.Navigate(new ListUserPage());
                            }
                        }
                        else
                        {
                            Login();
                            Password();
                            string selected_Login = (App.Current as App).AddLoginName;
                            string selected_Password = (App.Current as App).AddPasswordName;
                            var loginAdd = new Login()
                            {
                                LoginUser = LoginTb.Text
                            };
                            DBEntities.GetContext().Login.Add(loginAdd);
                            DBEntities.GetContext().SaveChanges();

                            var passwordAdd = new Password()
                            {
                                PasswordUser = PasswordTb.Text
                            };
                            DBEntities.GetContext().Password.Add(passwordAdd);
                            DBEntities.GetContext().SaveChanges();

                            var userAdd = new User()
                            {
                                IdLogin = Int32.Parse(selected_Login),
                                IdPassword = Int32.Parse(selected_Password),
                                IdRole = Int32.Parse(RoleCb.SelectedValue.ToString())
                            };
                            DBEntities.GetContext().User.Add(userAdd);
                            DBEntities.GetContext().SaveChanges();

                            MBClass.InfoMB("Данные о пользователе успешно добавлены");
                            NavigationService.Navigate(new ListUserPage());
                        }
                    }
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

        public void Login()
        {
            try
            {
                LoginCb.SelectedValue = 1;

                for (Int32 i = 0; i < 9999999; i++)
                {
                    if (string.IsNullOrEmpty(LoginCb.Text))
                    {

                    }
                    else
                    {
                        i = Int32.Parse(LoginCb.SelectedValue.ToString());
                        i = i + 1;
                        LoginCb.SelectedValue = i;

                        (App.Current as App).AddLoginName = i.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }

        public void Password()
        {
            try
            {
                PasswordCb.SelectedValue = 1;

                for (Int32 i = 0; i < 9999999; i++)
                {
                    if (string.IsNullOrEmpty(PasswordCb.Text))
                    {

                    }
                    else
                    {
                        i = Int32.Parse(PasswordCb.SelectedValue.ToString());
                        i = i + 1;
                        PasswordCb.SelectedValue = i;
                        (App.Current as App).AddPasswordName = i.ToString();
                    }

                }
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }
    }
}
