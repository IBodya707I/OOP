using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityCourseSystem.Models
{
    internal class Notification
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(200)] public string Subject { get; set; }
        public string Body { get; set; }
        [MaxLength(50)] public string NotificationType { get; set; }
        public DateTime SentAt { get; set; } = DateTime.Now;
        public bool IsRead { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
