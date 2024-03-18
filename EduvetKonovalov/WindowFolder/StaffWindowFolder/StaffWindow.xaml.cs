using EduvetKonovalov.ClassFolder;
using EduvetKonovalov.PageFolder.StaffPageFolder;
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

namespace EduvetKonovalov.WindowFolder.StaffWindowFolder
{
    /// <summary>
    /// Логика взаимодействия для StaffWindow.xaml
    /// </summary>
    public partial class StaffWindow : Window
    {
        public StaffWindow()
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

        private void ListProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ListProfilePage());
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            if (this.MainFrame.CanGoBack)
            {
                this.MainFrame.GoBack();
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
    }
}
