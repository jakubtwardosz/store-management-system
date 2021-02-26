using System;
using System.Collections.Generic;
using System.Linq;

namespace store_management_system_final
{
    /// <summary>
    /// Class to manage order in database
    /// </summary>
    public class OrdersService
    {
        /// <summary>
        /// Field that remember selected order
        /// </summary>
        public orders_displayed selected { get; set; }

        /// <summary>
        /// Method to get order to display
        /// </summary>
        /// <returns></returns>
        public List<orders_displayed> GetOrdersToDisplay()
        {
            // IDisposable
            using (StoreDBEntities db = new StoreDBEntities())
            {
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
        }


        /// <summary>
        /// Validating if fields are correct and adding order to database
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="orderStatus"></param>
        /// <param name="orderDate"></param>
        /// <returns>True if added, false if not added</returns>
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
        /// <summary>
        /// Updating selected order in database
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="orderStatus"></param>
        /// <param name="orderDate"></param>
        /// <returns></returns>
        public orders UpdateOrder(string customerId, string orderStatus, DateTime? orderDate)
        {
            StoreDBEntities db = new StoreDBEntities();

            var orders = from o in db.orders
                         where o.order_id == selected.Id
                         select o;

            orders toUpdate = orders.FirstOrDefault();
            // brands toUpdate2 = db.brands.FirstOrDefault(b => b.brand_id == selected.Id);

            if (toUpdate == null)
            {
                return null;
            }

            toUpdate.order_date = orderDate;
            toUpdate.order_status = orderStatus;

            db.SaveChanges();

            return toUpdate;
        }
        /// <summary>
        /// Deleting selected order from database
        /// </summary>
        /// <returns>Null if not found, deleted value if existed in database</returns>
        public orders DeleteSelectedOrder()
        {
            StoreDBEntities db = new StoreDBEntities();

            // Pobierz z bazy order_items razem z orderem

            var filteredOrders = from o in db.orders.Include(nameof(orders.order_items))
                                 where o.order_id == selected.Id
                                 select o;


            orders toDelete = filteredOrders.FirstOrDefault();

            if (toDelete == null)
            {
                return null;
            }

            db.orders.Remove(toDelete);

            db.SaveChanges();

            return toDelete;
        }
    }
    /// <summary>
    /// Fields displayed from selected order
    /// </summary>
    public class orders_displayed
    {
        public int Id { get; set; }
        public int? CustomerID { get; set; }
        public string OrderStatus { get; set; }
        public DateTime? OrderDate { get; set; }
    }
}
