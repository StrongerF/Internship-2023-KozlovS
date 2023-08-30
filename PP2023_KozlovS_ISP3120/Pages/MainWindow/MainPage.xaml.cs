using Microsoft.Data.SqlClient;
using PP2023_KozlovS_ISP3120.Windows;
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

namespace PP2023_KozlovS_ISP3120.Pages.MainWindow
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public List<Product> Products { get; set; }
        public List<Order> Orders { get; set; }
        public ServerRequests ServerRequests { get; set; }
        public ComboBoxItem FilterAllTypesComboBoxItem { get; set; } = new ComboBoxItem() { Content = "Все типы" };
        public ComboBoxItem FilterAllTypesOrdersComboBoxItem { get; set; } = new ComboBoxItem() { Content = "Все заявки" };
        public ComboBoxItem FilterAcceptedOrdersComboBoxItem { get; set; } = new ComboBoxItem() { Content = "Принятые" };
        public ComboBoxItem FilterDeclinedOrdersComboBoxItem { get; set; } = new ComboBoxItem() { Content = "Отклонённые" };
        public ComboBoxItem FilterNonOrdersComboBoxItem { get; set; } = new ComboBoxItem() { Content = "Нерассмотренные" };

        public MainPage()
        {
            InitializeComponent();

            ServerRequests = App.ServerRequests;
            DataContext = this;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ReloadPage();
        }

        private void ReloadPage()
        {
            SearchTextBox.Text = string.Empty;
            FilterComboBox.Items.Clear();
            SearchOrdersTextBox.Text = string.Empty;
            FilterOrdersComboBox.Items.Clear();
            List<Product> products;
            List<Category> categories;
            List<Order> orders;
            try
            {
                products = ServerRequests.GetEntities<Product>();
                categories = ServerRequests.GetEntities<Category>();
                orders = ServerRequests.GetEntities<Order>();
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

            ProductsItemsControl.ItemsSource = products;
            Products = products;
            OrdersItemsControl.ItemsSource = orders;
            Orders = orders;

            FilterComboBox.Items.Add(FilterAllTypesComboBoxItem);
            FilterOrdersComboBox.Items.Add(FilterAllTypesOrdersComboBoxItem);
            foreach (Category category in categories)
            {
                FilterComboBox.Items.Add(category);
            }
            FilterOrdersComboBox.Items.Add(FilterAcceptedOrdersComboBoxItem);
            FilterOrdersComboBox.Items.Add(FilterDeclinedOrdersComboBoxItem);
            FilterOrdersComboBox.Items.Add(FilterNonOrdersComboBoxItem);

            FilterComboBox.SelectedIndex = 0;
            FilterOrdersComboBox.SelectedIndex = 0;
        }

        private void EditProductButton_Loaded(object sender, RoutedEventArgs e)
        {
            if (App.ServerRequests.CurrentUser.EmployeeVisibility == "Visible")
            {
                (sender as Button).Visibility = Visibility.Visible;
            }
            else
            {
                (sender as Button).Visibility = Visibility.Collapsed;
            }
        }

        private void BuyProductButton_Loaded(object sender, RoutedEventArgs e)
        {
            if (App.ServerRequests.CurrentUser.ClientVisibility == "Visible")
            {
                (sender as Button).Visibility = Visibility.Visible;
            }
            else
            {
                (sender as Button).Visibility = Visibility.Collapsed;
            }
        }

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            AddEditProductWindow window = new AddEditProductWindow();
            bool? isAdded = window.ShowDialog();
            ReloadPage();
        }


        private void FilterProducts()
        {
            List<Product> sordedProducts = Products;
            if (!FilterAllTypesComboBoxItem.IsSelected)
            {
                sordedProducts = sordedProducts.Where(p => p.CategoryID == FilterComboBox.SelectedIndex).ToList();
            }

            sordedProducts = sordedProducts.Where(p => p.Name.ToLower().Contains(SearchTextBox.Text.ToLower())).ToList();

            ProductsItemsControl.ItemsSource = sordedProducts;
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            FilterProducts();
        }

        private void EditProductButton_Click(object sender, RoutedEventArgs e)
        {
            Product product = (sender as Button).DataContext as Product;
            if (product == null)
            {
                return;
            }
            AddEditProductWindow window = new AddEditProductWindow(product);
            bool? isAdded = window.ShowDialog();
            ReloadPage();
        }

        private void FilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterProducts();
        }

        private void AcceptOrderButton_Loaded(object sender, RoutedEventArgs e)
        {
            if (App.ServerRequests.CurrentUser.EmployeeVisibility == "Visible" &&
                ((sender as Button).DataContext as Order).IsAccepted == null)
            {
                (sender as Button).Visibility = Visibility.Visible;
            }
            else
            {
                (sender as Button).Visibility = Visibility.Collapsed;
            }
        }

        private void DeclineOrderButton_Loaded(object sender, RoutedEventArgs e)
        {
            if (App.ServerRequests.CurrentUser.EmployeeVisibility == "Visible" &&
                ((sender as Button).DataContext as Order).IsAccepted == null)
            {
                (sender as Button).Visibility = Visibility.Visible;
            }
            else
            {
                (sender as Button).Visibility = Visibility.Collapsed;
            }
        }

        private void AcceptOrderButton_Click(object sender, RoutedEventArgs e)
        {
            Order order = (sender as Button).DataContext as Order;
            MessageBoxResult result = MessageBox.Show("Вы действительно хотите принять заявку?",
                                                  "Внимание",
                                                  MessageBoxButton.YesNo,
                                                  MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    bool isAccepted = App.ServerRequests.EditOrderAccept(order, true);
                    if (isAccepted)
                    {
                        App.InfoMessageBox("Заявка была успешно принята!");
                    }
                    else
                    {
                        App.ErrorMessageBox("Не удалось принять заявку!");
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

                ReloadPage();
            }
        }

        private void DeclineOrderButton_Click(object sender, RoutedEventArgs e)
        {
            Order order = (sender as Button).DataContext as Order;
            MessageBoxResult result = MessageBox.Show("Вы действительно хотите отклонить заявку?",
                                                  "Внимание",
                                                  MessageBoxButton.YesNo,
                                                  MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    bool isAccepted = App.ServerRequests.EditOrderAccept(order, false);
                    if (isAccepted)
                    {
                        App.InfoMessageBox("Заявка была успешно отменена!");
                    }
                    else
                    {
                        App.ErrorMessageBox("Не удалось отменить заявку!");
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
                ReloadPage();
            }
        }

        private void SearchOrdersTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            FilterOrders();
        }

        private void FilterOrdersComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterOrders();
        }

        private void FilterOrders()
        {
            List<Order> sordedOrders = Orders;
            if (FilterAllTypesOrdersComboBoxItem.IsSelected)
            {
                sordedOrders = Orders;
            }
            else if (FilterAcceptedOrdersComboBoxItem.IsSelected)
            {
                sordedOrders = Orders.Where(o => o.IsAccepted == true).ToList();
            }
            else if (FilterDeclinedOrdersComboBoxItem.IsSelected)
            {
                sordedOrders = Orders.Where(o => o.IsAccepted == false).ToList();
            }
            else if (FilterNonOrdersComboBoxItem.IsSelected)
            {
                sordedOrders = Orders.Where(o => o.IsAccepted == null).ToList();
            }


            sordedOrders = sordedOrders.Where(p => p.ProductName.ToLower().Contains(SearchOrdersTextBox.Text.ToLower())).ToList();

            OrdersItemsControl.ItemsSource = sordedOrders;
        }

        private void BuyProductButton_Click(object sender, RoutedEventArgs e)
        {
            BuyProductWindow window = new BuyProductWindow((sender as Button).DataContext as Product);
            bool? isDeleted = window.ShowDialog();
            ReloadPage();
        }

    }
}
