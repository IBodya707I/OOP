using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Tracing;

namespace P01_HospitalDatabase.Data.Models
{
    internal class Visitation
    {
        [Key]
        public int VisitationId { get; set; }
        public DateTime Date { get; set; }
        [MaxLength(250)]
        public string Comments { get; set; }
        public Patient Patient { get; set; }
    }
}
