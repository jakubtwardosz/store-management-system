using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace store_management_system.Data
{
    class ProductDBContext : DbContext
    {
        public ProductDBContext (DbContextOptions<ProductDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(GetProducts());
            base.OnModelCreating(modelBuilder);
        }

        private Product[] GetProducts()
        {
            return new Product[]
            {
                new Product { ID = 1, Name = "Koszulka", Description = "Adidas", Price = 29.99, Unit = 5 },
                new Product { ID = 2, Name = "Koszulka", Description = "Puma", Price = 29.99, Unit = 50 },
                new Product { ID = 3, Name = "Spodnie", Description = "Nike", Price = 39.99, Unit = 20 },
                new Product { ID = 4, Name = "Czapka", Description = "Umbro", Price = 19.99, Unit = 9 }
            };
        }
    }
}
