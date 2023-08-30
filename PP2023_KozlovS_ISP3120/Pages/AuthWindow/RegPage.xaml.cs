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
using ProductStoreClassLibrary;
using ProductStoreClassLibrary.Entities;

namespace PP2023_KozlovS_ISP3120.Pages.AuthWindow
{
    /// <summary>
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent();
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            bool isRegistered = false;

            User newUser = new User()
            {
                FullName = FullNameTextBox.Text,
                PhoneNumber = PhoneNumberTextBox.Text,
                Password = PasswordTextBox.Password
            };
            try
            {
                isRegistered = ServerRequests.RegisterUser(newUser, SecondPasswordTextBox.Password, true);
                if (isRegistered)
                {
                    App.InfoMessageBox("Вы успешно зарегистрировались!");
                    NavigationService.GoBack();
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

        private void AuthHyperlink_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void FullNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FullNameTextBox.Text))
            {
                RegButton.IsEnabled = false;
                FullNameCorrectTextBlock.Visibility = Visibility.Visible;
                FullNameCorrectTextBlock.Text = "ФИО должно быть введено!";
            }
            else if (FullNameTextBox.Text.Length > 100)
            {
                RegButton.IsEnabled = false;
                FullNameCorrectTextBlock.Visibility = Visibility.Visible;
                FullNameCorrectTextBlock.Text = "ФИО должно быть не более 100 символов!";
            }
            else
            {
                FullNameCorrectTextBlock.Visibility = Visibility.Collapsed;
                CheckLength();
            }
        }

        private void PhoneNumberTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!Regex.IsMatch(PhoneNumberTextBox.Text, @"^\+7"))
            {
                RegButton.IsEnabled = false;
                PhoneNumberCorrectTextBlock.Visibility = Visibility.Visible;
                PhoneNumberCorrectTextBlock.Text = "Номер телефона должен быть в формате +7!";
            }
            else if (!Regex.IsMatch(PhoneNumberTextBox.Text, @"^\+7\d{10}$"))
            {
                RegButton.IsEnabled = false;
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
                RegButton.IsEnabled = false;
                PasswordCorrectTextBlock.Visibility = Visibility.Visible;
                PasswordCorrectTextBlock.Text = "Пароль должен быть введён!";
            }
            else if (PasswordTextBox.Password.Length < 8 ||
                     PasswordTextBox.Password.Length > 32)
            {
                RegButton.IsEnabled = false;
                PasswordCorrectTextBlock.Visibility = Visibility.Visible;
                PasswordCorrectTextBlock.Text = "Пароль должен содержать в себе от 8 до 32 символов включительно!";
            }
            else if (!(Regex.IsMatch(PasswordTextBox.Password, @"\W") &&
                       Regex.IsMatch(PasswordTextBox.Password, @"\d") &&
                       (Regex.IsMatch(PasswordTextBox.Password, @"[a-z]") 
                       || Regex.IsMatch(PasswordTextBox.Password, @"[а-я]")) &&
                       (Regex.IsMatch(PasswordTextBox.Password, @"[A-Z]") 
                       || Regex.IsMatch(PasswordTextBox.Password, @"[А-Я]"))))
            {
                RegButton.IsEnabled = false;
                PasswordCorrectTextBlock.Visibility = Visibility.Visible;
                PasswordCorrectTextBlock.Text = "Пароль должен содержать в себе хотя бы одну строчную букву, прописную букву, цифру и любой другой символ!";
            }
            else
            {
                PasswordCorrectTextBlock.Visibility = Visibility.Collapsed;
                CheckLength();
            }
            if (SecondPasswordTextBox.Password != PasswordTextBox.Password)
            {
                RegButton.IsEnabled = false;
                SecondPasswordCorrectTextBlock.Visibility = Visibility.Visible;
                SecondPasswordCorrectTextBlock.Text = "Пароли должны совпадать!";
            }
            else
            {
                SecondPasswordCorrectTextBlock.Visibility = Visibility.Collapsed;
                CheckLength();
            }
        }

        private void SecondPasswordTextBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (SecondPasswordTextBox.Password != PasswordTextBox.Password)
            {
                RegButton.IsEnabled = false;
                SecondPasswordCorrectTextBlock.Visibility = Visibility.Visible;
                SecondPasswordCorrectTextBlock.Text = "Пароли должны совпадать!";
            }
            else
            {
                SecondPasswordCorrectTextBlock.Visibility = Visibility.Collapsed;
                CheckLength();
            }
        }


        private bool CheckLength()
        {

            bool isButtonEnabled = FullNameTextBox.Text.Length != 0 &&
                                   PhoneNumberTextBox.Text.Length != 0 &&
                                   PasswordTextBox.Password.Length != 0 &&
                                   SecondPasswordTextBox.Password.Length != 0
                                   &&
                                   FullNameCorrectTextBlock.Visibility == Visibility.Collapsed &&
                                   PhoneNumberCorrectTextBlock.Visibility == Visibility.Collapsed &&
                                   PasswordCorrectTextBlock.Visibility == Visibility.Collapsed &&
                                   SecondPasswordCorrectTextBlock.Visibility == Visibility.Collapsed;

            RegButton.IsEnabled = isButtonEnabled;
            return isButtonEnabled;
        }

    }
}
