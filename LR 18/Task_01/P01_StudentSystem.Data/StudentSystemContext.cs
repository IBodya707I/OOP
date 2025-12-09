using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {
        }
        public StudentSystemContext(DbContextOptions<StudentSystemContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-DI6V8K1\\SQLEXPRESS;Database=StudentSystemDB;Trusted_Connection=True;TrustServerCertificate=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });
            modelBuilder.Entity<Student>().Property(s => s.PhoneNumber).IsUnicode(false);
            modelBuilder.Entity<Resource>().Property(s => s.Url).IsUnicode(false);
            modelBuilder.Entity<Homework>().Property(h => h.Content).IsUnicode(false);
            modelBuilder.Entity<Course>().Property(c => c.Price).HasPrecision(18, 2);
            base.OnModelCreating(modelBuilder);
        }
    }
}
