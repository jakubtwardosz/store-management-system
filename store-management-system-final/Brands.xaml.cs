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
    /// Logika interakcji dla klasy Brands.xaml
    /// </summary>
    public partial class Brands : Window
    {
        public Brands()
        {
            InitializeComponent();

            this.BrandsDataGrid.ItemsSource = BrandsService.GetBrandToDisplay();
        }

        BrandsService BrandsService = new BrandsService();

        private void AddBrand(object s, RoutedEventArgs e)
        {
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

        private static brands_displayed GetSelectedDisplay(SelectionChangedEventArgs e)
        {
            return e.AddedItems.Count == 0
                ? null
                : e.AddedItems[0] as brands_displayed;
        }

        private void UpdateBrand(object s, RoutedEventArgs e)
        {
            if (BrandsService.selected == null)
            {
                MessageBox.Show("You must select something!");
                return;
            }

            BrandsService.UpdateBrand(TextBoxBrand.Text);
            MessageBox.Show("Updated!");
        }

        private void DeleteBrand(object s, RoutedEventArgs e)
        {
            brands DeletedBrand = BrandsService.DeleteSelectedBrand();
            MessageBox.Show($"Deleted! {DeletedBrand.brand_name}");
        }
    }
}
