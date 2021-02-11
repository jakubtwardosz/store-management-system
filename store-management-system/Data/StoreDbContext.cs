using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace store_management_system.Data
{
    public class StoreDbContext : DbContext
    {
        public DbSet<Brands> Brands { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Products> Products { get; set; }



        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Products> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>().HasData(GetProducts());
            base.OnModelCreating(modelBuilder);
        }

        private Products[] GetProducts()
        {
            return new Products[]
            {
                new Products { Id = 1, Name = "Koszulka", Description = "Adidas", Price = 29.99, Unit = 5 },
                new Products { Id = 2, Name = "Koszulka", Description = "Puma", Price = 29.99, Unit = 50 },
                new Products { Id = 3, Name = "Spodnie", Description = "Nike", Price = 39.99, Unit = 20 },
                new Products { Id = 4, Name = "Czapka", Description = "Umbro", Price = 19.99, Unit = 9 }
            };
        }
    }
}
