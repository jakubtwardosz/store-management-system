using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace store_management_system.Data
{
    public class OrderItems
    {
        [ForeignKey(typeof(Orders))]
        public int OrderId { get; set; }
        [Key][PrimaryKey, AutoIncrement]
        public int ItemId { get; set; }
        [ForeignKey(typeof(Products))]
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int ListPrice { get; set; }
        public int Discount { get; set; }
    }
}
