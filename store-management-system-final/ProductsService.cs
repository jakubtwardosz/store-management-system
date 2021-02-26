using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store_management_system_final
{
    public class ProductsService
    {
        public products_displayed selected { get; set; }

        public List<products_displayed> GetProductToDisplay()
        {
            StoreDBEntities db = new StoreDBEntities();

            var products = from p in db.products
                           select new products_displayed
                           {
                               Id = p.product_id,
                               ProductName = p.product_name,
                               BrandId = p.brand_id,
                               CategoryId = p.category_id,
                               ProductPrice = p.product_price,
                               ProductQuantity = p.product_quantity
                           };

            return products.ToList();
        }
    }

    public class products_displayed
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        // int?
        public int? BrandId { get; set; }
        public int? CategoryId { get; set; }
        public int ProductPrice { get; set; }
        public int? ProductQuantity { get; set; }
    }
}
