using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCourseSystem.Services.Interfaces;

namespace UniversityCourseSystem.Services
{
    internal class CourseService
    {
        private IGradeRepository repository;
        private IGradeCalculator calculator;
        private INotificationService notifier;
        private IReportGenerator reporter;
        private ILogger logger;
        public CourseService(
            IGradeRepository repository,
            IGradeCalculator calculator,
            INotificationService notifier,
            IReportGenerator reporter,
            ILogger logger)
        {
            this.repository = repository;
            this.calculator = calculator;
            this.notifier = notifier;
            this.reporter = reporter;
            this.logger = logger;
        }

        public void ProcessCourseGrades(int courseId)
        {
            var students = repository.GetStudentsByCourse(courseId);

            if (!students.Any())
            {
                AnsiConsole.MarkupLine("[red]No students found for this course![/]");
                return;
            }
            var table = new Table();
            table.AddColumn("Student");
            table.AddColumn("ID");
            table.AddColumn("Calculated Grade");
            AnsiConsole.Progress()
                .Start(ctx =>
                {
                    AnsiConsole.MarkupLine("[green]Calculating grades...[/]");
                    foreach (var student in students)
                    {
                        var grades = repository.GetGradesByStudent(student.Id, courseId);
                        decimal finalGrade = calculator.CalculateFinalGrade(grades);
                        repository.SaveFinalGrade(student.Id, courseId, finalGrade);
                        notifier.Notify(student, $"Final Grade: {finalGrade:F2}");
                        table.AddRow(
                            $"{student.FirstName} {student.LastName}",
                            student.StudentNumber,
                            $"[bold yellow]{finalGrade:F2}[/]"
                        );
                    }
                });
            reporter.Generate(courseId);

            AnsiConsole.Write(table);
            AnsiConsole.MarkupLine("[green]Course processing completed successfully![/]");
        }
    }
}
