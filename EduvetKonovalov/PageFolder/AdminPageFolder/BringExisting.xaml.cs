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
    /// Логика взаимодействия для BringExisting.xaml
    /// </summary>
    public partial class BringExisting : Page
    {
        VeterinaryEquipment veterinaryEquipment = new VeterinaryEquipment();
        Provider provider = new Provider();

        public BringExisting(VeterinaryEquipment veterinaryEquipment)
        {
            InitializeComponent();
            DataContext = veterinaryEquipment;

            this.veterinaryEquipment.IdVeterinaryEquipment =
                veterinaryEquipment.IdVeterinaryEquipment;
            ProviderCb.ItemsSource = DBEntities.GetContext().Provider.ToList();
        }

        private void AddProviderBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ProviderCb.SelectedIndex <= -1)
            {
                MBClass.ErrorMB("Выберите поставщика");
                ProviderCb.Focus();
            }
            else
            {
                veterinaryEquipment = DBEntities.GetContext().VeterinaryEquipment
                                    .FirstOrDefault(l => l.IdVeterinaryEquipment ==
                                    veterinaryEquipment.IdVeterinaryEquipment);
                veterinaryEquipment.IdProvider = Int32.Parse(ProviderCb.SelectedValue.ToString());
                DBEntities.GetContext().SaveChanges();

                MBClass.InfoMB("Поставщик был привязан");
                NavigationService.Navigate(new ListVeterinaryEquipmentPage());
            }
        }
    }
}
