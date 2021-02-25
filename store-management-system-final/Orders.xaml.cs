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
            OrdersService.AddOrder(CustomerId.Text, OrderStatus.Text, OrderDate.SelectedDate);
            MessageBox.Show("Added!");
        }

        private void ReadOrder(object sender, RoutedEventArgs e)
        {

        }

        private void ordersGridDataSelectionChanged(object s, SelectionChangedEventArgs e)
        {

        }

        private void UpdateOrder(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteOrder(object sender, RoutedEventArgs e)
        {

        }
    }
}
