using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models
{
    public enum ContentType
    {
        Application,
        Pdf,
        Zip
    }
    public class Homework
    {
        [Key]
        public int HomeworkId { get; set; }
        public string Content { get; set; }
        public ContentType ContentType {  get; set; }
        public DateTime SubmissionTime { get; set; }
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}
