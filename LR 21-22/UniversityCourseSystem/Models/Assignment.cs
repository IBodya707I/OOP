using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityCourseSystem.Models
{
    internal class Assignment
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(200)] public string Title { get; set; }
        public string Description { get; set; }
        public int MaxPoints { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsGradeable { get; set; } 
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int AssignmentTypeId { get; set; }
        public AssignmentType AssignmentType { get; set; }
        public ICollection<Grade> Grades { get; set; }
    }
}
