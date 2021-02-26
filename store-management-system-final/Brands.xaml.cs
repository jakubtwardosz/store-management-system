using System.Windows;
using System.Windows.Controls;

namespace store_management_system_final
{
    /// <summary>
    /// Logika interakcji dla klasy Brands.xaml
    /// </summary>
    public partial class Brands : Window
    {
        /// <summary>
        /// Inicialize Window for managing brands
        /// </summary>
        public Brands()
        {
            InitializeComponent();

            this.BrandsDataGrid.ItemsSource = BrandsService.GetBrandToDisplay();
        }

        BrandsService BrandsService = new BrandsService();

        private void AddBrand(object s, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxBrand.Text))
            {
                MessageBox.Show("You need to type something!");
                return;
            }

            BrandsService.AddBrand(TextBoxBrand.Text);
            MessageBox.Show("Added!");
        }

        private void ReadBrand(object s, RoutedEventArgs e)
        {
            BrandsDataGrid.ItemsSource = BrandsService.GetBrandToDisplay();
            MessageBox.Show("Loaded!");
        }

        private void brandsGridDataSelectionChanged(object s, SelectionChangedEventArgs e)
        {
            BrandsService.selected = GetSelectedDisplay(e);

            TextBoxBrand.Text = BrandsService.selected?.Name;
        }
        /// <summary>
        /// Gets selected brand
        /// </summary>
        /// <param name="e"></param>
        /// <returns>Return selected or null if not selected</returns>
        public static brands_displayed GetSelectedDisplay(SelectionChangedEventArgs e)
        {
            return e.AddedItems.Count == 0
                ? null
                : e.AddedItems[0] as brands_displayed;
        }

        private void UpdateBrand(object s, RoutedEventArgs e)
        {
            if (BrandsService.selected == null)
            {
                NotSelectedMessage();
                return;
            }

            BrandsService.UpdateBrand(TextBoxBrand.Text);
            MessageBox.Show("Updated!");
        }

        private void DeleteBrand(object s, RoutedEventArgs e)
        {
            if (BrandsService.selected == null)
            {
                NotSelectedMessage();
                return;
            }

            brands DeletedBrand = BrandsService.DeleteSelectedBrand();
            MessageBox.Show($"Deleted! {DeletedBrand?.brand_name}");
        }
        /// <summary>
        /// Comment for display when user try to update
        /// </summary>
        public static void NotSelectedMessage()
        {
            MessageBox.Show("You must select something!");
        }
    }
}
