using Microsoft.Data.SqlClient;
using ProductStoreClassLibrary;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PP2023_KozlovS_ISP3120.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEditProductWindow.xaml
    /// </summary>
    public partial class AddEditProductWindow : Window
    {
        public string Header { get; set; }
        public Product Product { get; set; }
        public ComboBoxItem NewCategoryComboBoxItem { get; set; } = new ComboBoxItem() { Content = "Новая категория..." };


        public AddEditProductWindow()
        {
            InitializeComponent();

            DeleteButton.Visibility = Visibility.Collapsed;
            Header = "Добавление продукта";
            List<Category> categories;
            Product = new Product();

            DataContext = this;

            try
            {
                categories = App.ServerRequests.GetEntities<Category>();
            }
            catch (SqlException)
            {
                App.ErrorMessageBox("Произошла ошибка с базой данных!");
                return;
            }
            catch (Exception ex)
            {
                App.ErrorMessageBox(ex.Message);
                return;
            }

            foreach (Category category in categories)
            {
                CategoryComboBox.Items.Add(category);
            }
            CategoryComboBox.Items.Add(NewCategoryComboBoxItem);
        }

        public AddEditProductWindow(Product product)
        {
            InitializeComponent();

            Header = "Редактирование продукта";
            List<Category> categories;
            Product = product;

            DataContext = this;

            try
            {
                categories = App.ServerRequests.GetEntities<Category>();
            }
            catch (SqlException)
            {
                App.ErrorMessageBox("Произошла ошибка с базой данных!");
                return;
            }
            catch (Exception ex)
            {
                App.ErrorMessageBox(ex.Message);
                return;
            }

            foreach (Category category in categories)
            {
                CategoryComboBox.Items.Add(category);
            }
            CategoryComboBox.Items.Add(NewCategoryComboBoxItem);

            CategoryComboBox.SelectedItem = categories.Where(c => c.ID == product.CategoryID).FirstOrDefault();

        }

        private bool CheckLength()
        {
            bool isButtonEnabled = NameTextBox.Text.Length != 0 &&
                                   PriceTextBox.Text.Length != 0 &&
                                   QuantityTextBox.Text.Length != 0 &&
                                   MinQuantityTextBox.Text.Length != 0 &&
                                   UnitTextBox.Text.Length != 0 &&
                                   CategoryComboBox.SelectedIndex != -1 
                                   &&
                                   NameCorrectTextBlock.Visibility == Visibility.Collapsed &&
                                   PriceCorrectTextBlock.Visibility == Visibility.Collapsed &&
                                   QuantityCorrectTextBlock.Visibility == Visibility.Collapsed &&
                                   MinQuantityCorrectTextBlock.Visibility == Visibility.Collapsed &&
                                   UnitCorrectTextBlock.Visibility == Visibility.Collapsed &&
                                   NewCategoryCorrectTextBlock.Visibility == Visibility.Collapsed;
            SaveButton.IsEnabled = isButtonEnabled;
            return isButtonEnabled;
        }


        private void NameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                SaveButton.IsEnabled = false;
                NameCorrectTextBlock.Visibility = Visibility.Visible;
                NameCorrectTextBlock.Text = "Название должно быть введено!";
            }
            else if (NameTextBox.Text.Length > 100)
            {
                SaveButton.IsEnabled = false;
                NameCorrectTextBlock.Visibility = Visibility.Visible;
                NameCorrectTextBlock.Text = "Название должно быть не более 100 символов!";
            }
            else
            {
                NameCorrectTextBlock.Visibility = Visibility.Collapsed;
                CheckLength();
            }
        }

        private void PriceTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            double price;
            if (string.IsNullOrWhiteSpace(PriceTextBox.Text))
            {
                SaveButton.IsEnabled = false;
                PriceCorrectTextBlock.Visibility = Visibility.Visible;
                PriceCorrectTextBlock.Text = "Цена должна быть введена!";
            }
            else if (!double.TryParse(PriceTextBox.Text, out price))
            {
                SaveButton.IsEnabled = false;
                PriceCorrectTextBlock.Visibility = Visibility.Visible;
                PriceCorrectTextBlock.Text = "Введена некорректная цена!";
            }
            else if (price < 0 || price > 10000000)
            {
                SaveButton.IsEnabled = false;
                PriceCorrectTextBlock.Visibility = Visibility.Visible;
                PriceCorrectTextBlock.Text = "Цена должна быть в промежутке от 0 до 10 млн!";
            }
            else
            {
                PriceCorrectTextBlock.Visibility = Visibility.Collapsed;
                CheckLength();
            }
        }

        private void QuantityTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int quantity;
            if (string.IsNullOrWhiteSpace(QuantityTextBox.Text))
            {
                SaveButton.IsEnabled = false;
                QuantityCorrectTextBlock.Visibility = Visibility.Visible;
                QuantityCorrectTextBlock.Text = "Количество должно быть введено!";
            }
            else if (!int.TryParse(QuantityTextBox.Text, out quantity))
            {
                SaveButton.IsEnabled = false;
                QuantityCorrectTextBlock.Visibility = Visibility.Visible;
                QuantityCorrectTextBlock.Text = "Введено некорректное количество!";
            }
            else if (quantity < 0 || quantity > 1000000)
            {
                SaveButton.IsEnabled = false;
                QuantityCorrectTextBlock.Visibility = Visibility.Visible;
                QuantityCorrectTextBlock.Text = "Количество должно быть в промежутке от 0 до 1 млн!";
            }
            else
            {
                QuantityCorrectTextBlock.Visibility = Visibility.Collapsed;
                CheckLength();
            }
        }

        private void MinQuantityTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int minQuantity;
            if (string.IsNullOrWhiteSpace(MinQuantityTextBox.Text))
            {
                SaveButton.IsEnabled = false;
                MinQuantityCorrectTextBlock.Visibility = Visibility.Visible;
                MinQuantityCorrectTextBlock.Text = "Минимальное количество должно быть введено!";
            }
            else if (!int.TryParse(MinQuantityTextBox.Text, out minQuantity))
            {
                SaveButton.IsEnabled = false;
                MinQuantityCorrectTextBlock.Visibility = Visibility.Visible;
                MinQuantityCorrectTextBlock.Text = "Введено некорректное минимальное количество!";
            }
            else if (minQuantity < 0 || minQuantity > 1000000)
            {
                SaveButton.IsEnabled = false;
                MinQuantityCorrectTextBlock.Visibility = Visibility.Visible;
                MinQuantityCorrectTextBlock.Text = "Минимальное количество должно быть в промежутке от 0 до 1 млн!";
            }
            else
            {
                MinQuantityCorrectTextBlock.Visibility = Visibility.Collapsed;
                CheckLength();
            }
        }

        private void UnitTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UnitTextBox.Text))
            {
                SaveButton.IsEnabled = false;
                UnitCorrectTextBlock.Visibility = Visibility.Visible;
                UnitCorrectTextBlock.Text = "Единица измерения должна быть введена!";
            }
            else if (UnitTextBox.Text.Length > 50)
            {
                SaveButton.IsEnabled = false;
                UnitCorrectTextBlock.Visibility = Visibility.Visible;
                UnitCorrectTextBlock.Text = "Единица измерения должна быть не более 50 символов!";
            }
            else
            {
                UnitCorrectTextBlock.Visibility = Visibility.Collapsed;
                CheckLength();
            }
        }

        private void CategoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (NewCategoryComboBoxItem.IsSelected)
            {
                NewCategoryPanel.Visibility = Visibility.Visible;
                NewCategoryTextBox_TextChanged(sender, null);
            }
            else
            {
                NewCategoryPanel.Visibility = Visibility.Collapsed;
                NewCategoryCorrectTextBlock.Visibility = Visibility.Collapsed;
                CheckLength();
            }
        }

        private void NewCategoryTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NewCategoryTextBox.Text))
            {
                SaveButton.IsEnabled = false;
                NewCategoryCorrectTextBlock.Visibility = Visibility.Visible;
                NewCategoryCorrectTextBlock.Text = "Новая категория должна быть введена!";
            }
            else if (UnitTextBox.Text.Length > 50)
            {
                SaveButton.IsEnabled = false;
                NewCategoryCorrectTextBlock.Visibility = Visibility.Visible;
                NewCategoryCorrectTextBlock.Text = "Новая категория должна быть не более 100 символов!";
            }
            else
            {
                NewCategoryCorrectTextBlock.Visibility = Visibility.Collapsed;
                CheckLength();
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            bool isSaved;
            Category category;
            List<Category> categories = App.ServerRequests.GetEntities<Category>();

            if (NewCategoryPanel.Visibility == Visibility.Visible)
            {
                if (categories.Where(c => c.Name == NewCategoryTextBox.Text).Count() != 0)
                {
                    App.ErrorMessageBox("Данная категория уже существует!");
                    return;
                }
                else
                {
                    try
                    {
                        Category tempCategory = new Category { Name = NewCategoryTextBox.Text };
                        bool isCategoryAdded = App.ServerRequests.AddEntity(tempCategory);
                        if (!isCategoryAdded)
                        {
                            App.ErrorMessageBox("Не удалось добавить новую категорию!");
                            return;
                        }
                        else
                        {
                            categories = App.ServerRequests.GetEntities<Category>();
                            category = categories.Where(c => c.Name == tempCategory.Name).FirstOrDefault();
                        }
                    }
                    catch (SqlException)
                    {
                        App.ErrorMessageBox("Произошла ошибка с базой данных!");
                        return;
                    }
                    catch (Exception ex)
                    {
                        App.ErrorMessageBox(ex.Message);
                        return;
                    }
                }
            }
            else
            {
                category = CategoryComboBox.SelectedItem as Category;
            }


            double price = double.Parse(PriceTextBox.Text);
            int quantity = int.Parse(QuantityTextBox.Text);
            int minQuantity = int.Parse(MinQuantityTextBox.Text);


            Product = new Product
            {
                ID = Product.ID,
                Name = NameTextBox.Text,
                Price = price,
                Quantity = quantity,
                MinQuantity = minQuantity,
                Unit = UnitTextBox.Text,
                CategoryID = category.ID
            };

            if (Header == "Добавление продукта")
            {
                try
                {
                    isSaved = App.ServerRequests.AddEntity(Product);
                    if (isSaved)
                    {
                        App.InfoMessageBox("Продукт успешно добавлен!");
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
                return;
            }
            if (Header == "Редактирование продукта")
            {
                try
                {
                    isSaved = App.ServerRequests.EditEntity(Product);
                    if (isSaved)
                    {
                        App.InfoMessageBox("Продукт успешно отредактирован!");
                        DialogResult = true;
                        return;
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

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить продукт?",
                                                  "Внимание",
                                                  MessageBoxButton.YesNo,
                                                  MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                bool isDeleted = App.ServerRequests.DeleteEntity(Product);
                if (isDeleted)
                {
                    App.InfoMessageBox($"{Product.Name} удалён!");
                    DialogResult = true;
                }
                else
                {
                    App.ErrorMessageBox("Не удалось удалить продукт!");
                }

            }
        }
    }
}
