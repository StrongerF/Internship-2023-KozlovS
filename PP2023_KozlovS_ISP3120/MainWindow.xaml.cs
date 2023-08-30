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
using PP2023_KozlovS_ISP3120.Pages.MainWindow;
using ProductStoreClassLibrary;

namespace PP2023_KozlovS_ISP3120
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ServerRequests ServerRequests { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            
            MainFrame.NavigationService.Navigate(new MainPage());
            ServerRequests = App.ServerRequests;

            
        }
    }
}
