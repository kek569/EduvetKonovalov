using EduvetKonovalov.ClassFolder;
using EduvetKonovalov.DataFolder;
using EduvetKonovalov.PageFolder.AdminPageFolder;
using Microsoft.Win32;
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
using System.Windows.Threading;

namespace EduvetKonovalov.PageFolder.StaffPageFolder
{
    /// <summary>
    /// Логика взаимодействия для EditProfilePage.xaml
    /// </summary>
    public partial class EditProfilePage : Page
    {
        Staff staff = new Staff();

        public EditProfilePage(Staff staff)
        {
            InitializeComponent();
            DataContext = staff;
            this.staff.IdStaff = staff.IdStaff;

            LoginCb.ItemsSource = DBEntities.GetContext().User.ToList();
            PasswordCb.ItemsSource = DBEntities.GetContext().User.ToList();

            staff = DBEntities.GetContext().Staff
                                .FirstOrDefault(s => s.IdStaff == staff.IdStaff);

            var timer = new DispatcherTimer
            { Interval = TimeSpan.FromSeconds(0.5) };
            timer.Start();
            timer.Tick += (sender, args) =>
            {
                timer.Stop();
                (App.Current as App).EditLoginStaffOneName = LoginTb.Text;
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
                string selected_LoginOne = (App.Current as App).EditLoginStaffOneName;

                var userOne = DBEntities.GetContext()
                        .User
                        .FirstOrDefault(u => u.LoginUser == LoginTb.Text);

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
                            staff.User.LoginUser = LoginTb.Text;
                            staff.User.PasswordUser = PasswordTb.Text;

                            staff.LastNameStaff = LastNameStaffTb.Text;
                            staff.FirstNameStaff = FirstNameStaffTb.Text;
                            staff.MiddleNameStaff = MiddleName;
                            staff.FullName = FirstNameStaffTb.Text + " "
                                + LastNameStaffTb.Text + " " + MiddleNameFull;
                            staff.NumberPhoneStaff = NumberPhoneStaffTb.Text;
                            staff.AdressStaff = AdressStaffTb.Text;
                            DBEntities.GetContext().SaveChanges();

                            MBClass.InfoMB("Данные о профиле успешно отредактированы");
                            NavigationService.Navigate(new ListProfilePage());
                        }
                        else
                        {
                            staff = DBEntities.GetContext().Staff
                                .FirstOrDefault(s => s.IdStaff == staff.IdStaff);
                            staff.User.LoginUser = LoginTb.Text;
                            staff.User.PasswordUser = PasswordTb.Text;

                            staff.LastNameStaff = LastNameStaffTb.Text;
                            staff.FirstNameStaff = FirstNameStaffTb.Text;
                            staff.MiddleNameStaff = MiddleName;
                            staff.FullName = FirstNameStaffTb.Text + " "
                                + LastNameStaffTb.Text + " " + MiddleNameFull;
                            staff.NumberPhoneStaff = NumberPhoneStaffTb.Text;
                            staff.AdressStaff = AdressStaffTb.Text;
                            staff.PhotoStaff = ClassImage.ConvertImageToArray(selectedFileName);
                            DBEntities.GetContext().SaveChanges();

                            MBClass.InfoMB("Данные о профиле успешно отредактированы");
                            NavigationService.Navigate(new ListProfilePage());
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
    }
}
