using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCourseSystem.Models;

namespace UniversityCourseSystem.Services.Interfaces
{
    internal interface IGradeRepository
    {
        List<Student> GetStudentsByCourse(int courseId);
        List<Grade> GetGradesByStudent(int studentId, int courseId);
        void SaveFinalGrade(int studentId, int courseId, decimal grade);
    }
}
