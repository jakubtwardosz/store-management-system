using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store_management_system_final
{
    class CustomersService
    {
        public customers_displayed selected { get; set; }

        public List<customers_displayed> GetCustomersToDisplay()
        {
            StoreDBEntities db = new StoreDBEntities();

            var customers = from c in db.customers
                         select new customers_displayed
                         {
                             Id = c.customer_id,
                             FirstName = c.first_name,
                             LastName = c.last_name,
                             Email = c.email,
                             Street = c.street,
                             ZipCode = c.zip_code,
                             City = c.city,
                             Phone = c.phone
                         };

            return customers.ToList();
        }
    }

    public class customers_displayed
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public int Phone { get; set; }
    }

}
