using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace store_management_system.Data
{
    public class Orders
    {
        [Key][PrimaryKey, AutoIncrement]
        public int OrderId { get; set; }
        [ForeignKey(typeof(Customers))]
        public int CustomerId { get; set; }
        public string OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
