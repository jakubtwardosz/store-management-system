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

            StoreDBEntities db = new StoreDBEntities();

            var products = from p in db.products
                           select new
                           {
                               ProductName = p.product_name,
                               Price = p.price,
                               Quantity = p.quantity,
                               Brand = p.brands,
                               Category = p.category
                           };

            this.productGridData.ItemsSource = products.ToList();
        }

        private void AddProduct(object s, RoutedEventArgs e)
        {
            StoreDBEntities db = new StoreDBEntities();

            /*

            products productsObject = new products()
            {
                product_name = addNewProductName.Text;
                price = addNewProductPrice.Text;
                quantity = addNewProductQuantity.Text;

            }

            db.

            db.Save*/

            /*
            dbContext.Products.Add(NewProduct);
            dbContext.SaveChanges();
            GetProducts();
            NewProduct = new Products();
            AddNewProductGrid.DataContext = NewProduct;*/
        }
    }
}
