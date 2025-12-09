using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCourseSystem.Data;
using UniversityCourseSystem.Models;
using UniversityCourseSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace UniversityCourseSystem.Services
{
    internal class GradeRepository: IGradeRepository
    {
        private UniversityDbContext context;

        public GradeRepository(UniversityDbContext context)
        {
            this.context = context;
        }
        public List<Student> GetStudentsByCourse(int courseId)
        {
            return context.Enrollments
                .Where(e => e.CourseId == courseId)
                .Select(e => e.Student)
                .Distinct()
                .ToList();
        }
        public List<Grade> GetGradesByStudent(int studentId, int courseId)
        {
            return context.Grades
                .Include(g => g.Assignment)
                .Where(g => g.StudentId == studentId && g.Assignment.CourseId == courseId)
                .ToList();
        }
        public void SaveFinalGrade(int studentId, int courseId, decimal grade)
        {
            var enrollment = context.Enrollments
                .FirstOrDefault(e => e.StudentId == studentId && e.CourseId == courseId);

            if (enrollment != null)
            {
                enrollment.FinalGrade = grade;
                context.SaveChanges();
            }
        }
    }
}
