using P01_HospitalDatabase.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_01.P01_HospitalDatabase.Data.Models
{
    internal class Doctor
    {
        public int DoctorId { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Specialty { get; set; }
        [MaxLength(100)]
        public string email { get; set; }
        [MaxLength(30)]
        public string password { get; set; }    
        public ICollection<Visitation> Visitations { get; set; } 
    }
}
