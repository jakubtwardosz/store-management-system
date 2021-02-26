using System.Windows;
using System.Windows.Controls;

namespace store_management_system_final
{
    /// <summary>
    /// Logika interakcji dla klasy Products.xaml
    /// </summary>
    public partial class Products : Window
    {
        /// <summary>
        /// Inicialize Window for managing products
        /// </summary>
        public Products()
        {
            InitializeComponent();

            this.ProductsDataGrid.ItemsSource = ProductsService.GetProductToDisplay();
        }

        ProductsService ProductsService = new ProductsService();

        private void AddProduct(object sender, RoutedEventArgs e)
        {
            if (ProductsService.TryAddProduct(ProductName.Text, ProductBrandId.Text, ProductCategoryId.Text, ProductPrice.Text, ProductQuantity.Text))
            {
                MessageBox.Show("Added!");
            }
            else
            {
                MessageBox.Show("Product not added!");
            }
        }

        private void productsGridDataSelectionChanged(object s, SelectionChangedEventArgs e)
        {
            ProductsService.selected = GetSelectedDisplay(e);
            ProductName.Text = ProductsService.selected?.ProductName;
            ProductBrandId.Text = ProductsService.selected?.BrandId.ToString();
            ProductCategoryId.Text = ProductsService.selected?.CategoryId.ToString();
            ProductPrice.Text = ProductsService.selected?.ProductPrice.ToString();
            ProductQuantity.Text = ProductsService.selected?.ProductQuantity.ToString();

        }

        /// <summary>
        /// Get selected product
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static products_displayed GetSelectedDisplay(SelectionChangedEventArgs e)
        {
            return e.AddedItems.Count == 0
                ? null
                : e.AddedItems[0] as products_displayed;
        }


        private void ReadProduct(object sender, RoutedEventArgs e)
        {
            ProductsDataGrid.ItemsSource = ProductsService.GetProductToDisplay();
            MessageBox.Show("Loaded!");
        }

        private void UpdateProduct(object sender, RoutedEventArgs e)
        {

            if (ProductsService.selected == null)
            {
                NotSelectedMessage();
                return;
            }

            ProductsService.UpdateProduct(ProductName.Text, ProductPrice.Text, ProductQuantity.Text);

            MessageBox.Show("Updated!");

        }

        private void DeleteProduct(object sender, RoutedEventArgs e)
        {
            if (ProductsService.selected == null)
            {
                NotSelectedMessage();
                return;
            }

            products DeletedProduct = ProductsService.DeleteSelectedProduct();
            MessageBox.Show($"Deleted! {DeletedProduct?.product_id} ");

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
