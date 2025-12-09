using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityCourseSystem.Models
{
    internal class Student
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)] 
        public string FirstName { get; set; }
        [MaxLength(100)] 
        public string LastName { get; set; }
        [MaxLength(255)] 
        public string Email { get; set; }
        [MaxLength(20)] 
        public string StudentNumber { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<Grade> Grades { get; set; }
        public ICollection<Notification> Notifications { get; set; }
    }
}
