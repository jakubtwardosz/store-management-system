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

        public bool TryAddProduct(string ProductName, string ProductBrandId, string ProductCategoryId, string ProductPrice, string ProductQuantity)
        {
            StoreDBEntities db = new StoreDBEntities();

            if (int.TryParse(ProductPrice, out int Price)
                && int.TryParse(ProductQuantity, out int Quantity))
            {

                int? category_id = null;
                if (int.TryParse(ProductCategoryId, out int categoryId) && db.category.Any(category => category.category_id == categoryId))
                {
                    category_id = categoryId;
                }

                int? brand_id = null;
                if (int.TryParse(ProductBrandId, out int brandId) && db.brands.Any(brands => brands.brand_id == brandId))
                {
                    brand_id = brandId;
                }

                products productsObject =
                    new products() 
                    {
                        product_name = ProductName,
                        product_price = Price,
                        product_quantity = Quantity,
                        brand_id = brand_id,
                        category_id = category_id
                    };

                db.products.Add(productsObject);
                db.SaveChanges();

                return true;
            }

            return false;
        }

        public products DeleteSelectedProduct()
        {
            StoreDBEntities db = new StoreDBEntities();

            // Pobierz z bazy order_items razem z orderem

            var filteredProduct = from p in db.products.Include(nameof(products.order_items))
                                  where p.product_id == selected.Id
                                  select p;

            products toDelete = filteredProduct.FirstOrDefault();

            if (toDelete == null)
            {
                return null;
            }

            db.products.Remove(toDelete);

            db.SaveChanges();

            return toDelete;
        }

        public products UpdateProduct(string ProductName, string ProductPrice, string ProductQuantity)
        {
            StoreDBEntities db = new StoreDBEntities();

            var products = from p in db.products
                           where p.product_id == selected.Id
                           select p;

            products toUpdate = products.FirstOrDefault();
            // brands toUpdate2 = db.brands.FirstOrDefault(b => b.brand_id == selected.Id);

            if (toUpdate == null
                || int.TryParse(ProductPrice, out int productPrice) == false
                || int.TryParse(ProductQuantity, out int productQuantity) == false)
            {
                return null;
            }

            toUpdate.product_name = ProductName;
            toUpdate.product_price = productPrice;
            toUpdate.product_quantity = productQuantity;

            db.SaveChanges();

            return toUpdate;
        }
    }

    public class products_displayed
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int? BrandId { get; set; }
        public int? CategoryId { get; set; }
        public int ProductPrice { get; set; }
        public int? ProductQuantity { get; set; }
    }
}
