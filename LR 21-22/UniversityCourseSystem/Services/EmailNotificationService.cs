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
    internal class EmailNotificationService: INotificationService
    {
        public void Notify(Student student, string message)
        {
            AnsiConsole.MarkupLine($"Sent to {student.Email}: {message}");
        }
    }
}
