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

        public bool TryAddCustomer(string FirstName, string LastName, string Email, string Street, string ZipCode, string City, string Phone)
        {
            StoreDBEntities db = new StoreDBEntities();

            if (int.TryParse(Phone, out int phone) 
                && db.customers.All(customers => customers.email != Email)
                && Phone.Length == 9 )
            {
                customers customersObject =
                new customers()
                {
                    first_name = FirstName,
                    last_name = LastName,
                    email = Email,
                    street = Street,
                    zip_code = ZipCode,
                    city = City,
                    phone = phone
                };

                db.customers.Add(customersObject);

                db.SaveChanges();

                return true;
            }

            return false;

        }

        public customers UpdateCustomer(string FirstName, string LastName, string Email, string Street, string ZipCode, string City, string Phone)
        {
            StoreDBEntities db = new StoreDBEntities();

            var customers = from c in db.customers
                         where c.customer_id == selected.Id
                         select c;

            customers toUpdate = customers.FirstOrDefault();
            // brands toUpdate2 = db.brands.FirstOrDefault(b => b.brand_id == selected.Id);

            if (toUpdate == null || int.TryParse(Phone, out int phone) == false || ZipCode.Length > 6)
            {
                return null;
            }

            toUpdate.first_name = FirstName;
            toUpdate.last_name = LastName;
            toUpdate.email = Email;
            toUpdate.street = Street;
            toUpdate.zip_code = ZipCode;
            toUpdate.city = City;
            toUpdate.phone = phone;

            db.SaveChanges();

            return toUpdate;
        }

        public customers DeleteSelectedCustomer()
        {
            StoreDBEntities db = new StoreDBEntities();

            // Pobierz z bazy order_items razem z orderem

            var filteredCustomer = from c in db.customers.Include(nameof(customers.orders))
                                 where c.customer_id == selected.Id
                                 select c;


            customers toDelete = filteredCustomer.FirstOrDefault();

            if (toDelete == null)
            {
                return null;
            }

            db.customers.Remove(toDelete);

            db.SaveChanges();

            return toDelete;
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

