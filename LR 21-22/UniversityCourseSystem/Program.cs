using Spectre.Console;
using UniversityCourseSystem.Data;
using UniversityCourseSystem.Models;
using UniversityCourseSystem.Services;
using UniversityCourseSystem.Services.Interfaces;
namespace UniversityCourseSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new UniversityDbContext();
            IGradeRepository repository = new GradeRepository(context);
            IGradeCalculator calculator = new GradeCalculator();
            INotificationService notifier = new EmailNotificationService();
            IReportGenerator reporter = new PdfReportGenerator();
            ILogger logger = new ConsoleLogger();
            var courseService = new CourseService(repository, calculator, notifier, reporter, logger);
            while (true)
            {
                try 
                { 
                AnsiConsole.Clear();
                AnsiConsole.Write(new FigletText("SRP").Color(Color.Cyan1));

                var choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Select an option:")
                        .AddChoices("Process Grades (SRP Demo)", "Exit"));
                if (choice == "Exit") break;
                var courseId = AnsiConsole.Ask<int>("Enter [green]Course ID[/]:");
                courseService.ProcessCourseGrades(courseId);
                }
                catch (Exception ex)
                {
                    AnsiConsole.MarkupLine($"[red]Error:[/] {ex.Message}");
                }
                AnsiConsole.MarkupLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
        static void SeedData(UniversityDbContext context)
        {
            /*var strategies = new List<GradingStrategy>
            {
                new GradingStrategy { StrategyName = "WeightedAverage", Description = "Exam 60%, Labs 40%", Configuration = "" },
                new GradingStrategy { StrategyName = "PassFail", Description = "Simple Pass/Fail", Configuration = "" },
                new GradingStrategy { StrategyName = "BestOfN", Description = "Best 5 grades", Configuration = "" }
            };
            context.GradingStrategies.AddRange(strategies);
            context.SaveChanges();
            var assignmentTypes = new List<AssignmentType>
            {
                new AssignmentType { TypeName = "Lab", Description = "Laboratory work", IsGradeable = true },
                new AssignmentType { TypeName = "Exam", Description = "Final exam", IsGradeable = true },
                new AssignmentType { TypeName = "Project", Description = "Course project", IsGradeable = true },
                new AssignmentType { TypeName = "Survey", Description = "Feedback", IsGradeable = false }, 
                new AssignmentType { TypeName = "Quiz", Description = "Self-check", IsGradeable = false }
            };
            context.AssignmentTypes.AddRange(assignmentTypes);
            context.SaveChanges();
            var reportTypes = new List<ReportType>
            {
                new ReportType { TypeName = "PDF", FileExtension = ".pdf", MimeType = "application/pdf" },
                new ReportType { TypeName = "Excel", FileExtension = ".xlsx", MimeType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" },
                new ReportType { TypeName = "CSV", FileExtension = ".csv", MimeType = "text/csv" },
                new ReportType { TypeName = "JSON", FileExtension = ".json", MimeType = "application/json" }
            };
            context.ReportTypes.AddRange(reportTypes);
            context.SaveChanges();
            var teachers = new List<Teacher>
            {
                new Teacher { FirstName = "Alan", LastName = "Turing", Email = "alan@uni.edu", Department = "Computer Science" },
                new Teacher { FirstName = "Ada", LastName = "Lovelace", Email = "ada@uni.edu", Department = "Mathematics" }
            };
            context.Teachers.AddRange(teachers);
            context.SaveChanges();
            var courses = new List<Course>
            {
                new Course
                {
                    Name = "Algorithms & Data Structures",
                    Code = "CS101",
                    Credits = 5,
                    TeacherId = teachers[0].Id, 
                    GradingStrategyId = strategies[0].Id 
                },
                new Course
                {
                    Name = "Discrete Mathematics",
                    Code = "MATH201",
                    Credits = 4,
                    TeacherId = teachers[1].Id, 
                    GradingStrategyId = strategies[1].Id 
                }
            };
            context.Courses.AddRange(courses);
            context.SaveChanges();
            var students = new List<Student>
            {
                new Student { FirstName = "John", LastName = "Doe", Email = "john@student.edu", StudentNumber = "S001" },
                new Student { FirstName = "Jane", LastName = "Smith", Email = "jane@student.edu", StudentNumber = "S002" },
                new Student { FirstName = "Bob", LastName = "Martin", Email = "bob@student.edu", StudentNumber = "S003" }
            };
            context.Students.AddRange(students);
            context.SaveChanges();
            var enrollments = new List<Enrollment>
            {
                new Enrollment { StudentId = students[0].Id, CourseId = courses[0].Id, EnrolledAt = DateTime.Now,LetterGrade = "" }, 
                new Enrollment { StudentId = students[1].Id, CourseId = courses[0].Id, EnrolledAt = DateTime.Now, LetterGrade = "" }, 
                new Enrollment { StudentId = students[2].Id, CourseId = courses[1].Id, EnrolledAt = DateTime.Now, LetterGrade = "" }  
            };
            context.Enrollments.AddRange(enrollments);
            context.SaveChanges();
            var assignments = new List<Assignment>
            {
                new Assignment
                {
                    Title = "Lab 1: Arrays",
                    Description = "Basic arrays task",
                    MaxPoints = 100,
                    DueDate = DateTime.Now.AddDays(7),
                    CourseId = courses[0].Id,
                    AssignmentTypeId = assignmentTypes[0].Id, 
                    IsGradeable = true
                },
                new Assignment
                {
                    Title = "Midterm Exam",
                    Description = "Theory test",
                    MaxPoints = 100,
                    DueDate = DateTime.Now.AddMonths(1),
                    CourseId = courses[0].Id,
                    AssignmentTypeId = assignmentTypes[1].Id, 
                    IsGradeable = true
                },
                new Assignment
                {
                    Title = "Course Feedback",
                    Description = "Anonymous survey",
                    MaxPoints = 0,
                    DueDate = DateTime.Now.AddMonths(2),
                    CourseId = courses[0].Id,
                    AssignmentTypeId = assignmentTypes[3].Id, 
                    IsGradeable = false
                }
            };
            context.Assignments.AddRange(assignments);
            context.SaveChanges();
            var grades = new List<Grade>
            {
                new Grade
                {
                    StudentId = students[0].Id,
                    AssignmentId = assignments[0].Id, 
                    Points = 95,
                    Feedback = "Excellent work!",
                    SubmittedAt = DateTime.Now,
                    GradedAt = DateTime.Now
                },
                new Grade
                {
                    StudentId = students[1].Id, 
                    AssignmentId = assignments[0].Id, 
                    Points = 88,
                    Feedback = "Good job",
                    SubmittedAt = DateTime.Now,
                    GradedAt = DateTime.Now
                }
            };
            context.Grades.AddRange(grades);
            context.SaveChanges();
            var reports = new List<Report>
            {
                new Report
                {
                    FileName = "Report_CS101.pdf",
                    GeneratedBy = "System",
                    FileSizeBytes = 1024,
                    CourseId = courses[0].Id,
                    ReportTypeId = reportTypes[0].Id 
                }
            };
            context.Reports.AddRange(reports);
            context.SaveChanges();*/
        }
    }
}

