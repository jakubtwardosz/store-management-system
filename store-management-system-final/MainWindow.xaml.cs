using System.Windows;

namespace store_management_system_final
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenBrandWindow(object sender, RoutedEventArgs e)
        {
            Brands brands = new Brands();
            brands.Show();
        }

        private void OpenOrdersWindow(object sender, RoutedEventArgs e)
        {
            Orders orders = new Orders();
            orders.Show();
        }

        private void OpenProductsWindow(object sender, RoutedEventArgs e)
        {
            Products products = new Products();
            products.Show();
        }

        private void OpenCustomersWindow(object sender, RoutedEventArgs e)
        {
            Customers customers = new Customers();
            customers.Show();
        }
    }
}