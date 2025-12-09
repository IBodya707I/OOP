using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCourseSystem.Models;
using Microsoft.EntityFrameworkCore;
namespace UniversityCourseSystem.Data
{
    internal class UniversityDbContext: DbContext
    {
        public UniversityDbContext() { }
        public UniversityDbContext(DbContextOptions<UniversityDbContext> options) : base(options) { }

        // Реєстрація таблиць
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<GradingStrategy> GradingStrategies { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<AssignmentType> AssignmentTypes { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<ReportType> ReportTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-DI6V8K1\\SQLEXPRESS;Database=University;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
