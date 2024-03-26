using EduvetKonovalov.ClassFolder;
using EduvetKonovalov.DataFolder;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Net;
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
using static System.Net.Mime.MediaTypeNames;

namespace EduvetKonovalov.PageFolder.AdminPageFolder
{
    /// <summary>
    /// Логика взаимодействия для AddStaffPage.xaml
    /// </summary>
    public partial class AddStaffPage : Page
    {
        public AddStaffPage()
        {
            InitializeComponent();
            PassportCb.ItemsSource = DBEntities.GetContext().Passport.ToList();
            PassportOneCb.ItemsSource = DBEntities.GetContext().Passport.ToList();
            GenderCb.ItemsSource = DBEntities.GetContext().Gender.ToList();
            LoginCb.ItemsSource = DBEntities.GetContext().Login.ToList();
            PasswordCb.ItemsSource = DBEntities.GetContext().Password.ToList();
            JobTitleCb.ItemsSource = DBEntities.GetContext().JobTitle.ToList();

        }

        private void LoadPhotoBtn_Click(object sender, RoutedEventArgs e)
        {
            AddPhoto();
        }

        Staff staff = new Staff();
        string selectedFileName = "";

        private void AddPhoto()
        {
            try
            {

                OpenFileDialog op = new OpenFileDialog();
                op.InitialDirectory = "";
                op.Filter = "All support graphics|*.jpg;*.jpeg;*.png|" +
                    "JPEG (*.jpg;*jpeg)|*.jpg;*jpeg|" +
                    "Portable Network Graphic (*.png|*.png";

                if (op.ShowDialog() == true)
                {
                    selectedFileName = op.FileName;
                    staff.PhotoStaff = ClassImage.ConvertImageToArray(selectedFileName);
                    PhotoIM.Source = ClassImage.ConvertByteArrayToImage(staff.PhotoStaff);


                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private string MiddleName;
        private string MiddleNameFull;

        private void AddStaffBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var userOne = DBEntities.GetContext()
                        .User
                        .FirstOrDefault(u => u.Login.LoginUser == LoginTb.Text);

                if (userOne == null)
                {
                    if (string.IsNullOrWhiteSpace(LastNameStaffTb.Text))
                    {
                        MBClass.ErrorMB("Введите имя");
                        LastNameStaffTb.Focus();
                    }
                    else if (string.IsNullOrWhiteSpace(FirstNameStaffTb.Text))
                    {
                        MBClass.ErrorMB("Введите фамилию");
                        FirstNameStaffTb.Focus();
                    }
                    else if (string.IsNullOrWhiteSpace(NumberPhoneStaffTb.Text))
                    {
                        MBClass.ErrorMB("Введите номер телефона");
                        NumberPhoneStaffTb.Focus();
                    }
                    else if (string.IsNullOrWhiteSpace(DateOfBirthStaffDp.Text))
                    {
                        MBClass.ErrorMB("Введите дату рождения");
                        DateOfBirthStaffDp.Focus();
                    }
                    else if (string.IsNullOrWhiteSpace(AdressStaffTb.Text))
                    {
                        MBClass.ErrorMB("Введите адрес");
                        AdressStaffTb.Focus();
                    }
                    else if (string.IsNullOrWhiteSpace(LoginTb.Text))
                    {
                        MBClass.ErrorMB("Введите логин");
                        LoginTb.Focus();
                    }
                    else if (string.IsNullOrWhiteSpace(PasswordTb.Text))
                    {
                        MBClass.ErrorMB("Введите пароль");
                        PasswordTb.Focus();
                    }
                    else if (PassportCb.SelectedIndex <= -1)
                    {
                        MBClass.ErrorMB("Введите паспорт");
                        PassportCb.Focus();
                    }
                    else if (GenderCb.SelectedIndex <= -1)
                    {
                        MBClass.ErrorMB("Введите пол");
                        GenderCb.Focus();
                    }
                    else if (JobTitleCb.SelectedIndex <= -1)
                    {
                        MBClass.ErrorMB("Введите должность");
                        JobTitleCb.Focus();
                    }
                    else
                    {
                        if (string.IsNullOrWhiteSpace(MiddleNameStaffTb.Text))
                        {
                            MiddleName = null;
                            MiddleNameFull = "";
                        }
                        else
                        {
                            MiddleName = MiddleNameStaffTb.Text;
                            MiddleNameFull = MiddleNameStaffTb.Text;
                        }

                        if (selectedFileName == "")
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
                                IdRole = 2
                            };
                            DBEntities.GetContext().User.Add(userAdd);
                            DBEntities.GetContext().SaveChanges();
                            var staffAdd = new Staff()
                            {

                                LastNameStaff = LastNameStaffTb.Text,
                                FirstNameStaff = FirstNameStaffTb.Text,
                                MiddleNameStaff = MiddleName,
                                FullName = (FirstNameStaffTb.Text + " " +
                                                LastNameStaffTb.Text + " "
                                                + MiddleNameFull),
                                NumberPhoneStaff = NumberPhoneStaffTb.Text,
                                DateOfBirthStaff = System.DateTime.Parse(DateOfBirthStaffDp.Text),
                                IdPassport = Int32.Parse(PassportCb.SelectedValue.ToString()),
                                IdGender = Int32.Parse(GenderCb.SelectedValue.ToString()),
                                IdLogin = Int32.Parse(selected_Login),
                                IdPassword = Int32.Parse(selected_Password),
                                AdressStaff = AdressStaffTb.Text,
                                IdJobTitle = Int32.Parse(JobTitleCb.SelectedValue.ToString())
                            };
                            DBEntities.GetContext().Staff.Add(staffAdd);
                            DBEntities.GetContext().SaveChanges();

                            MBClass.InfoMB("Данные о сотруднике успешно добавлены");
                            NavigationService.Navigate(new ListStaffPage());
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
                                IdRole = 2
                            };
                            DBEntities.GetContext().User.Add(userAdd);
                            DBEntities.GetContext().SaveChanges();
                            var staffAdd = new Staff()
                            {
                                LastNameStaff = LastNameStaffTb.Text,
                                FirstNameStaff = FirstNameStaffTb.Text,
                                MiddleNameStaff = MiddleName,
                                FullName = (FirstNameStaffTb.Text + " " +
                                                LastNameStaffTb.Text + " "
                                                + MiddleNameFull),
                                NumberPhoneStaff = NumberPhoneStaffTb.Text,
                                DateOfBirthStaff = System.DateTime.Parse(DateOfBirthStaffDp.Text),
                                IdPassport = Int32.Parse(PassportCb.SelectedValue.ToString()),
                                IdGender = Int32.Parse(GenderCb.SelectedValue.ToString()),
                                IdLogin = Int32.Parse(selected_Login),
                                IdPassword = Int32.Parse(selected_Password),
                                AdressStaff = AdressStaffTb.Text,
                                IdJobTitle = Int32.Parse(JobTitleCb.SelectedValue.ToString()),
                                PhotoStaff = ClassImage.ConvertImageToArray(selectedFileName)
                            };
                            DBEntities.GetContext().Staff.Add(staffAdd);
                            DBEntities.GetContext().SaveChanges();

                            MBClass.InfoMB("Данные о сотруднике успешно добавлены");
                            NavigationService.Navigate(new ListStaffPage());
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

        private void AddPassport_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddPassportPage());
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

                        //MBClass.InfoMB("" + i);
                        (App.Current as App).AddLoginName = i.ToString();
                    }
                }
                /*Int32 b = Int32.Parse(LoginCb.SelectedValue.ToString());
                LoginCb.SelectedValue = b - 1;*/
                string selected_Login = (App.Current as App).AddLoginName;
                Int32 a = Int32.Parse(selected_Login);
                if (a <= 0)
                {
                    a = 1;
                    (App.Current as App).AddLoginName = a.ToString();
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

                        //MBClass.InfoMB("" + i);
                    }

                }
                /*Int32 b = Int32.Parse(PasswordCb.SelectedValue.ToString());
                PasswordCb.SelectedValue = b - 1;*/
                string selected_Password = (App.Current as App).AddPasswordName;
                Int32 a = Int32.Parse(selected_Password);
                if (a <= 0)
                {
                    a = 1;
                    (App.Current as App).AddPasswordName = a.ToString();
                }

            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }

        private void PassportOneCb_IsMouseCapturedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (PassportOneCb.SelectedIndex <= -1)
            {

            }
            else
            {
                Int32 b = Int32.Parse(PassportOneCb.SelectedValue.ToString());
                PassportCb.SelectedValue = b;
            }
        }
    }
}