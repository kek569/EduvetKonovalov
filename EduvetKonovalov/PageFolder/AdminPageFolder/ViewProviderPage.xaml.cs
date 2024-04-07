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
    /// Логика взаимодействия для ViewProviderPage.xaml
    /// </summary>
    public partial class ViewProviderPage : Page
    {
        Provider provider = new Provider();

        public ViewProviderPage(VeterinaryEquipment veterinaryEquipment)
        {
            InitializeComponent();
            provider = DBEntities.GetContext().Provider
                                .FirstOrDefault(p => p.IdProvider ==
                                veterinaryEquipment.IdProvider);
            DataContext = provider;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(NameProviderTb.Text))
                {
                    MBClass.ErrorMB("Введите наименование поставщика");
                    NameProviderTb.Focus();
                }
                else if (string.IsNullOrWhiteSpace(NumberPhoneProviderTb.Text))
                {
                    MBClass.ErrorMB("Введите номер телефона");
                    NumberPhoneProviderTb.Focus();
                }
                else if (string.IsNullOrWhiteSpace(EmailProviderTb.Text))
                {
                    MBClass.ErrorMB("Введите электроную почту");
                    EmailProviderTb.Focus();
                }
                else
                {
                    provider = DBEntities.GetContext().Provider
                                    .FirstOrDefault(p => p.IdProvider ==
                                    provider.IdProvider);
                    provider.NameProvider = NameProviderTb.Text;
                    provider.NumberPhoneProvider = NumberPhoneProviderTb.Text;
                    provider.EmailProvider = EmailProviderTb.Text;
                    DBEntities.GetContext().SaveChanges();

                    MBClass.InfoMB("Данные о поставщике были успешно изменнены");
                    NavigationService.Navigate(new ListVeterinaryEquipmentPage());
                }
            }
            catch (Exception ex) 
            {
                MBClass.ErrorMB(ex.Message);
            }
        }
    }
}
