using P01_BillsPaymentSystem.Data.EntityConfig;
using BillsPaymentSystem.P01_BillsPaymentSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using P01_BillsPaymentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillsPaymentSystem.P01_BillsPaymentSystem.Data
{
    internal class BillsPaymentContext:DbContext
    {
        public BillsPaymentContext() { }
        public BillsPaymentContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-DI6V8K1\\SQLEXPRESS;Database=BillsPaymentSystemDB;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new  CreditCardConfiguration());
            modelBuilder.ApplyConfiguration(new  PaymentMethodConfiguration());
            modelBuilder.ApplyConfiguration(new  BankAccountConfiguration());
        }
    }
}
