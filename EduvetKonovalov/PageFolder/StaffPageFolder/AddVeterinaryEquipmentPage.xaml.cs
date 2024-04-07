using EduvetKonovalov.ClassFolder;
using EduvetKonovalov.DataFolder;
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

namespace EduvetKonovalov.PageFolder.StaffPageFolder
{
    /// <summary>
    /// Логика взаимодействия для AddVeterinaryEquipmentPage.xaml
    /// </summary>
    public partial class AddVeterinaryEquipmentPage : Page
    {
        VeterinaryEquipment veterinaryEquipment = new VeterinaryEquipment();
        RequestVeterinaryEquipment requestVeterinaryEquipment = new RequestVeterinaryEquipment();

        public AddVeterinaryEquipmentPage()
        {
            InitializeComponent();
            TypeVeterinaryEquipmentCb.ItemsSource = DBEntities.
                GetContext().TypeVeterinaryEquipment.ToList();


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
                    requestVeterinaryEquipment.PhotoVeterinaryEquipment =
                        ClassImage.ConvertImageToArray(selectedFileName);
                    PhotoIM.Source = ClassImage.ConvertByteArrayToImage
                        (requestVeterinaryEquipment.PhotoVeterinaryEquipment);
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void AddVeterinaryEquipmentBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(NameVeterinaryEquipmentTb.Text))
                {
                    MBClass.ErrorMB("Введите название оборудование");
                    NameVeterinaryEquipmentTb.Focus();
                }
                else if (string.IsNullOrWhiteSpace(WhereDidItComeFromTb.Text))
                {
                    MBClass.ErrorMB("Введите откуда поступит оборудование");
                    WhereDidItComeFromTb.Focus();
                }
                else if (TypeVeterinaryEquipmentCb.SelectedIndex <= -1)
                {
                    MBClass.ErrorMB("Введите тип оборудование");
                    TypeVeterinaryEquipmentCb.Focus();
                }
                else if (string.IsNullOrWhiteSpace(AmountComingTb.Text))
                {
                    MBClass.ErrorMB("Введите кол-во запросаемой оборудование");
                    AmountComingTb.Focus();
                }
                else if (string.IsNullOrWhiteSpace(SumComingTb.Text))
                {
                    MBClass.ErrorMB("Введите сумму запросаемой оборудование");
                    SumComingTb.Focus();
                }
                else
                {
                    string selected_dept = (App.Current as App).DeptName;
                    veterinaryEquipment = DBEntities.GetContext().VeterinaryEquipment
                                    .FirstOrDefault(v => v.Staff.User.LoginUser ==
                                    selected_dept);

                    if (selectedFileName == "")
                    {
                        DatePicker datePicker = new DatePicker();
                        datePicker.SelectedDate = DateTime.Now.Date;
                        var RequestVeterinaryEquipmentAdd = new RequestVeterinaryEquipment()
                        {
                            NameVeterinaryEquipment = NameVeterinaryEquipmentTb.Text,
                            IdTypeVeterinaryEquipment = Int32.Parse
                            (TypeVeterinaryEquipmentCb.SelectedValue.ToString()),
                            RecordingDate = System.DateTime.Parse(datePicker.Text),
                            WhereDidItComeFrom = WhereDidItComeFromTb.Text,
                            IdStaff = Int32.Parse(veterinaryEquipment.IdStaff.ToString()),
                            AmountRequest = Int32.Parse(AmountComingTb.Text),
                            SumRequest = Int32.Parse(SumComingTb.Text.Replace(@".", @","))
                        };
                        DBEntities.GetContext().RequestVeterinaryEquipment.
                            Add(RequestVeterinaryEquipmentAdd);
                        DBEntities.GetContext().SaveChanges();

                        MBClass.InfoMB("Запрос был создан, расмотрим его в ближайщие время!");
                        NavigationService.Navigate(new ListVeterinaryEquipmentPage());
                    }
                    else
                    {
                        DatePicker datePicker = new DatePicker();
                        datePicker.SelectedDate = DateTime.Now.Date;
                        var RequestVeterinaryEquipmentAdd = new RequestVeterinaryEquipment()
                        {
                            NameVeterinaryEquipment = NameVeterinaryEquipmentTb.Text,
                            IdTypeVeterinaryEquipment = Int32.Parse
                            (TypeVeterinaryEquipmentCb.SelectedValue.ToString()),
                            RecordingDate = System.DateTime.Parse(datePicker.Text),
                            WhereDidItComeFrom = WhereDidItComeFromTb.Text,
                            IdStaff = Int32.Parse(veterinaryEquipment.IdStaff.ToString()),
                            AmountRequest = Int32.Parse(AmountComingTb.Text),
                            SumRequest = Int32.Parse(SumComingTb.Text.Replace(@".", @",")),
                            PhotoVeterinaryEquipment = ClassImage
                            .ConvertImageToArray(selectedFileName)
                        };
                        DBEntities.GetContext().RequestVeterinaryEquipment.
                            Add(RequestVeterinaryEquipmentAdd);
                        DBEntities.GetContext().SaveChanges();

                        MBClass.InfoMB("Запрос был создан, расмотрим его в ближайщие время!");
                        NavigationService.Navigate(new ListVeterinaryEquipmentPage());
                    }
                } 
            }
            catch (DbEntityValidationException ex)
            {
                MBClass.ErrorMB(ex);
            }
        }
    }
}
