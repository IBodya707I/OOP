using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCourseSystem.Models;
using UniversityCourseSystem.Services.Interfaces;

namespace UniversityCourseSystem.Services
{
    internal class GradeCalculator: IGradeCalculator
    {
        public decimal CalculateFinalGrade(List<Grade> grades)
        {
            if (grades == null || grades.Count == 0)
            {
                throw new ArgumentException("Grades list cannot be null or empty.");
            }
            AnsiConsole.MarkupLine($"[blue]Calculating final grade for {grades.Count} grades...[/]");
            return grades.Average(g => g.Points);
        }
    }
}
