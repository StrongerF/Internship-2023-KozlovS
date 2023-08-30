using ProductStoreClassLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PP2023_KozlovS_ISP3120
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static ServerRequests serverRequests;
        internal static ServerRequests ServerRequests
        {
            get
            {
                return serverRequests;
            }
            set
            {
                serverRequests = value;
                MainWindow = new MainWindow();
                MainWindow.Show();
                AuthWindow.Close();
            }
        }
        internal static AuthWindow AuthWindow { get; set; }
        internal static MainWindow MainWindow { get; set; }

        internal static void InfoMessageBox(string message)
        {
            MessageBox.Show(message, "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        internal static void ErrorMessageBox(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
