﻿using EduvetKonovalov.DataFolder;
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

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ListVeterinaryEquipmentPage());
        }
    }
}