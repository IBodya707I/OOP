using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityCourseSystem.Models
{
    internal class Enrollment
    {
        [Key]
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? FinalGrade { get; set; }
        [MaxLength(2)] 
        public string LetterGrade { get; set; }
        public DateTime EnrolledAt { get; set; } = DateTime.Now;
        public DateTime? CompletedAt { get; set; }
    }
}
