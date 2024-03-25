using EduvetKonovalov.ClassFolder;
using EduvetKonovalov.DataFolder;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
using System.Windows.Threading;

namespace EduvetKonovalov.PageFolder.AdminPageFolder
{
    /// <summary>
    /// Логика взаимодействия для EditStaffPage.xaml
    /// </summary>
    public partial class EditStaffPage : Page
    {
        Staff staff = new Staff();

        public EditStaffPage(Staff staff)
        {
            InitializeComponent();
            DataContext = staff;
            this.staff.IdStaff = staff.IdStaff;

            PassportCb.ItemsSource = DBEntities.GetContext().Passport.ToList();
            PassportOneCb.ItemsSource = DBEntities.GetContext().Passport.ToList();
            GenderCb.ItemsSource = DBEntities.GetContext().Gender.ToList();
            LoginCb.ItemsSource = DBEntities.GetContext().Login.ToList();
            PasswordCb.ItemsSource = DBEntities.GetContext().Password.ToList();

            staff = DBEntities.GetContext().Staff
                                .FirstOrDefault(s => s.IdStaff == staff.IdStaff);
            DateOfBirthStaffDp.Text = staff.DateOfBirthStaff.ToString();

            var timer = new DispatcherTimer 
            { Interval = TimeSpan.FromSeconds(0.5) };
            timer.Start();
            timer.Tick += (sender, args) =>
            {
                timer.Stop();
                (App.Current as App).EditLoginAdminOneName = LoginTb.Text;
            };        
        }

        private void LoadPhotoBtn_Click(object sender, RoutedEventArgs e)
        {
            AddPhoto();
        }

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
                            staff = DBEntities.GetContext().Staff
                                .FirstOrDefault(s => s.IdStaff == staff.IdStaff);
                            staff.Login.LoginUser = LoginTb.Text;
                            staff.Password.PasswordUser = PasswordTb.Text;
                            staff.Passport.NumberPassport = Int32.Parse(PassportTb.Text);
                            staff.Passport.SeriesPassport = Int32.Parse(PassportOneTb.Text);

                            staff.LastNameStaff = LastNameStaffTb.Text;
                            staff.FirstNameStaff = FirstNameStaffTb.Text;
                            staff.MiddleNameStaff = MiddleName;
                            staff.FullName = FirstNameStaffTb.Text + " "
                                + LastNameStaffTb.Text + " " + MiddleNameFull;
                            staff.NumberPhoneStaff = NumberPhoneStaffTb.Text;
                            staff.DateOfBirthStaff = System.DateTime.Parse(DateOfBirthStaffDp.Text);
                            staff.IdGender = Int32.Parse(GenderCb.SelectedValue.ToString());
                            staff.AdressStaff = AdressStaffTb.Text;
                            DBEntities.GetContext().SaveChanges();

                            MBClass.InfoMB("Данные о сотруднике успешно отредактированы");
                            NavigationService.Navigate(new ListStaffPage());
                        }
                        else
                        {
                            staff = DBEntities.GetContext().Staff
                                .FirstOrDefault(s => s.IdStaff == staff.IdStaff);
                            staff.Login.LoginUser = LoginTb.Text;
                            staff.Password.PasswordUser = PasswordTb.Text;
                            staff.Passport.NumberPassport = Int32.Parse(PassportTb.Text);
                            staff.Passport.SeriesPassport = Int32.Parse(PassportOneTb.Text);

                            staff.LastNameStaff = LastNameStaffTb.Text;
                            staff.FirstNameStaff = FirstNameStaffTb.Text;
                            staff.MiddleNameStaff = MiddleName;
                            staff.FullName = FirstNameStaffTb.Text + " "
                                + LastNameStaffTb.Text + " " + MiddleNameFull;
                            staff.NumberPhoneStaff = NumberPhoneStaffTb.Text;
                            staff.DateOfBirthStaff = System.DateTime.Parse(DateOfBirthStaffDp.Text);
                            staff.IdGender = Int32.Parse(GenderCb.SelectedValue.ToString());
                            staff.AdressStaff = AdressStaffTb.Text;
                            staff.PhotoStaff = ClassImage.ConvertImageToArray(selectedFileName);
                            DBEntities.GetContext().SaveChanges();

                            MBClass.InfoMB("Данные о сотруднике успешно отредактированы");
                            NavigationService.Navigate(new ListStaffPage());
                        }
                    }
                }
                else
                {
                    MBClass.ErrorMB("Данный логин уже существует");
                }
            }
            catch(DbEntityValidationException ex)
            {
                MBClass.ErrorMB(ex);
            }
        }
    }
}
