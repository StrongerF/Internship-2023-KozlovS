using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using Microsoft.Data.SqlClient;
using PP2023_KozlovS_ISP3120.Pages.AuthWindow;
using ProductStoreClassLibrary;
using ProductStoreClassLibrary.Entities;

namespace PP2023_KozlovS_ISP3120.Pages.AuthWindow
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
            User user = new User();
            DataContext = user;
        }

        private void AuthButton_Click(object sender, RoutedEventArgs e)
        {
            bool isAuthorized = false;

            User user = new User()
            {
                PhoneNumber = PhoneNumberTextBox.Text,
                Password = PasswordTextBox.Password
            };
            try
            {
                ServerRequests serverRequests;
                isAuthorized = ServerRequests.UserAuthorization(user, out serverRequests);
                if (isAuthorized)
                {
                    App.ServerRequests = serverRequests;
                }
                else
                {
                    App.ErrorMessageBox("Что-то пошло не так!");
                }
            }
            catch (SqlException)
            {
                App.ErrorMessageBox("Произошла ошибка с базой данных!");
            }
            catch (Exception ex)
            {
                App.ErrorMessageBox(ex.Message);
            }
        }

        private void RegHyperlink_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegPage());
        }


        private void PhoneNumberTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!Regex.IsMatch(PhoneNumberTextBox.Text, @"^\+7"))
            {
                AuthButton.IsEnabled = false;
                PhoneNumberCorrectTextBlock.Visibility = Visibility.Visible;
                PhoneNumberCorrectTextBlock.Text = "Номер телефона должен быть в формате +7!";
            }
            else if (!Regex.IsMatch(PhoneNumberTextBox.Text, @"^\+7\d{10}$"))
            {
                AuthButton.IsEnabled = false;
                PhoneNumberCorrectTextBlock.Visibility = Visibility.Visible;
                PhoneNumberCorrectTextBlock.Text = "Номер телефона должен содержать в себе \"+7\" и 11 цифр!";
            }
            else
            {
                PhoneNumberCorrectTextBlock.Visibility = Visibility.Collapsed;
                CheckLength();
            }
        }


        private void PasswordTextBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (PasswordTextBox.Password == "")
            {
                AuthButton.IsEnabled = false;
                PasswordCorrectTextBlock.Visibility = Visibility.Visible;
                PasswordCorrectTextBlock.Text = "Пароль должен быть введён!";
            }
            else if (PasswordTextBox.Password.Length < 8 ||
                     PasswordTextBox.Password.Length > 32)
            {
                AuthButton.IsEnabled = false;
                PasswordCorrectTextBlock.Visibility = Visibility.Visible;
                PasswordCorrectTextBlock.Text = "Пароль должен содержать в себе от 8 до 32 символов включительно!";
            }
            else
            {
                PasswordCorrectTextBlock.Visibility = Visibility.Collapsed;
                CheckLength();
            }
        }


        private bool CheckLength()
        {
            
            bool isButtonEnabled = PhoneNumberTextBox.Text.Length != 0 && 
                                   PasswordTextBox.Password.Length != 0
                                   &&
                                   PhoneNumberCorrectTextBlock.Visibility == Visibility.Collapsed &&
                                   PasswordCorrectTextBlock.Visibility == Visibility.Collapsed;

            AuthButton.IsEnabled = isButtonEnabled;
            return isButtonEnabled;
        }
    }
}
