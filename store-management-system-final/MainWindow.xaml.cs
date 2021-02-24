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

            var brands = from b in db.brands
                         select new
                         {
                             ID = b.brand_id,
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

        private void ReadBrand(object s, RoutedEventArgs e)
        {
            StoreDBEntities db = new StoreDBEntities();

            this.BrandsDataGrid.ItemsSource = db.brands.ToList();
        }

        private void brandsGridDataSelectionChanged(object s, SelectionChangedEventArgs e)
        {

        }

        private void UpdateBrand(object s, RoutedEventArgs e)
        {

        }

        private void DeleteBrand(object s, RoutedEventArgs e)
        {

        }



    }
}







        /*private void brandsGridDataSelectionChanged(object s, SelectionChangedEventArgs e)
        {
            brands brands = new brands();
            brands = (bra)this.BrandsDataGrid.SelectedItems[0];


            foreach (var item in this.BrandsDataGrid.SelectedItems)
            {
                brands = item as brands;                

                MessageBox.Show(brands.brand_name);
            }

            *//* if (this.BrandsDataGrid.SelectedIndex >= 0 && this.BrandsDataGrid.SelectedItems.Count >= 0)
              {

                      brands b = (brands)this.BrandsDataGrid.SelectedItems[0];
                       = b.brand_name;

              }*/

/*
            Member member = new Member();
            foreach (var obj in dataGrid.SelectedItems)
            {
                member = obj as Member;
                str += "DepartmetId : " + member.DepartmetId + "   EmployeeId:" + member.EmployeeId + "  Name:" + member.Name + "  Address:" + member.Address + "  Email:" + member.Email + "\n";
            }*//*
        }

        private void MyDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            if (dr != null)
            {

                ID_gry_tb.Text = dr["ID_gry"].ToString();
                Nazwa_tb.Text = dr["Nazwa"].ToString();
                Kategoria_tb.Text = dr["Kategoria"].ToString();
                Kategoria_wiekowa_tb.Text = dr["Kategoria_wiekowa"].ToString();
                Data_wydania_tb.Text = dr["Data_wydania"].ToString();
                Cena_dzien_tb.Text = dr["Cena_dzien"].ToString();

                add_btn.IsEnabled = false;
                update_btn.IsEnabled = true;
                delete_btn.IsEnabled = true;
                ID_gry_tb.IsEnabled = false;
            }
        }


        private void UpdateBrand(object s, RoutedEventArgs e)
        {
            StoreDBEntities db = new StoreDBEntities();

            var r = from b in db.brands
                    where b.brand_id == 1
                    select b;

            brands obj = r.SingleOrDefault();

            if (obj != null)
            {
                obj.brand_name = this.TextBoxBrand.Text;
                db.SaveChanges();
            }

        }

        private void DeleteBrand(object s, RoutedEventArgs e)
        {
            StoreDBEntities db = new StoreDBEntities();

            var r = from b in db.brands
                    where b.brand_id == 1
                    select b;

            brands obj = r.SingleOrDefault();

            if (obj != null)
            {
                db.brands.Remove(obj);
                db.SaveChanges();
            }
        }




        *//* private void GetProducts()
         {
             StoreDBEntities db = new StoreDBEntities();
             this.productGridData.ItemsSource = db.products.ToList();
         }

         private void AddProduct(object s, RoutedEventArgs e)
         {
             StoreDBEntities db = new StoreDBEntities();

             products productsObject = new products()
             {
                 product_name = addNewProductName.Text,
                 product_price = int.Parse(addNewProductPrice.Text),
                 product_quantity = int.Parse(addNewProductQuantity.Text)
             };

             db.products.Add(productsObject);
             db.SaveChanges();
             GetProducts();
         }

         private void ProductGridDataSelectionChanged(object sender, SelectionChangedEventArgs e)
         {
             Console.WriteLine();
         }

         private void UpdateProduct(object s, RoutedEventArgs e)
         {
             StoreDBEntities db = new StoreDBEntities();

             var r = from d in db.products
                     where d.product_id == 1
                     select d;

             foreach (var item in r)
             {
                 MessageBox.Show(item.product_name);
                 item.product_name = "Bulbulator2000";
             }

             db.SaveChanges();
         }*//*


    }
}
*/