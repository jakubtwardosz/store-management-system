using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace store_management_system.Data
{
    public class Products
    {
        [Key][PrimaryKey, AutoIncrement]
        public int ProductId { get; set; }
        public string Name { get; set; }
        [ForeignKey(typeof(Brands))]
        public int BrandId { get; set; }
        [ForeignKey(typeof(Category))]
        public int CategoryId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
