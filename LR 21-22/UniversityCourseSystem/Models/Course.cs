using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityCourseSystem.Models
{
    internal class Course
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(200)] 
        public string Name { get; set; }
        [MaxLength(20)] 
        public string Code { get; set; }
        public int Credits { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int GradingStrategyId { get; set; }
        public GradingStrategy GradingStrategy { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<Assignment> Assignments { get; set; }
        public ICollection<Report> Reports { get; set; }
    }
}
