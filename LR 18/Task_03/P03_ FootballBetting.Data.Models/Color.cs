using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03__FootballBetting.Data.Models
{
    internal class Color
    {
        [Key]
        public int ColorId { get; set; }
        public string Name { get; set; }
        [InverseProperty("SecondColor")]
        public ICollection<Team> SecondaryColorTeams { get; set; } = new List<Team>();
        [InverseProperty("PrimaryColor")]
        public ICollection<Team> PrimaryColorTeans { get; set; } = new List<Team>();
    }
}
