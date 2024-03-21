﻿using EduvetKonovalov.ClassFolder;
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
        public AddVeterinaryEquipmentPage()
        {
            InitializeComponent();
            TypeVeterinaryEquipmentCb.ItemsSource = DBEntities.
                GetContext().TypeVeterinaryEquipment.ToList();
            ComingCb.ItemsSource = DBEntities.GetContext().Coming.ToList();
            ConsumptionCb.ItemsSource = DBEntities.
                GetContext().Consumption.ToList();
            RemainderCb.ItemsSource = DBEntities.GetContext().Remainder.ToList();
        }

        private void LoadPhotoBtn_Click(object sender, RoutedEventArgs e)
        {
            AddPhoto();
        }

        VeterinaryEquipment veterinaryEquipment =
            new VeterinaryEquipment();
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

        private void AddVeterinaryEquipmentBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (selectedFileName == "")
                {
                    Coming();
                    Consumption();
                    Remainder();

                    string selected_Coming = (App.Current as App)
                        .AddComingStaff;
                    string selected_Consumption = (App.Current as App)
                        .AddConsumptionStaff;
                    string selected_Remainder = (App.Current as App)
                        .AddRemainderStaff;

                    var сomingAdd = new Coming()
                    {
                        AmountComing = Int32.Parse(AmountComingTb.Text),
                        SumComing = Convert.ToDecimal
                        (SumComingTb.Text.Replace(@".", @","))
                    };
                    DBEntities.GetContext().Coming.Add(сomingAdd);
                    DBEntities.GetContext().SaveChanges();

                    var consumptionAdd = new Consumption()
                    {
                        AmountConsumption = Int32.Parse
                        (AmountConsumptionTb.Text),
                        SumConsumption = Convert.ToDecimal
                        (SumConsumptionTb.Text.Replace(@".", @","))
                    };
                    DBEntities.GetContext().Consumption.Add(consumptionAdd);
                    DBEntities.GetContext().SaveChanges();

                    var remainderAdd = new Remainder()
                    {
                        AmountRemainder = Int32.Parse(AmountRemainderTb.Text),
                        SumRemainder = Convert.ToDecimal
                        (SumRemainderTb.Text.Replace(@".", @","))
                    };
                    DBEntities.GetContext().Remainder.Add(remainderAdd);
                    DBEntities.GetContext().SaveChanges();

                    DatePicker datePicker = new DatePicker();
                    datePicker.SelectedDate = DateTime.Now.Date;
                    var veterinaryEquipmentAdd = new VeterinaryEquipment()
                    {
                        NameVeterinaryEquipment = NameVeterinaryEquipmentTb.Text,
                        IdTypeVeterinaryEquipment = Int32.Parse
                        (TypeVeterinaryEquipmentCb.SelectedValue.ToString()),
                        RecordingDate = System.DateTime.Parse(datePicker.Text),
                        WhereDidItComeFrom = WhereDidItComeFromTb.Text,
                        WhoWasReleased = WhoWasReleasedTb.Text,
                        IdComing = Int32.Parse(selected_Coming),
                        IdConsumption = Int32.Parse(selected_Consumption),
                        IdRemainder = Int32.Parse(selected_Remainder)
                    };
                    DBEntities.GetContext().VeterinaryEquipment.
                        Add(veterinaryEquipmentAdd);
                    DBEntities.GetContext().SaveChanges();

                    MBClass.InfoMB("Данные о оборудование успешно добавлены");
                    NavigationService.Navigate(new ListVeterinaryEquipmentPage());
                }
                else
                {
                    Coming();
                    Consumption();
                    Remainder();

                    string selected_Coming = (App.Current as App)
                        .AddComingStaff;
                    string selected_Consumption = (App.Current as App)
                        .AddConsumptionStaff;
                    string selected_Remainder = (App.Current as App)
                        .AddRemainderStaff;

                    var сomingAdd = new Coming()
                    {
                        AmountComing = Int32.Parse(AmountComingTb.Text),
                        SumComing = Convert.ToDecimal
                        (SumComingTb.Text.Replace(@".", @","))
                    };
                    DBEntities.GetContext().Coming.Add(сomingAdd);
                    DBEntities.GetContext().SaveChanges();

                    var consumptionAdd = new Consumption()
                    {
                        AmountConsumption = Int32.Parse
                        (AmountConsumptionTb.Text),
                        SumConsumption = Convert.ToDecimal
                        (SumConsumptionTb.Text.Replace(@".", @","))
                    };
                    DBEntities.GetContext().Consumption.Add(consumptionAdd);
                    DBEntities.GetContext().SaveChanges();

                    var remainderAdd = new Remainder()
                    {
                        AmountRemainder = Int32.Parse(AmountRemainderTb.Text),
                        SumRemainder = Convert.ToDecimal
                        (SumRemainderTb.Text.Replace(@".", @","))
                    };
                    DBEntities.GetContext().Remainder.Add(remainderAdd);
                    DBEntities.GetContext().SaveChanges();

                    DatePicker datePicker = new DatePicker();
                    datePicker.SelectedDate = DateTime.Now.Date;
                    var veterinaryEquipmentAdd = new VeterinaryEquipment()
                    {
                        NameVeterinaryEquipment = NameVeterinaryEquipmentTb.Text,
                        IdTypeVeterinaryEquipment = Int32.Parse
                        (TypeVeterinaryEquipmentCb.SelectedValue.ToString()),
                        RecordingDate = System.DateTime.Parse(datePicker.Text),
                        WhereDidItComeFrom = WhereDidItComeFromTb.Text,
                        WhoWasReleased = WhoWasReleasedTb.Text,
                        IdComing = Int32.Parse(selected_Coming),
                        IdConsumption = Int32.Parse(selected_Consumption),
                        IdRemainder = Int32.Parse(selected_Remainder),
                        PhotoVeterinaryEquipment = ClassImage
                        .ConvertImageToArray(selectedFileName)
                    };
                    DBEntities.GetContext().VeterinaryEquipment.
                        Add(veterinaryEquipmentAdd);
                    DBEntities.GetContext().SaveChanges();

                    MBClass.InfoMB("Данные о оборудование успешно добавлены");
                    NavigationService.Navigate(new ListVeterinaryEquipmentPage());
                }
            }
            catch (DbEntityValidationException ex)
            {
                MBClass.ErrorMB(ex);
            }
        }

        public void Coming()
        {
            try
            {
                ComingCb.SelectedValue = 1;

                for (Int32 i = 0; i < 9999999; i++)
                {
                    if (string.IsNullOrEmpty(ComingCb.Text)) { }
                    else
                    {
                        i = Int32.Parse(ComingCb.SelectedValue.ToString());
                        i = i + 1;
                        ComingCb.SelectedValue = i;

                        (App.Current as App).AddComingStaff = i.ToString();
                    }
                }
                string selected_Coming = (App.Current as App).AddComingStaff;
                Int32 a = Int32.Parse(selected_Coming);
                if (a <= 0)
                {
                    a = 1;
                    (App.Current as App).AddComingStaff = a.ToString();
                }
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }

        public void Consumption()
        {
            try
            {
                ConsumptionCb.SelectedValue = 1;

                for (Int32 i = 0; i < 9999999; i++)
                {
                    if (string.IsNullOrEmpty(ConsumptionCb.Text)) { }
                    else
                    {
                        i = Int32.Parse(ConsumptionCb.SelectedValue.ToString());
                        i = i + 1;
                        ConsumptionCb.SelectedValue = i;

                        (App.Current as App).AddConsumptionStaff = i.ToString();
                    }
                }
                string selected_Consumption = (App.Current as App).AddConsumptionStaff;
                Int32 a = Int32.Parse(selected_Consumption);
                if (a <= 0)
                {
                    a = 1;
                    (App.Current as App).AddConsumptionStaff = a.ToString();
                }
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }

        public void Remainder()
        {
            try
            {
                RemainderCb.SelectedValue = 1;

                for (Int32 i = 0; i < 9999999; i++)
                {
                    if (string.IsNullOrEmpty(RemainderCb.Text)) { }
                    else
                    {
                        i = Int32.Parse(RemainderCb.SelectedValue.ToString());
                        i = i + 1;
                        RemainderCb.SelectedValue = i;

                        (App.Current as App).AddRemainderStaff = i.ToString();
                    }
                }
                string selected_Remainder = (App.Current as App).AddRemainderStaff;
                Int32 a = Int32.Parse(selected_Remainder);
                if (a <= 0)
                {
                    a = 1;
                    (App.Current as App).AddRemainderStaff = a.ToString();
                }
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
        }
    }
}