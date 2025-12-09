using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P03_SalesDatabase.Data.Models;
namespace P03_SalesDatabase.Data
{
    internal class SalesContext : DbContext
    {
        public SalesContext()
        {
        }
        public SalesContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Sale> Sales { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-DI6V8K1\\SQLEXPRESS;Database=SalesDB;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(c => c.Name).IsUnicode();
                entity.Property(c => c.Email).IsUnicode(false);
            });
            modelBuilder.Entity<Store>(entity =>
            {
                entity.Property(s => s.Name).IsUnicode();
            });
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(p => p.Name).IsUnicode();
                entity.Property(p => p.Price).HasColumnType("decimal(18,2)");   
            });
            modelBuilder.Entity<Sale>().Property(s => s.Date).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Product>().Property(p => p.Description).HasDefaultValue("No description");
        }
    }
}
