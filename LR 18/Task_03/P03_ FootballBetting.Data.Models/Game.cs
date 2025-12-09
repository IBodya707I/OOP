using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03__FootballBetting.Data.Models
{
    internal class Game
    {
        [Key]
        public int GameId { get; set; }
        public decimal AwayTeamBetRate { get; set; }
        public int AwayteamGoals { get; set; }
        [ForeignKey("AwayTeam")]
        public int? AwayTeamId { get; set; }
        public Team AwayTeam { get; set; }
        public decimal DrawBetRate { get; set; }
        public decimal HomeTeamBetRate { get; set; }
        public int HomeTeamGoals { get; set; }
        [ForeignKey("HomeTeam")]
        public int? HomeTeamId { get; set; }
        public Team HomeTeam { get; set; }
        public string Result {  get; set; }
        public DateTime DateTime { get; set; }
        public ICollection<PlayerStatitic> PlayerStatitics { get; set; } = new List<PlayerStatitic>();
        public ICollection<Bet> Bets { get; set; } = new List<Bet>();

    }
}
