using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCourseSystem.Models;

namespace UniversityCourseSystem.Services.Interfaces
{
    internal interface IGradeCalculator
    {
        decimal CalculateFinalGrade(List<Grade> grades);
    }
}
