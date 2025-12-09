using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P03__FootballBetting.Data.Models
{
    internal class Town
    {
        [Key]
        public int TownId {  get; set; }
        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public string Name {  get; set; }
        public Country Country { get; set; }
    }
}
