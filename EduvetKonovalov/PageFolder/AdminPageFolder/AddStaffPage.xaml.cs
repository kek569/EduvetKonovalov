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
            GenderCb.ItemsSource = DBEntities.GetContext().Gender.ToList();
            UserCb.ItemsSource = DBEntities.GetContext().User.ToList();
            JobTitleCb.ItemsSource = DBEntities.GetContext().JobTitle.ToList();
            RoleCb.ItemsSource = DBEntities.GetContext().Role.ToList();
            NumberPassportTb.MaxLength = 4;
            SeriesPassportTb.MaxLength = 6;
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
                        .FirstOrDefault(u => u.LoginUser == LoginTb.Text);

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
                    else if (string.IsNullOrWhiteSpace(NumberPassportTb.Text))
                    {
                        MBClass.ErrorMB("Введите серию паспорта");
                        NumberPassportTb.Focus();
                    }
                    else if (string.IsNullOrWhiteSpace(SeriesPassportTb.Text))
                    {
                        MBClass.ErrorMB("Введите номер паспорта");
                        SeriesPassportTb.Focus();
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
                    else if (RoleCb.SelectedIndex <= -1)
                    {
                        MBClass.ErrorMB("Введите роль");
                        RoleCb.Focus();
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
                            Passport();
                            string selected_Login = (App.Current as App).AddLoginName;
                            string selected_Passport = (App.Current as App).AddPassportName;
                            var userAdd = new User()
                            {
                                LoginUser = LoginTb.Text,
                                PasswordUser = PasswordTb.Text,
                                IdRole = Int32.Parse(RoleCb.SelectedValue.ToString())
                            };
                            DBEntities.GetContext().User.Add(userAdd);
                            DBEntities.GetContext().SaveChanges();
                            var passportAdd = new Passport()
                            {
                                NumberPassport = Int32.Parse(NumberPassportTb.Text),
                                SeriesPassport = Int32.Parse(SeriesPassportTb.Text)
                            };
                            DBEntities.GetContext().Passport.Add(passportAdd);
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
                                IdPassport = Int32.Parse(selected_Passport),
                                IdGender = Int32.Parse(GenderCb.SelectedValue.ToString()),
                                IdUser = Int32.Parse(selected_Login),
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
                            Passport();
                            string selected_Login = (App.Current as App).AddLoginName;
                            string selected_Passport = (App.Current as App).AddPassportName;
                            var userAdd = new User()
                            {
                                LoginUser = LoginTb.Text,
                                PasswordUser = PasswordTb.Text,
                                IdRole = Int32.Parse(RoleCb.SelectedValue.ToString())
                            };
                            DBEntities.GetContext().User.Add(userAdd);
                            DBEntities.GetContext().SaveChanges();
                            var passportAdd = new Passport()
                            {
                                NumberPassport = Int32.Parse(NumberPassportTb.Text),
                                SeriesPassport = Int32.Parse(SeriesPassportTb.Text)
                            };
                            DBEntities.GetContext().Passport.Add(passportAdd);
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
                                IdPassport = Int32.Parse(selected_Passport),
                                IdGender = Int32.Parse(GenderCb.SelectedValue.ToString()),
                                IdUser = Int32.Parse(selected_Login),
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

        public void Login()
        {
            try
            {
                UserCb.SelectedValue = 1;

                for (Int32 i = 0; i < 9999999; i++)
                {
                    if (string.IsNullOrEmpty(UserCb.Text))
                    {

                    }
                    else
                    {
                        
                        if (Int32.Parse(UserCb.SelectedValue.ToString()) == 1)
                        {
                            i = 10;
                        }
                        else
                        {
                            i = Int32.Parse(UserCb.SelectedValue.ToString());
                        }
                        i = i + 1;
                        UserCb.SelectedValue = i;

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

        public void Passport()
        {
            try
            {
                PassportCb.SelectedValue = 1;

                for (Int32 i = 0; i < 9999999; i++)
                {
                    if (string.IsNullOrEmpty(PassportCb.Text))
                    {

                    }
                    else
                    {
                        if (Int32.Parse(PassportCb.SelectedValue.ToString()) == 1)
                        {
                            i = 7;
                        }
                        else
                        {
                            i = Int32.Parse(PassportCb.SelectedValue.ToString());
                        }
                        i = i + 1;
                        PassportCb.SelectedValue = i;
                        (App.Current as App).AddPassportName = i.ToString();

                        //MBClass.InfoMB("" + i);
                    }

                }
                /*Int32 b = Int32.Parse(PasswordCb.SelectedValue.ToString());
                PasswordCb.SelectedValue = b - 1;*/
                string selected_Passport = (App.Current as App).AddPassportName;
                Int32 a = Int32.Parse(selected_Passport);
                if (a <= 0)
                {
                    a = 1;
                    (App.Current as App).AddPassportName = a.ToString();
                }

            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }

        private void Lol_Click(object sender, RoutedEventArgs e)
        {
            Login();
        }
    }
}