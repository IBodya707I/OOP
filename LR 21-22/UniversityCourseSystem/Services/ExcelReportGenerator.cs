using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCourseSystem.Services.Interfaces;
namespace UniversityCourseSystem.Services
{
    internal class ExcelReportGenerator: IReportGenerator
    {
        public void Generate(int courseId)
        {
            AnsiConsole.MarkupLine($"Excel Report for Course {courseId} generated and saved.");
        }
    }
}
