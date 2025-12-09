using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityCourseSystem.Models
{
    internal class ReportType
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)] public string TypeName { get; set; }
        [MaxLength(10)] public string FileExtension { get; set; }
        [MaxLength(100)] public string MimeType { get; set; }

        public ICollection<Report> Reports { get; set; }
    }
}
