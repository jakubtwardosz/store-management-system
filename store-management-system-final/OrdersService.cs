using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store_management_system_final
{
    public class OrdersService
    {
        public List<orders_displayed> GetOrdersToDisplay()
        {
            StoreDBEntities db = new StoreDBEntities();

            // Sprawdzić rzutowanie

            var orders = from o in db.orders
                         select new orders_displayed
                         {
                             Id = o.order_id,
                             CustomerID = (int)o.customer_id,
                             OrderStatus = o.order_status,
                             OrderDate = (DateTime)o.order_date
                         };

            return orders.ToList();
        }
    }

    public class orders_displayed
    {
        public int Id { get; set; }
        public int CustomerID { get; set; }
        public string OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
