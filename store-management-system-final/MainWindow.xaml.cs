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
        private brands_displayed selected;


        public MainWindow()
        {
            InitializeComponent();

            StoreDBEntities db = new StoreDBEntities();

            var brands = from b in db.brands
                         select new brands_displayed
                         {
                             Id = b.brand_id,
                             Name = b.brand_name
                         };


            this.BrandsDataGrid.ItemsSource = brands.ToList();
        }

        private void AddBrand(object s, RoutedEventArgs e)
        {
            StoreDBEntities db = new StoreDBEntities();

            brands brandsObject = new brands()
            {
                brand_name = TextBoxBrand.Text
            };

            db.brands.Add(brandsObject);
            db.SaveChanges();
        }
        /// <summary>
        /// Metoda do pobierania brandów
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void ReadBrand(object s, RoutedEventArgs e)
        {
            StoreDBEntities db = new StoreDBEntities();

            var brands = from b in db.brands
                         select new brands_displayed
                         {
                             Id = b.brand_id,
                             Name = b.brand_name
                         }; 

            this.BrandsDataGrid.ItemsSource = brands.ToList(); 
        }

        private void brandsGridDataSelectionChanged(object s, SelectionChangedEventArgs e)
        {
            selected = GetSelectedDisplay(e);

            TextBoxBrand.Text = selected?.Name;
        }

        private static brands_displayed GetSelectedDisplay(SelectionChangedEventArgs e)
        {
            return e.AddedItems.Count == 0
                ? null
                : e.AddedItems[0] as brands_displayed;
        }

        private void UpdateBrand(object s, RoutedEventArgs e)
        {
            if(selected == null)
            {
                MessageBox.Show("Zaznacz cos");
                return;
            }

            StoreDBEntities db = new StoreDBEntities();

            var brands = from b in db.brands 
                         where b.brand_id == selected.Id
                         select b;

            brands toUpdate = brands.FirstOrDefault();
            // brands toUpdate2 = db.brands.FirstOrDefault(b => b.brand_id == selected.Id);

            toUpdate.brand_name = TextBoxBrand.Text;

            db.SaveChanges();
        }

        private void DeleteBrand(object s, RoutedEventArgs e)
        {

        }

        class brands_displayed
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }


    }
}