using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace store_management_system.Data
{
    public class Brands
    {
        [Key]
        public int BrandId { get; set; }
        public string BrandName { get; set; }
    }
}
