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

namespace store_management_system_final
{
    /// <summary>
    /// Logika interakcji dla klasy Orders.xaml
    /// </summary>
    public partial class Orders : Window
    {
        public Orders()
        {
            InitializeComponent();

            this.OrdersDataGrid.ItemsSource = OrdersService.GetOrdersToDisplay();
        }

        OrdersService OrdersService = new OrdersService();


        private void AddOrder(object sender, RoutedEventArgs e)
        {
            if (OrdersService.TryAddOrder(CustomerId.Text, OrderStatus.Text, OrderDate.SelectedDate))
            {
                MessageBox.Show("Added!");
            }
            else
            {
                MessageBox.Show("Customer not found!");
            }            
        }

        private void ReadOrder(object sender, RoutedEventArgs e)
        {
            OrdersDataGrid.ItemsSource = OrdersService.GetOrdersToDisplay();
            MessageBox.Show("Loaded!");
        }

        private void ordersGridDataSelectionChanged(object s, SelectionChangedEventArgs e)
        {
            OrdersService.selected = GetSelectedDisplay(e);

            var selected = OrdersService.selected;
            //TextBoxBrand.Text = BrandsService.selected?.Name;

            CustomerId.Text = selected?.CustomerID.ToString();
            OrderStatus.Text = selected?.OrderStatus;
            OrderDate.Text = selected?.OrderDate.ToString();

        }

        public static orders_displayed GetSelectedDisplay(SelectionChangedEventArgs e)
        {
            return e.AddedItems.Count == 0
                ? null
                : e.AddedItems[0] as orders_displayed;
        }


        private void UpdateOrder(object sender, RoutedEventArgs e)
        {
            if (OrdersService.selected == null)
            {
                NotSelectedMessage();
                return;
            }

            OrdersService.UpdateOrder(CustomerId.Text, OrderStatus.Text, OrderDate.SelectedDate);

            MessageBox.Show("Updated!");
        }

        private void DeleteOrder(object sender, RoutedEventArgs e)
        {
            if (OrdersService.selected == null)
            {
                NotSelectedMessage();
                return;
            }

            orders DeletedOrder = OrdersService.DeleteSelectedOrder();
            MessageBox.Show($"Deleted! {DeletedOrder?.order_id}");
        }

        private static void NotSelectedMessage()
        {
            MessageBox.Show("You must select something!");
        }
    }
}
