using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace store_management_system.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
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
                new Product { Id = 1, Name = "Koszulka", Description = "Adidas", Price = 29.99, Unit = 5 },
                new Product { Id = 2, Name = "Koszulka", Description = "Puma", Price = 29.99, Unit = 50 },
                new Product { Id = 3, Name = "Spodnie", Description = "Nike", Price = 39.99, Unit = 20 },
                new Product { Id = 4, Name = "Czapka", Description = "Umbro", Price = 19.99, Unit = 9 }
            };
        }
    }
}
