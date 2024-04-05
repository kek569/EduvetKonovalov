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
    /// Логика взаимодействия для AddProviderPage.xaml
    /// </summary>
    public partial class AddProviderPage : Page
    {
        VeterinaryEquipment veterinaryEquipment = new VeterinaryEquipment();

        public AddProviderPage(VeterinaryEquipment veterinaryEquipment)
        {
            InitializeComponent();
            this.veterinaryEquipment.IdVeterinaryEquipment =
                veterinaryEquipment.IdVeterinaryEquipment;
            ProviderCb.ItemsSource = DBEntities.GetContext().Provider.ToList();
        }

        private string Lastid;

        private void AddProviderBtn_Click(object sender, RoutedEventArgs e)
        {
            ProviderLastId();
            var providerAdd = new Provider()
            {
                NameProvider = NameProviderTb.Text,
                NumberPhoneProvider = NumberPhoneProviderTb.Text,
                EmailProvider = EmailProviderTb.Text
            };
            DBEntities.GetContext().Provider.Add(providerAdd);
            DBEntities.GetContext().SaveChanges();

            veterinaryEquipment = DBEntities.GetContext().VeterinaryEquipment
                                .FirstOrDefault(l => l.IdVeterinaryEquipment ==
                                veterinaryEquipment.IdVeterinaryEquipment);
            veterinaryEquipment.IdProvider = Int32.Parse(Lastid);
            DBEntities.GetContext().SaveChanges();

            MBClass.InfoMB("Поставщик был добавлин");
            NavigationService.Navigate(new ListVeterinaryEquipmentPage());
        }

        public void ProviderLastId()
        {
            try
            {
                ProviderCb.SelectedValue = 1;

                for (Int32 i = 0; i < 9999999; i++)
                {
                    if (string.IsNullOrEmpty(ProviderCb.Text))
                    {

                    }
                    else
                    {
                        i = Int32.Parse(ProviderCb.SelectedValue.ToString());
                        i = i + 1;
                        ProviderCb.SelectedValue = i;

                        //MBClass.InfoMB("" + i);
                        Lastid = i.ToString();
                    }
                }
                /*Int32 b = Int32.Parse(LoginCb.SelectedValue.ToString());
                LoginCb.SelectedValue = b - 1;*/
                string selected_Lastid = Lastid;
                Int32 a = Int32.Parse(selected_Lastid);
                if (a <= 0)
                {
                    a = 1;
                    Lastid = a.ToString();
                }

            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }
    }
}
