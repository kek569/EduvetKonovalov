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
                if (selectedFileName == "")
                {;
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
                    veterinaryEquipment.WhoWasReleased = WhoWasReleasedTb.Text;
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
                    veterinaryEquipment.WhoWasReleased = WhoWasReleasedTb.Text;
                    veterinaryEquipment.PhotoVeterinaryEquipment = ClassImage
                        .ConvertImageToArray(selectedFileName);
                    DBEntities.GetContext().SaveChanges();

                    MBClass.InfoMB("Данные о оборудование успешно отредактированы");
                    NavigationService.Navigate(new ListVeterinaryEquipmentPage());
                }
            }
            catch (DbEntityValidationException ex)
            {
                MBClass.ErrorMB(ex);
            }
        }
    }
}
