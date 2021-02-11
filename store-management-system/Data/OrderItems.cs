using System;
using System.Collections.Generic;
using System.Text;

namespace store_management_system.Data
{
    public class OrderItems
    {
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int ListPrice { get; set; }
        public int Discount { get; set; }
    }
}
