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
using System.Windows.Shapes;

namespace EduvetKonovalov.WindowFolder.AdminWindowFolder
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new ListVeterinaryEquipmentPage());
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void CloseIm_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            bool ret = MBClass.QestionMB("Вы действительно желаете выйти?");
            if (ret == true)
            {
                this.Close();
            }
        }

        private void ListVeterinaryEquipmentBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ListVeterinaryEquipmentPage());
        }

        private void ListStaffBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ListStaffPage());
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {

            if (this.MainFrame.CanGoBack)
            {
                /*if (this.MainFrame.Navigate(new ListStaffPage()))
                {
                    MainFrame.Navigate(new ListVeterinaryEquipmentPage());
                }
                else
                {*/
                    this.MainFrame.GoBack();
                //}
            }
            else
            {
                bool ret = MBClass.QestionMB("Вы действительно желаете " +
                "выйти в окно авторизации?");
                if (ret == true)
                {
                    (App.Current as App).CheckLogin = true;
                    new AuthorizationWindow().Show();
                    this.Close();
                }
            }
        }

        private void LisRequestVeterinaryEquipmentBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ListRequestVeterinaryEquipmentPage());
        }
    }
}
