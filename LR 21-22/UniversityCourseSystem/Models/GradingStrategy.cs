using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityCourseSystem.Models
{
    internal class GradingStrategy
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)] public string StrategyName { get; set; }
        public string Description { get; set; }
        public string Configuration { get; set; } 
        public ICollection<Course> Courses { get; set; }
    }
}
