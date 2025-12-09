using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03_SalesDatabase.Data.Models
{
    internal class Customer
    {
        public int CustomerId { get; set; }
        public string CreditsCardNumber { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(80)] 
        public string Email { get; set; }
        public List<Sale> Sales { get; set; }
    }
}
