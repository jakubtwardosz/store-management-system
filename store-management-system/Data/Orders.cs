using System;
using System.Collections.Generic;
using System.Text;

namespace store_management_system.Data
{
    class Orders
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
