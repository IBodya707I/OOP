using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityCourseSystem.Models
{
    internal class Report
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(255)] public string FileName { get; set; }
        public DateTime GeneratedAt { get; set; } = DateTime.Now;
        [MaxLength(100)] public string GeneratedBy { get; set; }
        public int FileSizeBytes { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int ReportTypeId { get; set; }
        public ReportType ReportType { get; set; }
    }
}
