using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

using P01_HospitalDatabase.Data.Models;

namespace P01_HospitalDatabase.Data
{
    internal class HospitalContext: DbContext
    {
        public HospitalContext()
        {
        }
        public HospitalContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Visitation> Visitations { get; set; }
        public DbSet<Diagnose> Diagnoses { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<PatientMedicament> PatientsMedicaments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-DI6V8K1\\SQLEXPRESS;Database=HospitalDB;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientMedicament>().HasKey(pm => new { pm.PatientId, pm.MedicamentId });
            modelBuilder.Entity<Patient>().Property(p => p.FirstName).IsUnicode();
            modelBuilder.Entity<Patient>().Property(p => p.LastName).IsUnicode();
            modelBuilder.Entity<Patient>().Property(p => p.Address).IsUnicode();
            modelBuilder.Entity<Patient>().Property(p => p.Email).IsUnicode(false);
            modelBuilder.Entity<Visitation>().Property(v => v.Comments).IsUnicode();
            modelBuilder.Entity<Diagnose>().Property(d => d.Name).IsUnicode();
            modelBuilder.Entity<Diagnose>().Property(d => d.Comments).IsUnicode();
            modelBuilder.Entity<Medicament>().Property(m => m.Name).IsUnicode();
        }
    }
}
