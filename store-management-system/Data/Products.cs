using System;
using System.Collections.Generic;
using System.Text;

namespace store_management_system.Data
{
    public class Products
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
    }
}
