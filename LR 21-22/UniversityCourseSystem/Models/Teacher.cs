using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityCourseSystem.Models
{
    internal class Teacher
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)] 
        public string FirstName { get; set; }
        [MaxLength(100)] 
        public string LastName { get; set; }
        [MaxLength(255)] 
        public string Email { get; set; }
        [MaxLength(100)] 
        public string Department { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}
