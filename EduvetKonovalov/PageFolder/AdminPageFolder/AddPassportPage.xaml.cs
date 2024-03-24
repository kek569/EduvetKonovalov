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
    /// Логика взаимодействия для AddPassportPage.xaml
    /// </summary>
    public partial class AddPassportPage : Page
    {
        public AddPassportPage()
        {
            InitializeComponent();
        }

        private void AddPassportBtn_Click(object sender, RoutedEventArgs e)
        {
            var passportAdd = new Passport()
            {
                NumberPassport = Int32.Parse(NumberPassportTb.Text),
                SeriesPassport = Int32.Parse(SeriesPassportTb.Text)
            };
            DBEntities.GetContext().Passport.Add(passportAdd);
            DBEntities.GetContext().SaveChanges();
            MBClass.InfoMB("Данные о паспорте успешно добавлены");
            this.NavigationService.GoBack();
            //NavigationService.Navigate(new AddStaffPage());
        }
    }
}
