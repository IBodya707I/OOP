using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03__FootballBetting.Data.Models
{
    internal class Team
    {
        [Key]
        public int TeamId { get; set; }
        public decimal Budget { get; set; }
        public string Initials { get; set; }
        public string Name { get; set; }
        public string LogoUrl { get; set; }
        [ForeignKey("PrimaryColor")]
        public int? PrimaryKitColor { get; set; }
        public Color PrimaryColor { get; set; }
        [ForeignKey("SecondColor")]
        public int? SecondaryKitColor { get; set; }
        public Color SecondColor { get; set; }
        [ForeignKey("Town")]
        public int TownId { get; set; }
        public Town Town { get; set; }
        public ICollection<Player> Players { get; set; } = new List<Player>();
        [InverseProperty("HomeTeam")]
        public ICollection<Game> HomeGames { get; set; } = new List<Game>();
        [InverseProperty("AwayTeam")]
        public ICollection<Game> AwayGames { get; set; } = new List<Game>();
        [NotMapped]
        public ICollection<Game> AllGames { get { return HomeGames.Concat(AwayGames).ToList(); } }
    }
}
