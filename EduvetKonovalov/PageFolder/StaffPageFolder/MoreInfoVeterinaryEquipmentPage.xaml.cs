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

namespace EduvetKonovalov.PageFolder.StaffPageFolder
{
    /// <summary>
    /// Логика взаимодействия для MoreInfoVeterinaryEquipmentPage.xaml
    /// </summary>
    public partial class MoreInfoVeterinaryEquipmentPage : Page
    {
        VeterinaryEquipment veterinaryEquipment = new VeterinaryEquipment();

        public MoreInfoVeterinaryEquipmentPage(VeterinaryEquipment veterinaryEquipment)
        {
            InitializeComponent();
            DataContext = veterinaryEquipment;
            this.veterinaryEquipment.IdVeterinaryEquipment =
                veterinaryEquipment.IdVeterinaryEquipment;

            TypeVeterinaryEquipmentCb.ItemsSource = DBEntities.
                GetContext().TypeVeterinaryEquipment.ToList();
            ComingCb.ItemsSource = DBEntities.GetContext().Coming.ToList();
            ConsumptionCb.ItemsSource = DBEntities.
                GetContext().Consumption.ToList();
            RemainderCb.ItemsSource = DBEntities.GetContext().Remainder.ToList();
        }
    }
}
