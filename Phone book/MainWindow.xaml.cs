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

namespace Phone_book
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            PhoneDBEntities db = new PhoneDBEntities();

            var tblContact = from c in db.tbl_contact
                         select new
                         {
                             ID = c.ContactID,
                             FirstName = c.FirstName,
                             LastName = c.LastName,
                             ContactNo = c.ContactNo,
                             Address = c.Address,
                             Gender = c.Gender
                         };


            this.tblContact.ItemsSource = tblContact.ToList();

        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void Add_Contact(object sender, RoutedEventArgs e)
        {
            PhoneDBEntities db = new PhoneDBEntities();

            tbl_contact contactObject = new tbl_contact()
            {
                FirstName = txtboxFirstName.Text,
                LastName = txtboxLastName.Text,
                ContactNo = txtboxContactNo.Text,
                Address = txtboxAddress.Text,
                Gender = cmbGender.Text
            };

            db.tbl_contact.Add(contactObject);
            db.SaveChanges();
        }
        private void Update_Contact(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_Contact(object sender, RoutedEventArgs e)
        {

        }

        private void Clear_Contact(object sender, RoutedEventArgs e)
        {
            PhoneDBEntities db = new PhoneDBEntities();

            this.tblContact.ItemsSource = db.tbl_contact.ToList();

        }
    }
}
