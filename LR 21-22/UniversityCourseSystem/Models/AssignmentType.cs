using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityCourseSystem.Models
{
    internal class AssignmentType
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)] public string TypeName { get; set; } 
        public string Description { get; set; }
        public bool IsGradeable { get; set; } 

        public ICollection<Assignment> Assignments { get; set; }
    }
}
