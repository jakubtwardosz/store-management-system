using System.Collections.Generic;
using System.Linq;

namespace store_management_system_final
{
    /// <summary>
    /// Class to manage brands in database
    /// </summary>
    public class BrandsService
    {
        /// <summary>
        /// Field that remember selected brand
        /// </summary>
        public brands_displayed selected { get; set; }

        /// <summary>
        /// Method to get brands to display
        /// </summary>
        /// <returns></returns>
        public List<brands_displayed> GetBrandToDisplay()
        {
            // IDisposable
            using (StoreDBEntities db = new StoreDBEntities())
            {
                var brands = from b in db.brands
                             select new brands_displayed
                             {
                                 Id = b.brand_id,
                                 Name = b.brand_name
                             };

                return brands.ToList();
            }
        }

        /// <summary>
        /// Adding brand to database
        /// </summary>
        /// <param name="name"></param>
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

        /// <summary>
        /// Updating selected brand in database
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Null if not selected, updated version if sucesssed</returns>
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

        /// <summary>
        /// Deleting selected brand from database
        /// </summary>
        /// <returns>Null if not found, deleted value if existed in database</returns>
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

    /// <summary>
    ///  Field displayed from selected brand
    /// </summary>
    public class brands_displayed
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}