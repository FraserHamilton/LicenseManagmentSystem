using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LicenseManagmentSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LicenseManagmentSystem.Data
{
    public class ManagerContext : DbContext
    {
        public ManagerContext(DbContextOptions<ManagerContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<LicenseKey> LicenseKeys { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<LicenseKey>().ToTable("LicenseKey");
            modelBuilder.Entity<Product>().ToTable("Product");
        }
    }
}
