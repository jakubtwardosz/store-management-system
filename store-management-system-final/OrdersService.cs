using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store_management_system_final
{
    public class OrdersService
    {
        public orders_displayed selected { get; set; }

        public List<orders_displayed> GetOrdersToDisplay()
        {
            StoreDBEntities db = new StoreDBEntities();

            // Sprawdzić rzutowanie

            var orders = from o in db.orders
                         select new orders_displayed
                         {
                             Id = o.order_id,
                             CustomerID = o.customer_id,
                             OrderStatus = o.order_status,
                             OrderDate = o.order_date
                         };

            return orders.ToList();
        }

        // DateTime?

        public bool TryAddOrder(string customerId, string orderStatus, DateTime? orderDate)
        {
            StoreDBEntities db = new StoreDBEntities();
            
            if (int.TryParse(customerId, out int Id) 
                && db.customers.Any(customer => customer.customer_id == Id))
            {
                orders ordersObject =
                new orders()
                {
                    customer_id = Id,
                    order_status = orderStatus,
                    order_date = orderDate
                };

                db.orders.Add(ordersObject);

                db.SaveChanges();

                return true;
            }

            return false;

        }
    }

    public class orders_displayed
    {
        public int Id { get; set; }
        public int? CustomerID { get; set; }
        public string OrderStatus { get; set; }
        public DateTime? OrderDate { get; set; }
    }
}
