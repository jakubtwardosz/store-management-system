using System.Windows;
using System.Windows.Controls;

namespace store_management_system_final
{
    /// <summary>
    /// Logika interakcji dla klasy Customers.xaml
    /// </summary>
    public partial class Customers : Window
    {
        /// <summary>
        /// Inicialize Window from managing customers
        /// </summary>
        public Customers()
        {
            InitializeComponent();

            this.CustomersDataGrid.ItemsSource = CustomersService.GetCustomersToDisplay();
        }

        CustomersService CustomersService = new CustomersService();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddCustomer(object sender, RoutedEventArgs e)
        {
            if (CustomersService.TryAddCustomer(FirstName: CustomerFirstName.Text, LastName: CustomerLastName.Text, Email: CustomerEmail.Text, Street: CustomerStreet.Text, ZipCode: CustomerZipCode.Text, City: CustomerCity.Text, Phone: CustomerPhone.Text))
            {
                MessageBox.Show("Added!");
            }
            else
            {
                MessageBox.Show("Customer not added!");
            }


        }

        private void customersGridDataSelectionChanged(object s, SelectionChangedEventArgs e)
        {

            CustomersService.selected = GetSelectedDisplay(e);

            var selected = CustomersService.selected;

            CustomerFirstName.Text = CustomersService.selected?.FirstName;
            CustomerLastName.Text = CustomersService.selected?.LastName;
            CustomerEmail.Text = CustomersService.selected?.Email;
            CustomerStreet.Text = CustomersService.selected?.Street;
            CustomerZipCode.Text = CustomersService.selected?.ZipCode;
            CustomerCity.Text = CustomersService.selected?.City;
            CustomerPhone.Text = CustomersService.selected?.Phone.ToString();
        }

        /// <summary>
        /// Gets selected customer
        /// </summary>
        /// <param name="e"></param>
        /// <returns>Return selected or null if not selected</returns>
        public static customers_displayed GetSelectedDisplay(SelectionChangedEventArgs e)
        {
            return e.AddedItems.Count == 0
                ? null
                : e.AddedItems[0] as customers_displayed;
        }



        private void ReadCustomer(object sender, RoutedEventArgs e)
        {
            CustomersDataGrid.ItemsSource = CustomersService.GetCustomersToDisplay();
            MessageBox.Show("Loaded!");

        }

        private void UpdateCustomer(object sender, RoutedEventArgs e)
        {
            if (CustomersService.selected == null)
            {
                NotSelectedMessage();
                return;
            }

            var result = CustomersService.UpdateCustomer(FirstName: CustomerFirstName.Text, LastName: CustomerLastName.Text, Email: CustomerEmail.Text, Street: CustomerStreet.Text, ZipCode: CustomerZipCode.Text, City: CustomerCity.Text, Phone: CustomerPhone.Text);
            if (result == null)
            {
                MessageBox.Show("Fail to update!");
            }
            else
            {
                MessageBox.Show("Updated!");
            }
        }

        private void DeleteCustomer(object sender, RoutedEventArgs e)
        {

            if (CustomersService.selected == null)
            {
                NotSelectedMessage();
                return;
            }

            customers DeletedOrder = CustomersService.DeleteSelectedCustomer();
            MessageBox.Show($"Deleted! {DeletedOrder?.customer_id}");
        }


        /// <summary>
        /// Comment for display when user try to update or 
        /// </summary>
        public static void NotSelectedMessage()
        {
            MessageBox.Show("You must select something!");
        }
    }
}
