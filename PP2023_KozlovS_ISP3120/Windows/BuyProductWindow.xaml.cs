using Microsoft.Data.SqlClient;
using ProductStoreClassLibrary.Entities;
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
using System.Windows.Shapes;

namespace PP2023_KozlovS_ISP3120.Windows
{
    /// <summary>
    /// Логика взаимодействия для BuyProductWindow.xaml
    /// </summary>
    public partial class BuyProductWindow : Window
    {
        public Product Product { get; set; }
        public BuyProductWindow(Product product)
        {
            InitializeComponent();
            Product = product;

            DataContext = this;
        }

        private void QuantityTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            double quantity = 0;
            

            if (string.IsNullOrWhiteSpace(QuantityTextBox.Text))
            {
                SaveButton.IsEnabled = false;
                QuantityCorrectTextBlock.Visibility = Visibility.Visible;
                QuantityCorrectTextBlock.Text = "Количество должно быть введено!";
            }
            else if (!double.TryParse(QuantityTextBox.Text, out quantity))
            {
                SaveButton.IsEnabled = false;
                QuantityCorrectTextBlock.Visibility = Visibility.Visible;
                QuantityCorrectTextBlock.Text = "Введено некорректное количество!";
            }
            else if (quantity < 1 || quantity > 1000000)
            {
                SaveButton.IsEnabled = false;
                QuantityCorrectTextBlock.Visibility = Visibility.Visible;
                QuantityCorrectTextBlock.Text = "Количество должно быть в промежутке от 1 до 1 млн!";
            }
            else if (quantity > Product.Quantity)
            {
                SaveButton.IsEnabled = false;
                QuantityCorrectTextBlock.Visibility = Visibility.Visible;
                QuantityCorrectTextBlock.Text = "Количество не должно быть больше остатка на складе!";
            }
            else
            {
                QuantityCorrectTextBlock.Visibility = Visibility.Collapsed;
                SaveButton.IsEnabled = true;
                FinalPriceTextBlock.Text = Convert.ToString(Math.Round(Product.Price * quantity, 2));
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            int quantity = int.Parse(QuantityTextBox.Text);
            Order order = new Order()
            {
                ProductID = Product.ID,
                Quantity = quantity,
                Price = Product.Price,
                Date = DateTime.Now
            };
            bool isAdded;
            try
            {
                isAdded = App.ServerRequests.AddEntity(order);
                if (isAdded)
                {
                    App.InfoMessageBox("Заявка успешно добавлена!");
                    DialogResult = true;
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
    }
}
