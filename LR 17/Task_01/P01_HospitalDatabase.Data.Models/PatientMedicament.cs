using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace P01_HospitalDatabase.Data.Models
{
    internal class PatientMedicament
    {
        public int PatientId { get; set; }
        public int MedicamentId { get; set; }
        public Patient Patient { get; set; }
        public Medicament Medicament { get; set; }
    }
}
