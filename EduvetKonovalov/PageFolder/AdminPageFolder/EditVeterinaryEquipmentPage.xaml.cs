using EduvetKonovalov.ClassFolder;
using EduvetKonovalov.DataFolder;
using Microsoft.Win32;
using System;
using System.Collections;
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

namespace EduvetKonovalov.PageFolder.AdminPageFolder
{
    /// <summary>
    /// Логика взаимодействия для EditVeterinaryEquipmentPage.xaml
    /// </summary>
    public partial class EditVeterinaryEquipmentPage : Page
    {
        VeterinaryEquipment veterinaryEquipment = new VeterinaryEquipment();

        public EditVeterinaryEquipmentPage(VeterinaryEquipment veterinaryEquipment)
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

            ComingOneCb.ItemsSource = DBEntities.GetContext().Coming.ToList();

            ConsumptionOneCb.ItemsSource = DBEntities.
                GetContext().Consumption.ToList();

            RemainderOneCb.ItemsSource = DBEntities.GetContext().Remainder.ToList();

            StaffCb.ItemsSource = DBEntities.GetContext().Staff.ToList();
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
                    veterinaryEquipment.PhotoVeterinaryEquipment =
                        ClassImage.ConvertImageToArray(selectedFileName);
                    PhotoIM.Source = ClassImage.ConvertByteArrayToImage
                        (veterinaryEquipment.PhotoVeterinaryEquipment);
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
                else if (StaffCb.SelectedIndex <= -1)
                {
                    MBClass.ErrorMB("Введите кому отпущено");
                    StaffCb.Focus();
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
                else if (string.IsNullOrWhiteSpace(AmountConsumptionTb.Text))
                {
                    MBClass.ErrorMB("Введите кол-во в расходе");
                    AmountConsumptionTb.Focus();
                }
                else if (string.IsNullOrWhiteSpace(SumConsumptionTb.Text))
                {
                    MBClass.ErrorMB("Введите сумму в остатке");
                    SumComingTb.Focus();
                }
                else if (string.IsNullOrWhiteSpace(AmountRemainderTb.Text))
                {
                    MBClass.ErrorMB("Введите кол-во в остатке");
                    AmountRemainderTb.Focus();
                }
                else if (string.IsNullOrWhiteSpace(SumRemainderTb.Text))
                {
                    MBClass.ErrorMB("Введите сумму в приход");
                    SumRemainderTb.Focus();
                }
                else
                {
                    if (selectedFileName == "")
                    {
                        veterinaryEquipment = DBEntities.GetContext().VeterinaryEquipment
                                .FirstOrDefault(l => l.IdVeterinaryEquipment ==
                                veterinaryEquipment.IdVeterinaryEquipment);
                        veterinaryEquipment.Coming.AmountComing =
                            Int32.Parse(AmountComingTb.Text);
                        veterinaryEquipment.Coming.SumComing =
                            Convert.ToDecimal(SumComingTb.Text.Replace(@".", @","));
                        veterinaryEquipment.Consumption.AmountConsumption =
                            Int32.Parse
                           (AmountConsumptionTb.Text);
                        veterinaryEquipment.Consumption.SumConsumption =
                            Convert.ToDecimal(SumConsumptionTb.Text.Replace(@".", @","));
                        veterinaryEquipment.Remainder.AmountRemainder = Int32.Parse
                            (AmountRemainderTb.Text);
                        veterinaryEquipment.Remainder.SumRemainder =
                            Convert.ToDecimal(SumRemainderTb.Text.Replace(@".", @","));

                        veterinaryEquipment.NameVeterinaryEquipment =
                            NameVeterinaryEquipmentTb.Text;
                        veterinaryEquipment.IdTypeVeterinaryEquipment = Int32.Parse
                            (TypeVeterinaryEquipmentCb.SelectedValue.ToString());
                        veterinaryEquipment.WhereDidItComeFrom = WhereDidItComeFromTb.Text;
                        veterinaryEquipment.IdStaff = Int32.Parse(StaffCb.SelectedValue.ToString());
                        DBEntities.GetContext().SaveChanges();

                        MBClass.InfoMB("Данные о оборудование успешно отредактированы");
                        NavigationService.Navigate(new ListVeterinaryEquipmentPage());
                    }
                    else
                    {
                        veterinaryEquipment = DBEntities.GetContext().VeterinaryEquipment
                                .FirstOrDefault(l => l.IdVeterinaryEquipment ==
                                veterinaryEquipment.IdVeterinaryEquipment);
                        veterinaryEquipment.Coming.AmountComing =
                            Int32.Parse(AmountComingTb.Text);
                        veterinaryEquipment.Coming.SumComing =
                            Convert.ToDecimal(SumComingTb.Text.Replace(@".", @","));
                        veterinaryEquipment.Consumption.AmountConsumption =
                            Int32.Parse
                           (AmountConsumptionTb.Text);
                        veterinaryEquipment.Consumption.SumConsumption =
                            Convert.ToDecimal(SumConsumptionTb.Text.Replace(@".", @","));
                        veterinaryEquipment.Remainder.AmountRemainder = Int32.Parse
                            (AmountRemainderTb.Text);
                        veterinaryEquipment.Remainder.SumRemainder =
                            Convert.ToDecimal(SumRemainderTb.Text.Replace(@".", @","));

                        veterinaryEquipment.NameVeterinaryEquipment =
                            NameVeterinaryEquipmentTb.Text;
                        veterinaryEquipment.IdTypeVeterinaryEquipment = Int32.Parse
                            (TypeVeterinaryEquipmentCb.SelectedValue.ToString());
                        veterinaryEquipment.WhereDidItComeFrom = WhereDidItComeFromTb.Text;
                        veterinaryEquipment.IdStaff = Int32.Parse(StaffCb.SelectedValue.ToString());
                        veterinaryEquipment.PhotoVeterinaryEquipment = ClassImage
                            .ConvertImageToArray(selectedFileName);
                        DBEntities.GetContext().SaveChanges();

                        MBClass.InfoMB("Данные о оборудование успешно отредактированы");
                        NavigationService.Navigate(new ListVeterinaryEquipmentPage());
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                MBClass.ErrorMB(ex);
            }
        }

        private void FixBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ComingCb.SelectedIndex <= -1 ||
                ConsumptionCb.SelectedIndex <= -1 ||
                RemainderCb.SelectedIndex <= -1)
            {
                MBClass.ErrorMB("Произошла непредвиденая ошибка");
            }
            else
            {
                AmountComingTb.Text = ComingOneCb.Text;
                SumComingTb.Text = ComingCb.Text;
                AmountConsumptionTb.Text = ConsumptionOneCb.Text;
                SumConsumptionTb.Text = ConsumptionCb.Text;
                AmountRemainderTb.Text = RemainderOneCb.Text;
                SumRemainderTb.Text = RemainderCb.Text;

                string a = ComingCb.SelectedValue.ToString();
                (App.Current as App).EditComingAdmin = a;
                string b = ConsumptionCb.SelectedValue.ToString();
                (App.Current as App).EditConsumptionAdmin = b;
                string c = RemainderCb.SelectedValue.ToString();
                (App.Current as App).EditRemainderAdmin = c;
            }
        }
    }
}
