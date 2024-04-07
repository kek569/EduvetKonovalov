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
    /// Логика взаимодействия для EditVeterinaryEquipmentPage.xaml
    /// </summary>
    public partial class EditVeterinaryEquipmentPage : Page
    {
        RequestVeterinaryEquipment requestVeterinaryEquipment = new RequestVeterinaryEquipment();

        public EditVeterinaryEquipmentPage(RequestVeterinaryEquipment requestVeterinaryEquipment)
        {
            InitializeComponent();
            DataContext = requestVeterinaryEquipment;
            this.requestVeterinaryEquipment.IdRequestVeterinaryEquipment =
                requestVeterinaryEquipment.IdRequestVeterinaryEquipment;

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

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
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
                    MBClass.ErrorMB("Введите откуда поступило");
                    WhereDidItComeFromTb.Focus();
                }
                else if (TypeVeterinaryEquipmentCb.SelectedIndex <= -1)
                {
                    MBClass.ErrorMB("Введите тип оборудование");
                    TypeVeterinaryEquipmentCb.Focus();
                }
                else if (string.IsNullOrWhiteSpace(AmountComingTb.Text))
                {
                    MBClass.ErrorMB("Введите кол-во в приходе");
                    AmountComingTb.Focus();
                }
                else if (string.IsNullOrWhiteSpace(SumComingTb.Text))
                {
                    MBClass.ErrorMB("Введите сумму в приходе");
                    SumComingTb.Focus();
                }
                else
                {
                    VeterinaryEquipment veterinaryEquipment = new VeterinaryEquipment();
                    string selected_dept = (App.Current as App).DeptName;
                    veterinaryEquipment = DBEntities.GetContext().VeterinaryEquipment
                                    .FirstOrDefault(v => v.Staff.User.LoginUser ==
                                    selected_dept);

                    if (selectedFileName == "")
                    {
                        requestVeterinaryEquipment = DBEntities.GetContext().RequestVeterinaryEquipment
                                .FirstOrDefault(r => r.IdRequestVeterinaryEquipment ==
                                requestVeterinaryEquipment.IdRequestVeterinaryEquipment);
                        requestVeterinaryEquipment.AmountRequest =
                            Int32.Parse(AmountComingTb.Text);
                        requestVeterinaryEquipment.SumRequest =
                            Convert.ToDecimal(SumComingTb.Text.Replace(@".", @","));

                        requestVeterinaryEquipment.NameVeterinaryEquipment =
                            NameVeterinaryEquipmentTb.Text;
                        requestVeterinaryEquipment.IdTypeVeterinaryEquipment = Int32.Parse
                            (TypeVeterinaryEquipmentCb.SelectedValue.ToString());
                        requestVeterinaryEquipment.WhereDidItComeFrom = WhereDidItComeFromTb.Text;
                        requestVeterinaryEquipment.IdStaff = Int32.Parse(veterinaryEquipment.IdStaff.ToString());
                        DBEntities.GetContext().SaveChanges();

                        MBClass.InfoMB("Данные о запросе успешно отредактированы");
                        NavigationService.Navigate(new ListVeterinaryEquipmentPage());
                    }
                    else
                    {
                        requestVeterinaryEquipment = DBEntities.GetContext().RequestVeterinaryEquipment
                                .FirstOrDefault(r => r.IdRequestVeterinaryEquipment ==
                                requestVeterinaryEquipment.IdRequestVeterinaryEquipment);
                        requestVeterinaryEquipment.AmountRequest =
                            Int32.Parse(AmountComingTb.Text);
                        requestVeterinaryEquipment.SumRequest =
                            Convert.ToDecimal(SumComingTb.Text.Replace(@".", @","));

                        requestVeterinaryEquipment.NameVeterinaryEquipment =
                            NameVeterinaryEquipmentTb.Text;
                        requestVeterinaryEquipment.IdTypeVeterinaryEquipment = Int32.Parse
                            (TypeVeterinaryEquipmentCb.SelectedValue.ToString());
                        requestVeterinaryEquipment.WhereDidItComeFrom = WhereDidItComeFromTb.Text;
                        requestVeterinaryEquipment.IdStaff = Int32.Parse(veterinaryEquipment.IdStaff.ToString());
                        requestVeterinaryEquipment.PhotoVeterinaryEquipment = ClassImage
                            .ConvertImageToArray(selectedFileName);
                        DBEntities.GetContext().SaveChanges();

                        MBClass.InfoMB("Данные о запросе успешно отредактированы");
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
