﻿using System;
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

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri("pack://application:,,,/GUI;component/Resources/footballer.jpg");
            logo.EndInit();
            this.FootballerImage.Source = logo;
        }

        private void OnButtonCreatePersonClick(object sender, RoutedEventArgs e)
        {
            CreatePlayerWindow createPlayerWindow = new CreatePlayerWindow();
            createPlayerWindow.ShowDialog();
        }

        private void OnButtonShowPersonsClick(object sender, RoutedEventArgs e)
        {
            ShowPersonsWindow showPersonsWindow = new ShowPersonsWindow();
            showPersonsWindow.ShowDialog();
        }

        private void OnNewClubButtonClick(object sender, RoutedEventArgs e)
        {
            CreateClubWindow createClubWindow = new CreateClubWindow();
            createClubWindow.ShowDialog();
        }

        private void OnShowClubsButtonClick(object sender, RoutedEventArgs e)
        {
            ShowClubsWindow showClubsWindow = new ShowClubsWindow();
            try
            {
                showClubsWindow.ShowDialog();
            }
            catch (InvalidOperationException)
            {
                                
            }
            
        }

    }
}
