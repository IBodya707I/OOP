using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace P01_StudentSystem.Data.Models
{
    public enum ResourseType
    {
        Presentation,
        Document,
        Video,
        Other
    }
    public class Resource
    {
        [Key]
        public int ResourseId { get; set; }
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public string Url { get; set; }
        public ResourseType ResourceType { get; set; }  
        public Course Course { get; set; }
    }
}
