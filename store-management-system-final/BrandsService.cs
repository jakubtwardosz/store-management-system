using System.Collections.Generic;
using System.Linq;

namespace store_management_system_final
{
    public class BrandsService
    {
        public brands_displayed selected { get; set; }

        public List<brands_displayed> GetBrandToDisplay()
        {
            StoreDBEntities db = new StoreDBEntities();

            var brands = from b in db.brands
                         select new brands_displayed
                         {
                             Id = b.brand_id,
                             Name = b.brand_name
                         };

            return brands.ToList();
        }

        public void AddBrand(string name)
        {
            StoreDBEntities db = new StoreDBEntities();

            brands brandsObject =
                new brands()
                {
                    brand_name = name
                };

            db.brands.Add(brandsObject);
            db.SaveChanges();
        }

        public brands UpdateBrand(string name)
        {
            StoreDBEntities db = new StoreDBEntities();

            var brands = from b in db.brands
                         where b.brand_id == selected.Id
                         select b;

            brands toUpdate = brands.FirstOrDefault();
            // brands toUpdate2 = db.brands.FirstOrDefault(b => b.brand_id == selected.Id);

            if (toUpdate == null)
            {
                return null;
            }

            toUpdate.brand_name = name;

            db.SaveChanges();

            return toUpdate;
        }

        public brands DeleteSelectedBrand()
        {

            // To do: null 
            StoreDBEntities db = new StoreDBEntities();

            var brands = from b in db.brands
                         where b.brand_id == selected.Id
                         select b;

            // System.Reflection.TargetException: „Dla metody niestatycznej wymagany jest obiekt docelowy.”

            brands toDelete = brands.FirstOrDefault();

            if (toDelete == null)
            {
                return null;
            }

            // brands toUpdate2 = db.brands.FirstOrDefault(b => b.brand_id == selected.Id);

            db.brands.Remove(toDelete);

            db.SaveChanges();

            return toDelete;
        }
    }


    public class brands_displayed
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}