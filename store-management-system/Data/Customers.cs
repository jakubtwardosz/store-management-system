﻿using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace store_management_system.Data
{
    public class Customers
    {
        [Key][PrimaryKey, AutoIncrement]
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastaName { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public int Phone { get; set; }
    }
}
