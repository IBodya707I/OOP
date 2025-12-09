using P01_StudentSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P01_StudentSystem.Data;
using P01_StudentSystem.Data.Models;

namespace Task_01
{
    public static class Seeder
    {
        public static void Seed(StudentSystemContext context)
        {
            var student1 = new Student { Name = "Олександр Ткаченко", PhoneNumber = "0981112233", RegisteredOn = DateTime.Now };
            var student2 = new Student { Name = "Ірина Бондар", Birthday = new DateTime(1999, 5, 20), RegisteredOn = DateTime.Now.AddDays(-10) };
            var student3 = new Student { Name = "Василь Стус", RegisteredOn = DateTime.Now.AddDays(-20) };
            context.Students.AddRange(student1, student2, student3);
            context.SaveChanges();
            var cSharpCourse = new Course
            {
                Name = "C# Professional",
                Price = 300.00m,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(3),
                Description = "Поглиблене вивчення .NET"
            };
            var sqlCourse = new Course
            {
                Name = "SQL Fundamentals",
                Price = 150.50m,
                StartDate = DateTime.Now.AddDays(5),
                EndDate = DateTime.Now.AddMonths(1),
                Description = "Основи баз даних"
            };
            context.Courses.AddRange(cSharpCourse, sqlCourse);
            var resources = new List<Resource>
            {
                new Resource { Name = "Урок 1: Синтаксис", Url = "http://video.com/1", ResourceType = ResourseType.Video, Course = cSharpCourse },
                new Resource { Name = "Методичка PDF", Url = "http://docs.com/manual", ResourceType = ResourseType.Document, Course = cSharpCourse },
                new Resource { Name = "Слайди про SELECT", Url = "http://slides.com/sql", ResourceType = ResourseType.Presentation, Course = sqlCourse }
            };
            context.Resources.AddRange(resources);
            context.SaveChanges();
            var studentCourses = new List<StudentCourse>
            { 
                new StudentCourse { StudentId = student1.StudentId, CourseId = cSharpCourse.CourseId },
                new StudentCourse { StudentId = student2.StudentId, CourseId = cSharpCourse.CourseId },
                new StudentCourse {StudentId = student2.StudentId, CourseId = sqlCourse.CourseId},
                new StudentCourse { StudentId = student3.StudentId, CourseId = sqlCourse.CourseId }
            };
            context.StudentCourses.AddRange(studentCourses);
            context.SaveChanges();
            var homeworks = new List<Homework>
            {
                new Homework
                {
                    Content = "calculator.zip",
                    ContentType = ContentType.Zip,
                    SubmissionTime = DateTime.Now,
                    Student = student1,
                    Course = cSharpCourse
                },
                new Homework
                {
                    Content = "essay.pdf",
                    ContentType = ContentType.Pdf,
                    SubmissionTime = DateTime.Now.AddHours(-5),
                    Student = student2,
                    Course = cSharpCourse
                },
                new Homework
                {
                    Content = "queries.sql",
                    ContentType = ContentType.Application,
                    SubmissionTime = DateTime.Now.AddDays(-1),
                    Student = student3,
                    Course = sqlCourse
                }
            };
            context.Homeworks.AddRange(homeworks);
            context.SaveChanges();
        }
    }
}
