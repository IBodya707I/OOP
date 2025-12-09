using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models
{
    public class Student
    {   
        [Key]
        public int StudentId { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(10)]
        public string? PhoneNumber { get; set; }
        public DateTime RegisteredOn { get; set; }
        public DateTime? Birthday { get; set; }
        public ICollection<StudentCourse> Courses { get; set; } = new List<StudentCourse>();
        public ICollection<Homework> Homeworks { get; set; } = new List<Homework>();

    }
}
